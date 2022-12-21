using System.Globalization;
using HouseCourt.Context;
using HouseCourt.Entities;

namespace HouseCourt.Service;

public class ReadingService
{
    private readonly HouseCourtContext _context;
    private readonly HouseService _houseService;

    public ReadingService(HouseCourtContext context, HouseService houseService)
    {
        _context = context;
        _houseService = houseService;
    }

    public void InsertNewReading(String houseMacAddress, String humidity, String temperature)
    {
        List<House> houses = _houseService.GetByMacAddress(houseMacAddress);

        if (houses.Any() && !humidity.Equals("nan") && !temperature.Equals("nan") )
        {
            float hum = float.Parse(humidity, CultureInfo.InvariantCulture);
            float temp = float.Parse(temperature, CultureInfo.InvariantCulture);

            Entities.Type tempType = _context.Type.Where(t => t.Name == "Temperature").FirstOrDefault();
            Entities.Type humType = _context.Type.Where(t => t.Name == "Humidity").FirstOrDefault();
                
            _context.Readings.Add(new Reading()
            {
                Date = DateTime.Now.ToUniversalTime(),
                House = houses.First(),
                Type = tempType,
                Value = temp
            });
            
            _context.Readings.Add(new Reading()
            {
                Date = DateTime.Now.ToUniversalTime(),
                House = houses.First(),
                Type = humType,
                Value = hum
            });

            _context.SaveChanges();
        }
    }
}