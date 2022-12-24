using HouseCourt.Dto.Public;
using HouseCourt.Entities;

namespace HouseCourt.Factory;

public static class ReadingFactory
{
    public static ReadingDto ConvertToPublicDto(Reading reading)
    {
        return new ReadingDto()
        {
            Value = reading.Value,
            Unit = reading.Type.Unit.Name
        };
    }
}