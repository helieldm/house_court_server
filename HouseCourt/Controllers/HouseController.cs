using Microsoft.AspNetCore.Mvc;

namespace HouseCourt.Controllers;

[ApiController]
[Route("/house")]
public class HouseController : ControllerBase
{
    private readonly ILogger<WebSocketController> _logger;

    public HouseController(ILogger<WebSocketController> logger)
    {
        _logger = logger;
    }

    // Route register qui check l'adresse MAC de la maison avant de l'enregistrer -> WS

    [HttpPut("door")]
    public IActionResult OpenTheDoor()
    {
        _logger.Log(LogLevel.Information, "Open the door");
        
        return Ok();
    }
    
}