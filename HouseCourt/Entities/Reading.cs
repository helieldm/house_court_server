using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace HouseCourt.Entities
{
    public class Reading
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public House House { get; set; } // primary key of House class

    }
}