using HouseCourt.Context;
using HouseCourt.Dto.Input;
using HouseCourt.Entities;
using HouseCourt.Helper;

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

    public void ToggleVents(ToggleTaskDto taskDto)
    {
        if (taskDto.Action.Equals(MessageHelper.On) || taskDto.Action.Equals(MessageHelper.Off))
        {
            _context.Tasks.Add(new Entities.Task()
            {
                HouseMACAdress = taskDto.HouseMacAddress,
                Message = MessageHelper.Begin +
                          MessageHelper.Separator +
                          MessageHelper.Vents +
                          MessageHelper.Separator +
                          taskDto.Action +
                          MessageHelper.Separator +
                          MessageHelper.End
            });
        }

        _context.SaveChanges();
    }
    
    public void ToggleWindow(ToggleTaskDto taskDto)
    {
        if (taskDto.Action.Equals(MessageHelper.Open) || taskDto.Action.Equals(MessageHelper.Close))
        {
            _context.Tasks.Add(new Entities.Task()
            {
                HouseMACAdress = taskDto.HouseMacAddress,
                Message = MessageHelper.Begin +
                          MessageHelper.Separator +
                          MessageHelper.Window +
                          MessageHelper.Separator +
                          taskDto.Action +
                          MessageHelper.Separator +
                          MessageHelper.End
            });
        }

        _context.SaveChanges();
    }
    
    public void ToggleDoor(ToggleTaskDto taskDto)
    {
        if (taskDto.Action.Equals(MessageHelper.Open) || taskDto.Action.Equals(MessageHelper.Close))
        {
            _context.Tasks.Add(new Entities.Task()
            {
                HouseMACAdress = taskDto.HouseMacAddress,
                Message = MessageHelper.Begin +
                          MessageHelper.Separator +
                          MessageHelper.Door +
                          MessageHelper.Separator +
                          taskDto.Action +
                          MessageHelper.Separator +
                          MessageHelper.End
            });
        }

        _context.SaveChanges();
    }
    
    public void ToggleAlarm(ToggleTaskDto taskDto)
    {
        if (taskDto.Action.Equals(MessageHelper.On) || taskDto.Action.Equals(MessageHelper.Off))
        {
            _context.Tasks.Add(new Entities.Task()
            {
                HouseMACAdress = taskDto.HouseMacAddress,
                Message = MessageHelper.Begin +
                          MessageHelper.Separator +
                          MessageHelper.Alarm +
                          MessageHelper.Separator +
                          taskDto.Action +
                          MessageHelper.Separator +
                          MessageHelper.End
            });
        }

        _context.SaveChanges();
    }

    public void ToggleLed(LedDto ledDto)
    {
        _context.Tasks.Add(new Entities.Task()
        {
            HouseMACAdress = ledDto.HouseMacAddress,
            Message = MessageHelper.Begin +
                      MessageHelper.Separator +
                      MessageHelper.Led +
                      MessageHelper.Separator +
                      ledDto.Red +
                      MessageHelper.Separator +
                      ledDto.Green +
                      MessageHelper.Separator +
                      ledDto.Blue +
                      MessageHelper.Separator +
                      ledDto.Intensity +
                      MessageHelper.Separator +
                      MessageHelper.End
        });
        
        _context.SaveChanges();
    }
}