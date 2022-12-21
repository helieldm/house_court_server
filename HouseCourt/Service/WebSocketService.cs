using System.Net.WebSockets;
using System.Text;
using HouseCourt.Context;

namespace HouseCourt.Service;

public class WebSocketService
{
    private readonly ILogger<WebSocketService> _logger;
    private readonly MessageService _messageService;
    private readonly TaskService _taskService;
    
    public WebSocketService(ILogger<WebSocketService> logger, MessageService messageService, TaskService taskService)
    {
        _logger = logger;
        _messageService = messageService;
        _taskService = taskService;
    }

    public async Task Echo(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        _logger.Log(LogLevel.Information, $"Message received from Client : {Encoding.UTF8.GetString(buffer)}");

        while (!result.CloseStatus.HasValue)
        {
            var serverMsg = Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
            
            SubmitAvailableTasks(webSocket,_messageService.GetMacAddressFromMessage(Encoding.UTF8.GetString(buffer)), result);
            
            _messageService.Decode(Encoding.UTF8.GetString(buffer));

            await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
            _logger.Log(LogLevel.Information, "Message sent to Client");

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            _logger.Log(LogLevel.Information, $"Message received from Client : {Encoding.UTF8.GetString(buffer)}");
                
        }
        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        _logger.Log(LogLevel.Information, "WebSocket connection closed");
    }

    private async void SubmitAvailableTasks(WebSocket webSocket , String houseMacAddress, WebSocketReceiveResult? result)
    {
        if (houseMacAddress != "ERROR")
        {
            List<Entities.Task> tasksToSend = _taskService.GetTasksToSend(houseMacAddress);

            foreach (var task in tasksToSend)
            {
                var serverMsg = Encoding.UTF8.GetBytes(task.Message);
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                _logger.Log(LogLevel.Information, "Task sent to client");
                task.Sent = true;
                _taskService.UpdateTask(task);
            }
        }

    }
}