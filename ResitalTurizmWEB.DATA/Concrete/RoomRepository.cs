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
    public class RoomRepository : IBookingRepository<Room>
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

        public void Remove(int id)
        {
            var room = db.Room.FirstOrDefault(b => b.Id == id);
            db.Room.Remove(room);
            db.SaveChanges();
        }
    }
}
