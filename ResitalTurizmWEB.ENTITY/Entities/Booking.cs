using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public partial class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Otel")]
        public int? OtelId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public double Fiyat { get; set; }
        public Room Room { get; set; }
        public Otel Otel { get; set; }
    }
}
