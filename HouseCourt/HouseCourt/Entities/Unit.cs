using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace HouseCourt.Entities;

public class Unit
{
    [Key]
    public int IdTypeReading { get; set; }
    public string NameTypeReading { get; set; }
}