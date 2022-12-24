using HouseCourt.Dto.Input;
using HouseCourt.Dto.Public;
using HouseCourt.Entities;
using HouseCourt.Service;
using Microsoft.AspNetCore.Mvc;

namespace HouseCourt.Controllers;

[ApiController]
[Route("/reading")]
public class ReadingController : ControllerBase
{
    private readonly ReadingService _readingService;

    public ReadingController(ReadingService readingService)
    {
        _readingService = readingService;
    }
    
    [HttpGet("{houseMacAddress}/temperature/last")]
    public IActionResult GetLastTemperature(String houseMacAddress)
    {
        ReadingDto result = _readingService.GetLastReadingByType(houseMacAddress, "Temperature");
        if (result != null)
            return Ok(result);
        else
            return BadRequest();

    }
    
    [HttpGet("{houseMacAddress}/humidity/last")]
    public IActionResult GetLastHumidity(String houseMacAddress)
    {
        ReadingDto result = _readingService.GetLastReadingByType(houseMacAddress, "Humidity");
        if (result != null)
            return Ok(result);
        else
            return BadRequest();
    }
}