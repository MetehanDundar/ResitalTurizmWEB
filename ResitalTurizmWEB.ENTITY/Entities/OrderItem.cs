using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
