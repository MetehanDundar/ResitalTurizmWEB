using Microsoft.EntityFrameworkCore;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete.EfCore;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResitalTurizmWEB.DATA.Concrete
{
    public class RoomRepository : IRoomsRepository
    {


        private readonly ResitalContext db;

        public RoomRepository()
        {
            db = new ResitalContext();
        }

        public void Add(Room entity)
        {
            var Room = db.Room.Add(entity);
            db.SaveChanges();
        }

        public void Edit(Room entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Room Get(int id)
        {
            return db.Room.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Room> GetAll()
        {
            return db.Room.ToList();
        }

        public List<Booking> GetBookingsByOtel(int? otelId)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetRoomsByOtel(int otelId)
        {
            using (var context = new ResitalContext())
            {
                var rooms = context.Room.AsQueryable();
                //if (!string.IsNullOrEmpty(name))
                //{
                //    rooms = rooms
                //        .Include(i => i.Otel)
                //        .Where(i => i.OtelAd.ToLower() == name.ToLower());

                //}
                DateTime now = DateTime.Now.AddDays(-1);
                rooms = rooms.Include(x => x.Otel).Include(x => x.Bookings).Where(x => x.OtelId == otelId && !x.Bookings
                .Any(i => i.StartDate < now && i.EndDate > now)); //oda boş ise
                return rooms.ToList();
            }
        }

        public void Remove(int id)
        {
            var room = db.Room.FirstOrDefault(b => b.Id == id);
            db.Room.Remove(room);
            db.SaveChanges();
        }
    }
}
