using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.ENTITY;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ResitalTurizmWEB.ENTITY.Entities;
using System.Data.Entity;

namespace ResitalTurizmWEB.DATA.Concrete.EfCore
{
    public class EfCoreOtelRepository : EfCoreGenericRepository<Otel, ResitalContext>, IOtelRepository
    {
        public int GetCountByCategory(string categoryotel)
        {
            using (var context = new ResitalContext())
            {
                var otels = context.Oteller.Where(i => i.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(categoryotel))
                {
                    otels = otels
                        .Include(i => i.CategoryOtel)
                        .Where(i => i.OtelKategorisi.ToLower() == categoryotel.ToLower());
                }
                return otels.Count();
            }
        }

        public Otel GetOtelDetails(int id)
        {
            using (var context = new ResitalContext())
            {
                return context.Oteller
                    .Where(i => i.OtelID == id)
                    .Include(i => i.CategoryOtel)
                    .FirstOrDefault(); //varsa ilk kaydı getir
            }
        }

        public List<Otel> GetOtelsByCategoryOtel(string name, int page, int pageSize)
        {
            using (var context = new ResitalContext())
            {
                var otels = context.Oteller.Where(i=>i.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    otels = otels
                        .Include(i => i.CategoryOtel)
                        .Where(i => i.OtelKategorisi.ToLower() == name.ToLower());
                }
                return otels.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public List<Otel> GetSearchResult(string searchString,DateTime startDate, DateTime endDate) 
        {
            using (var context = new ResitalContext())
            {
                var otels = context
                    .Oteller
                    .Include(x => x.Bookings)
                    .Where(i=> i.Bookings.Count(x => !(x.EndDate > startDate && x.StartDate < endDate)) < i.Rooms.Count() 
                     &&  i.IsApproved && (i.OtelAdı.ToLower().Contains(searchString)) || (i.OtelAdres.ToLower().Contains(searchString)))
                    .AsQueryable();
                
                return otels.ToList();
            }
        }
    }
}
