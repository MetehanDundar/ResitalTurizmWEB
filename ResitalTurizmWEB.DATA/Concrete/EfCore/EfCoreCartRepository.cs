using Microsoft.EntityFrameworkCore;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResitalTurizmWEB.DATA.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart, ResitalContext>, ICartRepository
    {
        public void ClearCart(int cartId)
        {
            using (var context = new ResitalContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0";
                context.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }

        public void DeleteFromCart(int cartId, int bookingId)
        {
            using (var context = new ResitalContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0 and BookingId=@p1";
                context.Database.ExecuteSqlRaw(cmd,cartId,bookingId);
            }
        }

        public Cart GetByUserId(string userId)
        {
            using (var context = new ResitalContext())
            {
                return context.Carts
                    .Include(i => i.CartItems)
                    .ThenInclude(i => i.Booking)
                    .FirstOrDefault(i=>i.UserId ==userId);
            }
        }

        public override void Update(Cart entity) //EfCoreGenericRepository'den override ettim.
        {
            using (var context = new ResitalContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }

        }
    }
}
