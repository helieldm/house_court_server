using HouseCourt.Context;
using HouseCourt.Entities;
using HouseCourt.Helper;

namespace HouseCourt.Service;

public class HouseStateService
{
    private readonly HouseCourtContext _context;

    public HouseStateService(HouseCourtContext context)
    {
        _context = context;
    }

    public String GetSensorState(String macAddress, String sensor)
    {
        return _context.Sensors.Where(s => s.House.MACAdress == macAddress && s.Name == sensor).FirstOrDefault().State;
    }
    
    public Sensor GetSensor(String macAddress, String sensor)
    {
        return _context.Sensors.Where(s => s.House.MACAdress == macAddress && s.Name == sensor).FirstOrDefault();
    }

    public void UpdateOrCreateSensorState(String macAddress, String sensorName, String newState)
    {
        Sensor sensorObject = GetSensor(macAddress, sensorName);
        
        if (sensorObject != null)
        {
            sensorObject.State = newState;
        }
        else
        {
            _context.Add(new Sensor()
            {
                Name = sensorName,
                State = newState,
                HouseMACAdress = macAddress
            });
        }

        _context.SaveChanges();
    }
}