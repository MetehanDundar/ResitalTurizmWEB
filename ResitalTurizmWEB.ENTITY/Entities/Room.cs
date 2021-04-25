using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Otel")]
        public int OtelId { get; set; }
        //public string OtelAd { get; set; }
        //public DateTime GirisTarih { get; set; }
        //public DateTime CikisTarih { get; set; }
        public double Fiyat { get; set; }
        //public bool Doluluk { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Booking> Bookings { get; set; }
        public Otel Otel { get; set; }
    }
}
