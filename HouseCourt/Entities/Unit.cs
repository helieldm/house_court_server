using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace HouseCourt.Entities;

public class Unit
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}