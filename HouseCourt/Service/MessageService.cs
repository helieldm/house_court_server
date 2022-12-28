using HouseCourt.Entities;
using HouseCourt.Helper;

namespace HouseCourt.Service;

public class MessageService
{
    private HouseService _houseService;
    private ReadingService _readingService;
    private HouseStateService _houseStateService;

    public MessageService(HouseService houseService, ReadingService readingService, HouseStateService houseStateService)
    {
        _houseService = houseService;
        _readingService = readingService;
        _houseStateService = houseStateService;
    }

    public String GetMacAddressFromMessage(String message)
    {
        message = message.Trim();

        if (message.StartsWith(MessageHelper.Begin) && message.EndsWith(MessageHelper.End))
        {
            List<String> messageParts = message.Split(";").ToList();
            return messageParts.ElementAt(1);
        }

        return "ERROR";
    }

    public void Decode(String message)
    {
        message = message.Trim();
        
        if (message.StartsWith(MessageHelper.Begin) && message.Contains(MessageHelper.End))
        {
            List<String> messageParts = message.Split(";").ToList();
            String macAddress = messageParts.ElementAt(1);
            
            switch (messageParts.ElementAt(2))
            {
                case MessageHelper.Register:
                    _houseService.Register(macAddress);
                    break;
                case MessageHelper.DhtData:
                    _readingService.InsertNewReading(macAddress, messageParts.ElementAt(3), messageParts.ElementAt(4));
                    break;
                case MessageHelper.State:
                    _houseStateService.UpdateOrCreateSensorState(macAddress,messageParts.ElementAt(3), messageParts.ElementAt(4));
                    break;
            }
        }
    }
}