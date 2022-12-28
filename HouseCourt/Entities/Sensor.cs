using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCourt.Entities;

public class Sensor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AverageConsumption { get; set; }
    public string State { get; set; }
    public House House { get; set; }
    public String HouseMACAdress { get; set; }
    public virtual List<Consumption>? Consumptions { get; set; }

}