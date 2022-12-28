using System.Drawing;

namespace HouseCourt.Dto.Input;

public class LedDto
{
    public String HouseMacAddress { get; set; }
    public int Number { get; set; }
    public int Intensity { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}