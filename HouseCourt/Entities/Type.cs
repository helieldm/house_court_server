using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace HouseCourt.Entities;

public class Type
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public Unit Unit { get; set; } // primary key of House class
}