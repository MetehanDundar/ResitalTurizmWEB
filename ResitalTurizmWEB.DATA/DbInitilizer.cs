using ResitalTurizmWEB.DATA.Concrete.EfCore;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResitalTurizmWEB.DATA
{
    public static class DbInitilizer
    {
        public static void Initialize(ResitalContext context)
        {
            
            context.Database.EnsureDeleted();

            
            context.Database.EnsureCreated();

            // Look for any bookings.
            if (context.Booking.Any())
            {
                return;   // DB has been seeded
            }


            List<Room> rooms = new List<Room>
            {
                new Room { Description="A" },
                new Room { Description="B" },
                new Room { Description="C" }
            };

            DateTime date = DateTime.Today.AddDays(4);
            List<Booking> bookings = new List<Booking>
            {
                new Booking { StartDate=date, EndDate=date.AddDays(14), IsActive=true,  RoomId=1 },
                new Booking { StartDate=date, EndDate=date.AddDays(14), IsActive=true,  RoomId=2 },
                new Booking { StartDate=date, EndDate=date.AddDays(14), IsActive=true,  RoomId=3 }
            };


            context.Room.AddRange(rooms);
            context.SaveChanges();
            context.Booking.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
