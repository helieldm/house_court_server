using System.Text;
using HouseCourt.Context;
using HouseCourt.Entities;
namespace HouseCourt.Controllers;

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
    [Route("/User/Create")]
    public async Task<IActionResult> CreateUser([FromBody] JsonUser body)
    {
        User user = new User
        {
            IdUser = body.IdUser,
            UserName = body.UserName,
            UserPassword = body.UserPassword,
            MACAdress = body.MacAdress
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new JsonResult(user);
    }

    [HttpPost]
    [Route("/User/Update")]
    public async Task<IActionResult> UpdateUser([FromBody] JsonUser jsonUser)
    {
        User user = _context.Users.Where(u => u.IdUser == jsonUser.IdUser).FirstOrDefault();
        if(user != null)
        {
            user.UserName = jsonUser.UserName;
            user.UserPassword = jsonUser.UserPassword;
            user.MACAdress = jsonUser.MacAdress;
            _context.Users.AddOrUpdate(user);
            await _context.SaveChangesAsync();
            return Ok("Vos données on été mis à jours");
        }
        else
        {
            return NotFound($"Erreur: Impossible de trouver l'utilisateur {jsonUser.UserName}");
        }
    }

    [HttpPost]
    [Route("/User/Delete")]
    public async Task<IActionResult> DeleteUser([FromBody] JsonUser body)
    {
        User user = _context.Users.Where(u => u.IdUser == body.IdUser).FirstOrDefault();
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("Données supprimée");
        }
        else
        {
            return NotFound("Erreur: Impossible de trouver l'utilisateur cible");
        }
    }

    [HttpGet]
    [Route("/User/{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        //List<User>users = _context.Users.Where(u => u.IdUser == id).ToList();
        //User user = users[0];
        User user = _context.Users.Where(u => u.IdUser == id).FirstOrDefault();
        if(user == null)
        {
            return NotFound("Utilisateur non trouvé");
        }
        else
        {
            return new JsonResult(user);
        }
    }

    [HttpGet]
    [Route("/User/all")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<User> users = _context.Users.ToList();
        return new JsonResult(users);
    }

    [HttpPost]
    [Route("/House/Create")]
    public async Task<IActionResult> CreateHouse([FromBody] JsonHouse body)
    {
        House house = new House
        {
            MACAdress = body.MAC,
            HouseName = body.HouseName,
            Users = null
        };
        _context.Houses.Add(house);
        await _context.SaveChangesAsync();
        return Ok("Donnée enregistrée");
    }

    [HttpGet]
    [Route("/House/{id}")]
    public async Task<IActionResult> GetHouseById([FromRoute]string id)
    {
        //List<User>users = _context.Users.Where(u => u.IdUser == id).ToList();
        //User user = users[0];
        House? house = _context.Houses.Where(u => u.MACAdress == id).FirstOrDefault();
        if (house == null)
        {
            return NotFound("Maison non trouvée");
        }
        else
        {
            return new JsonResult(house);
        }
    }

    [HttpGet]
    [Route("/House/All")]
    public async Task<IActionResult> GetAllHouses()
    {
        List<House> houses = _context.Houses.ToList();
        return new JsonResult(houses);
    }

    [HttpPost]
    [Route("/Reading/Create")]
    public async Task<IActionResult> CreateReading([FromBody] JsonReading body)
    {
            Reading reading = new Reading
            {
                IdReading = body.IdReading,
                ValueReading = body.ValueReading,
                MACAdress = body.MACAdress,
                DateReading = DateTime.Now
            };
            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();
            return Ok($"La donnée avec l'id: {reading.IdReading} à été enregistre pour la maison {body.MACAdress}");
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

    public class JsonUser
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string MacAdress { get; set; }
    }

    public class JsonHouse
    {
        public string MAC { get; set; }
        public string HouseName { get; set; }
    }

    public class JsonReading
    {
        public int IdReading { get; set; }
        public int ValueReading { get; set; }
        public string MACAdress { get; set; }
    }

}