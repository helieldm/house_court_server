using System.Text;
using HouseCourt.Context;
using HouseCourt.Entities;
namespace HouseCourt.Controllers;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class WebSocketController : ControllerBase
{
    private readonly ILogger<WebSocketController> _logger;
    private ContextHouseCourt _context;
    public WebSocketController(ILogger<WebSocketController> logger)
    {
        _logger = logger;
        _context = new ContextHouseCourt();
    }
    
    [HttpGet("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    // </snippet>

    [HttpPost]
    [Route("/User")]
    public async Task<IActionResult> TestFunction([FromBody] User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new JsonResult(user);
    }

    [HttpGet]
    [Route("/User/{id}")]
    public async Task<IActionResult> GetUser([FromRoute] int id)
    {
        List<User>users = _context.Users.Where(u => u.IdUser == id).ToList();
        User user = users[0];
        return new JsonResult(user);
    }

    private async Task Echo(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        _logger.Log(LogLevel.Information, "Message received from Client");

        while (!result.CloseStatus.HasValue)
        {
            var serverMsg = Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
            await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
            _logger.Log(LogLevel.Information, "Message sent to Client");

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            _logger.Log(LogLevel.Information, "Message received from Client");
                
        }
        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        _logger.Log(LogLevel.Information, "WebSocket connection closed");
    }

}