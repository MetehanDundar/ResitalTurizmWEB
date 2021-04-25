using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public Booking Booking { get; set; }
        public Cart Cart { get; set; }
    }
}
