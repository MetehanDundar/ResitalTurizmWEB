using Microsoft.EntityFrameworkCore;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete.EfCore;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace ResitalTurizmWEB.DATA.Concrete
{
    public class BookingRepository : IBookingRepository<Booking>
    {
        private readonly ResitalContext db;

        public BookingRepository()
        {
            db = new ResitalContext();
        }
        public void Add(Booking entity)
        {
            var newBooking = db.Booking.Add(entity);
            db.SaveChanges();
        }

        public void Edit(Booking entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Booking Get(int id)
        {
            return db.Booking.Include(b => b.Room).FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return db.Booking.Include(b => b.Room).ToList();
        }

        public void Remove(int id)
        {
            var booking = db.Booking.FirstOrDefault(b => b.Id == id);
            db.Booking.Remove(booking);
            db.SaveChanges();
        }

        public List<Booking> GetBookingsByOtel(int? otelId)
        {
            using (var context = new ResitalContext())
            {
                var bookings = context.Booking.Where(i => i.IsActive).AsQueryable();
                if (otelId != null)
                {
                    bookings = bookings
                        .Include(i => i.Otel)
                        .Where(i => i.OtelId == otelId);
                }
                return bookings.ToList();
            }
        }
    }
}
