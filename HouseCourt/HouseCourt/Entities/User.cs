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
    public int IdUser { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string UserPhone { get; set; }
    public string MACAdress { get; set; } // primary key of House class
}