using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCourt.Entities;

public class House
{
    [Key]
    public string MACAdress { get; set; }
    public string Name { get; set; }
    public virtual List<User>? Users { get; set; } // Users list taking reference MACAdress property of User class (primary key House table)
    public virtual List<Reading>? Readings { get; set; }
    public virtual List<Sensor>? Sensors { get; set; }
}