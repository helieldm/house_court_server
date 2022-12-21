using System.Text;
using HouseCourt.Context;
using HouseCourt.Entities;
using HouseCourt.Service;
using Microsoft.AspNetCore.WebSockets;

namespace HouseCourt.Controllers;

using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class WebSocketController : ControllerBase
{
    private readonly ILogger<WebSocketController> _logger;
    private readonly WebSocketService _webSocketService;
    public WebSocketController(ILogger<WebSocketController> logger, WebSocketService webSocketService)
    {
        _logger = logger;
        _webSocketService = webSocketService;
    }
    
    [HttpGet("/")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await _webSocketService.Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}