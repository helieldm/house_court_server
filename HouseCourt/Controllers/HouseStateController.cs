using HouseCourt.Helper;
using HouseCourt.Service;
using Microsoft.AspNetCore.Mvc;

namespace HouseCourt.Controllers;

[ApiController]
[Route("{macAddress}/house/state")]
public class HouseStateController : ControllerBase
{
    private readonly ILogger<WebSocketController> _logger;
    private readonly HouseStateService _houseStateService;

    public HouseStateController(ILogger<WebSocketController> logger, HouseStateService houseService)
    {
        _logger = logger;
        _houseStateService = houseService;
    }
    
    [HttpGet("vents")]
    public IActionResult GetVentsState(String macAddress)
    {
        String result = _houseStateService.GetSensorState(macAddress, MessageHelper.Vents);
        
        if (result == null)
            return BadRequest("Couldn't retrieve sensor state");
        
        return Ok(result);
    }
    
    [HttpGet("window")]
    public IActionResult GetWindowState(String macAddress)
    {
        String result = _houseStateService.GetSensorState(macAddress, MessageHelper.Window);
        
        if (result == null)
            return BadRequest("Couldn't retrieve sensor state");
        
        return Ok(result);
    }
    
    [HttpGet("door")]
    public IActionResult GetDoorState(String macAddress)
    { 
        String result = _houseStateService.GetSensorState(macAddress, MessageHelper.Door);
        
        if (result == null)
            return BadRequest("Couldn't retrieve sensor state");
        
        return Ok(result);
    }
    
    [HttpGet("alarm")]
    public IActionResult GetAlarmState(String macAddress)
    {
        String result = _houseStateService.GetSensorState(macAddress, MessageHelper.Alarm);

        if (result == null)
            return BadRequest("Couldn't retrieve sensor state");

        return Ok(result);
    }
}