using HouseCourt.Dto.Input;
using HouseCourt.Entities;
using HouseCourt.Service;
using Microsoft.AspNetCore.Mvc;

namespace HouseCourt.Controllers;

[ApiController]
[Route("/house")]
public class HouseController : ControllerBase
{
    private readonly ILogger<WebSocketController> _logger;
    private readonly HouseService _houseService;

    public HouseController(ILogger<WebSocketController> logger, HouseService houseService)
    {
        _houseService = houseService;
        _logger = logger;
    }

    [HttpPost("vents")]
    public IActionResult ToggleVents([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Toggle the vents");
        
        _houseService.ToggleVents(taskDto);
        
        return Ok();
    }
    
    [HttpPost("window")]
    public IActionResult ToggleWindow([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Toggle the window");
        
        _houseService.ToggleWindow(taskDto);
        
        return Ok();
    }
    
    [HttpPost("door")]
    public IActionResult ToggleDoor([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Toggle the door");
        
        _houseService.ToggleDoor(taskDto);
        
        return Ok();
    }
    
    [HttpPost("alarm")]
    public IActionResult ToggleAlarm([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Toggle alarm");
        
        _houseService.ToggleAlarm(taskDto);
        
        return Ok();
    }
    
    [HttpPut("led")]
    public IActionResult UpdateLed([FromBody] LedDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Led");
        
        _houseService.ToggleLed(taskDto);
        
        return Ok();
    }
}