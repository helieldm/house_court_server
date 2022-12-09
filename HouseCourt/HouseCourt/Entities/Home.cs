using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace HouseCourt.Entities;

public class Home
{
    [Key]
    public string MACAdress { get; set; }
    public int ValueReading { get; set; }
    public DateTime DateReading { get; set; }
    public List<User> Users { get; set; }
}