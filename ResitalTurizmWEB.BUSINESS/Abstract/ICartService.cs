using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId); //kartı başlat
        Cart GetCartByUserId(string userId);
        void AddToCart(string userId, int bookingId, int quantity);
        void DeleteFromCart(string userId, int bookingId);
        void ClearCart(int cartId);
    }
}
