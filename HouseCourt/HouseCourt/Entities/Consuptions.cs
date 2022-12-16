using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCourt.Entities;

public class Consuptions
{
    [Key]
    public int ConsuptionsId { get; set; }
    public DateTime ConsuptionsDate { get; set; }
    public float ConsuptionsDuration { get; set; }
    public int SensorId { get;set; }
}