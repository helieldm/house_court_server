using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HouseCourt.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public House House { get; set; } // primary key of House class
}