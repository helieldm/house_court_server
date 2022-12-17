using System.Text;
using HouseCourt.Context;
using HouseCourt.Entities;
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
    private HouseCourtContext _houseCourtContext;
    public WebSocketController(ILogger<WebSocketController> logger)
    {
        _logger = logger;
        _houseCourtContext = new HouseCourtContext();
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
    // // </snippet>
    // #region Users
    //
    // /// <summary>
    // /// Method qui permet d'ajouter de un nouvel utilisateur
    // /// </summary>
    // /// <param name="body">les informations de l'utilsateur à créer</param>
    // /// <returns>une réponse 200 avec les informations de l'utilisateur créer</returns>
    // [HttpPost]
    // [Route("/User")]
    // public async Task<IActionResult> CreateUser([FromBody] JsonUser body)
    // {
    //     User user = new User
    //     {
    //         Id = body.IdUser,
    //         Name = body.UserName,
    //         Password = body.UserPassword,
    //         MACAdress = body.MacAdress
    //     };
    //     _context.Users.Add(user);
    //     await _context.SaveChangesAsync();
    //     return new JsonResult(user);
    // }
    //
    // /// <summary>
    // /// Method qui permet de modifier les informations d'un utilisateur
    // /// </summary>
    // /// <param name="jsonUser">les données de l'utilisateur pour modification</param>
    // /// <returns> une réponse status code 200 si ça c'est bien passer sinon 400 not found</returns>
    // [HttpPut]
    // [Route("/User")]
    // public async Task<IActionResult> UpdateUser([FromBody] JsonUser jsonUser)
    // {
    //     User user = _context.Users.Where(u => u.IdUser == jsonUser.IdUser).FirstOrDefault();
    //     if(user != null)
    //     {
    //         user.UserName = jsonUser.UserName;
    //         user.UserPassword = jsonUser.UserPassword;
    //         user.MACAdress = jsonUser.MacAdress;
    //         _context.Users.AddOrUpdate(user);
    //         await _context.SaveChangesAsync();
    //         return Ok("Vos données on été mis à jours");
    //     }
    //     else
    //     {
    //         return NotFound($"Erreur: Impossible de trouver l'utilisateur {jsonUser.UserName}");
    //     }
    // }
    //
    // /// <summary>
    // /// Method qui permet de supprimer un utilisateur en fonction des informations donner dans le body de la requête
    // /// </summary>
    // /// <param name="body">un json contenu dans le body de la requête</param>
    // /// <returns>une réponse avec un status code 200 si la donnée à bien été supprimer sinon une réponse avec un status code 400 not found</returns>
    // [HttpDelete]
    // [Route("/User")]
    // public async Task<IActionResult> DeleteUser([FromBody] JsonUser body)
    // {
    //     User user = _context.Users.Where(u => u.IdUser == body.IdUser).FirstOrDefault();
    //     if (user != null)
    //     {
    //         _context.Users.Remove(user);
    //         await _context.SaveChangesAsync();
    //         return Ok("Données supprimée");
    //     }
    //     else
    //     {
    //         return NotFound("Erreur: Impossible de trouver l'utilisateur cible");
    //     }
    // }
    //
    // /// <summary>
    // /// Method qui permet de récupérer un utlisateur en fonction de son id
    // /// </summary>
    // /// <param name="id">l'id de l'utilisateur qui sera passer dans le chemin de la route</param>
    // /// <returns>un json avec les informations de l'utilsateur cible</returns>
    // [HttpGet]
    // [Route("/User/{id}")]
    // public async Task<IActionResult> GetUserById([FromRoute] int id)
    // {
    //     //List<User>users = _context.Users.Where(u => u.IdUser == id).ToList();
    //     //User user = users[0];
    //     User user = _context.Users.Where(u => u.IdUser == id).FirstOrDefault();
    //     if(user == null)
    //     {
    //         return NotFound("Utilisateur non trouvé");
    //     }
    //     else
    //     {
    //         return new JsonResult(user);
    //     }
    // }
    //
    // /// <summary>
    // /// Method qui récupère l'ensemble des utilisateur
    // /// </summary>
    // /// <returns>Un json</returns>
    // [HttpGet]
    // [Route("/Users")]
    // public async Task<IActionResult> GetAllUsers()
    // {
    //     List<User> users = await _context.Users.ToListAsync();
    //     return new JsonResult(users);
    // }
    // #endregion
    //
    // #region houses
    //
    // /// <summary>
    // /// Method qui permet de créer une maison
    // /// </summary>
    // /// <param name="body">les informations de la maison à créer</param>
    // /// <returns>reponse status code 200 avec les informations de la maison créer</returns>
    // [HttpPost]
    // [Route("/House")]
    // public async Task<IActionResult> CreateHouse([FromBody] JsonHouse body)
    // {
    //     House house = new House
    //     {
    //         MACAdress = body.MAC,
    //         HouseName = body.HouseName,
    //         Users = null
    //     };
    //     _context.Houses.Add(house);
    //     await _context.SaveChangesAsync();
    //     return Ok("Donnée enregistrée");
    // }
    //
    // /// <summary>
    // /// Method qui permet de récupérer les données d'une maison en fonction de l'id de la maison
    // /// </summary>
    // /// <param name="id">l'id de la maison donner dans le chemin de la route</param>
    // /// <returns>les informations de la maison en json</returns>
    // [HttpGet]
    // [Route("/House/{id}")]
    // public async Task<IActionResult> GetHouseById([FromRoute]string id)
    // {
    //     //List<User>users = _context.Users.Where(u => u.IdUser == id).ToList();
    //     //User user = users[0];
    //     House? house = _context.Houses.Where(u => u.MACAdress == id).FirstOrDefault();
    //     if (house == null)
    //     {
    //         return NotFound("Maison non trouvée");
    //     }
    //     else
    //     {
    //         return new JsonResult(house);
    //     }
    // }
    //
    // /// <summary>
    // /// Method qui permet de récupérer toutes les maisons avec leurs informations
    // /// </summary>
    // /// <returns>l'ensemble des informations de chaques maison sous la forme d'un json</returns>
    // [HttpGet]
    // [Route("/Houses")]
    // public async Task<IActionResult> GetAllHouses()
    // {
    //     List<House> houses = await _context.Houses.ToListAsync();
    //     return new JsonResult(houses);
    // }
    // #endregion
    //
    // #region Reading
    //
    // /// <summary>
    // /// Method qui permet de créer une lecture (Reading)
    // /// </summary>
    // /// <param name="body">les informations de la lecture à créer</param>
    // /// <returns>un status code 200 une fois la consommation créer</returns>
    // [HttpPost]
    // [Route("/Reading")]
    // public async Task<IActionResult> CreateReading([FromBody] JsonReading body)
    // {
    //         Reading reading = new Reading
    //         {
    //             IdReading = body.IdReading,
    //             ValueReading = body.ValueReading,
    //             MACAdress = body.MACAdress,
    //             DateReading = DateTime.Now
    //         };
    //         _context.Readings.Add(reading);
    //         await _context.SaveChangesAsync();
    //         return Ok($"La donnée avec l'id: {reading.IdReading} à été enregistre pour la maison {body.MACAdress}");
    // }
    // #endregion
    //
    // #region consuptions
    //
    // /// <summary>
    // /// Method qui permet de créer une consommation
    // /// </summary>
    // /// <param name="body">les informations de la consommations à créer</param>
    // /// <returns> un status code 200 une fois la consommation créer</returns>
    // [HttpPost]
    // [Route("/Consuption")]
    // public async Task<IActionResult> CreateConsuption([FromBody] JsonConsuption body)
    // {
    //     var consuption = new Consumption
    //     {
    //         ConsuptionsId = body.ConsuptionsId,
    //         ConsuptionsDate = body.ConsuptionsDate,
    //         ConsuptionsDuration = body.ConsuptionsDuration,
    //         SensorId = body.SensorId
    //     };
    //     _context.Consuptions.Add(consuption);
    //     await _context.SaveChangesAsync();
    //     return Ok("Les informations de la consommation on été enregistrer");
    // }
    // #endregion
    //
    // #region sensors
    //
    // /// <summary>
    // /// Method qui permet de créer un capteur (sensor) pour une maison
    // /// </summary>
    // /// <param name="body">les informations du capteur (sensor) à créer</param>
    // /// <returns>les informations du capteur (sensor) sour la forme d'un json avec une réponse status code 200</returns>
    // [HttpPost]
    // [Route("/Sensor")]
    // public async Task<IActionResult> CreateSensor([FromBody] JsonSensor body)
    // {
    //     var sensor = new Sensor
    //     {
    //         SensorId = body.SensorId,
    //         SensorName = body.SensorName,
    //         SensorAverageConsuption = 0.ToString(),
    //         MACAdress = body.MACAdress
    //     };
    //     _context.Sensors.Add(sensor);
    //     await _context.SaveChangesAsync();
    //     return Ok($"Le capteur à été enregister dans la base pour la maison {sensor.MACAdress}");
    // }
    //
    //
    // /// <summary>
    // /// Method qui permet de récupére un capteur (sensor) par id pour une maison
    // /// </summary>
    // /// <param name="id">l'id cible du capteur</param>
    // /// <returns>les informations du capteur (sensor) sour la forme d'un json avec une réponse status code 200</returns>
    // [HttpGet]
    // [Route("/Sensor/{id}")]
    // public async Task<IActionResult> GetSensorById([FromRoute] int id)
    // {
    //     Sensor sensor = await _context.Sensors.Where(s => s.SensorId == id).FirstOrDefaultAsync();
    //     if(sensor != null)
    //     {
    //         return new JsonResult(sensor);
    //     }
    //     else
    //     {
    //         return NotFound("Aucun capteur n'a été trouver");
    //     }
    // }
    // #endregion

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

    #region Class utilitaire
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

    public class JsonSensor
    {
        public int SensorId { get; set; }
        public string SensorName { get; set; }
        public string SensorAverageConsuption { get; set; }
        public string MACAdress { get; set; }
    }

    public class JsonConsuption
    {
        public int ConsuptionsId { get; set; }
        public DateTime ConsuptionsDate { get; set; }
        public float ConsuptionsDuration { get; set; }
        public int SensorId { get; set; }
    }

    #endregion
}