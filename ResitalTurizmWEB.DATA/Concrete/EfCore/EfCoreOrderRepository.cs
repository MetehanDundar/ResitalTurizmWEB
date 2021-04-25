using Microsoft.EntityFrameworkCore;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResitalTurizmWEB.DATA.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order, ResitalContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new ResitalContext())
            {
                var orders = context.Orders
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Booking)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserId == userId);
                }

                return orders.ToList();

            }
        }
    }
}
