using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace HouseCourt.Entities
{
    public class Reading
    {
        [Key]
        public int IdReading { get; set; }
        public int ValueReading { get; set; }
        public DateTime DateReading { get; set; }
        public string MACAdress { get; set; }

    }
}