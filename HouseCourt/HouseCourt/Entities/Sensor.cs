using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCourt.Entities;

public class Sensor
{
    [Key]
    public int SensorId { get; set; }
    public string SensorName { get; set; }
    public string SensorAverageConsuption { get; set; }
    public string MACAdress { get; set; } // primary key of House class

    public virtual List<Consuptions>? Consuptions { get; set; }

}