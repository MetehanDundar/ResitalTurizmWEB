using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Otel
    {
        [Key]
        public int OtelID { get; set; }
        [ForeignKey("CategoryOtel")]
        public int CategoryID { get; set; }
        public string OtelAdı { get; set; }
        public string OtelKategorisi { get; set; }
        public string OtelAdres { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public double Fiyat { get; set; }
        public CategoryOtel CategoryOtel { get; set; }
        public List<Room> Rooms { get; set; }
        
        public List<Booking> Bookings { get; set; }

        
    }
}
