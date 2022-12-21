using HouseCourt.Context;
using HouseCourt.Entities;

namespace HouseCourt.Service;

public class HouseService
{
    private readonly HouseCourtContext _context;

    public HouseService(HouseCourtContext context)
    {
        _context = context;
    }

    public List<House> GetByMacAddress(String macAddress)
    {
        return _context.Houses.Where(h => h.MACAdress == macAddress).ToList();
    }

    public void Register(String macAddress)
    {
        List<House> houses = GetByMacAddress(macAddress);

        if (!houses.Any())
        {
            _context.Houses.Add(new House()
            {
                MACAdress = macAddress,
                Name = "MyHouse"
            });

            _context.SaveChanges();
        }
    }
}