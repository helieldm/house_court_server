using System;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCourt.Entities;

public class User
{
    [Key]
    public int IdUser { get; set; }
    public string UserName { get; set; }
    public string PasswordUser { get; set; }
    public Home? Home { get; set; }
}