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

    // Route register qui check l'adresse MAC de la maison avant de l'enregistrer -> WS

    [HttpPost("vents")]
    public IActionResult ToggleVents([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Open the door");
        
        _houseService.ToggleVents(taskDto);
        
        return Ok();
    }
    
    [HttpPost("window")]
    public IActionResult ToggleWindow([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Open the door");
        
        _houseService.ToggleWindow(taskDto);
        
        return Ok();
    }
    
    [HttpPost("door")]
    public IActionResult ToggleDoor([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Open the door");
        
        _houseService.ToggleDoor(taskDto);
        
        return Ok();
    }
    
    [HttpPost("alarm")]
    public IActionResult ToggleAlarm([FromBody] ToggleTaskDto taskDto)
    {
        _logger.Log(LogLevel.Information, "Open the door");
        
        _houseService.ToggleAlarm(taskDto);
        
        return Ok();
    }
}