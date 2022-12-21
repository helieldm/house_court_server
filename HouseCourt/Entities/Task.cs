using System.ComponentModel.DataAnnotations;

namespace HouseCourt.Entities;

public class Task
{
    [Key]
    public int Id { get; set; }
    public String HouseMACAdress { get; set; }
    public House House { get; set; }
    public String Message { get; set; }
    public Boolean Sent { get; set; }
}