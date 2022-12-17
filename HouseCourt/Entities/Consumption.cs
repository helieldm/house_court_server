using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCourt.Entities;

public class Consumption
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public float Duration { get; set; }
    public Sensor Sensor { get;set; }
}