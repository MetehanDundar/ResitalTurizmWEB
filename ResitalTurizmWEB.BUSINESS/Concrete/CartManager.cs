using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddToCart(string userId, int bookingId, int quantity)
        {
            var cart = GetCartByUserId(userId);

            if (cart!=null)
            {
                var index = cart.CartItems.FindIndex(i => i.BookingId == bookingId);
                if (index<0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        BookingId = bookingId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
                _cartRepository.Update(cart);
            }
        }

        public void ClearCart(int cartId)
        {
            _cartRepository.ClearCart(cartId);
        }

        public void DeleteFromCart(string userId, int bookingId)
        {
            var cart = GetCartByUserId(userId);
            if (cart!=null)
            {
                _cartRepository.DeleteFromCart(cart.Id, bookingId);
            }
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);
        }

        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new Cart() { UserId = userId }); //userId bilgisini repository aracılıgıyla veritabanına ekledim
        }
    }
}
