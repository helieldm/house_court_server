using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace HouseCourt.Entities;

public class TypeReading
{
    [Key]
    public int IdTypeReading { get; set; }
    public string NameTypeReading { get; set; }
    public string MACAdress { get; set; } // primary key of House class
}