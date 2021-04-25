using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete;
using ResitalTurizmWEB.ENTITY.Entities;
using ResitalTurizmWEB.MODELS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingRepository<Booking> bookingRepository = new BookingRepository();
        private readonly IBookingRepository<Room> roomRepository = new RoomRepository();

        public ServiceCallResult CreateBooking(Booking booking)
        {
            //int roomId = FindAvailableRoom(booking.StartDate, booking.EndDate);

            //if (roomId >= 0)
            //{
            //    booking.RoomId = roomId;
            //    booking.IsActive = true;
            //    bookingRepository.Add(booking);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            var callResult = new ServiceCallResult() { Success = false };

            if (booking.StartDate < DateTime.Today)
            {
                callResult.ErrorMessages.Add("Geçmiş tarihli rezervasyon yapılamaz!");
                return callResult;
            }

            if (booking.StartDate > booking.EndDate)
            {
                callResult.ErrorMessages.Add("Hatalı Tarih Seçimi");
                return callResult;
            }

            var activeBooking = bookingRepository.GetAll().Where(x => x.RoomId == booking.RoomId && (x.EndDate > booking.StartDate && x.StartDate < booking.EndDate));
            if (activeBooking.Count() > 0)
            {
                callResult.ErrorMessages.Add("Bu tarih aralığında odamız doludur!");
                return callResult;
            }

            var fark = booking.EndDate - booking.StartDate;
            var totalDays = fark.TotalDays;
            var room = roomRepository.Get(booking.RoomId);
            booking.Fiyat = room.Fiyat * totalDays;

            callResult.Success = true;
            callResult.SuccessMessages.Add("Rezervasyonunuz oluşturuldu. 'Sepete Ekle' butonuna tıklayınız.");
            booking.IsActive = true;
            bookingRepository.Add(booking);
            return callResult;
        }

        public int FindAvailableRoom(DateTime startDate, DateTime endDate)
        {
            if (startDate <= DateTime.Today || startDate > endDate)
                throw new ArgumentException("Hatalı Seçim..");

            var activeBookings = bookingRepository.GetAll().Where(b => b.IsActive);
            foreach (var room in roomRepository.GetAll())
            {
                var activeBookingsForCurrentRoom = activeBookings.Where(b => b.RoomId == room.Id);
                if (activeBookingsForCurrentRoom.All(b => startDate < b.StartDate &&
                    endDate < b.StartDate || startDate > b.EndDate && endDate > b.EndDate))
                {
                    return room.Id;
                }
            }
            return -1;
        }

        public List<DateTime> GetFullyOccupiedDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException("Başlangıç tarihi Bitiş tarihinden ileri bir tarh olamaz.");

            List<DateTime> fullyOccupiedDates = new List<DateTime>();
            int noOfRooms = roomRepository.GetAll().Count();
            var bookings = bookingRepository.GetAll();

            if (bookings.Any())
            {
                for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
                {
                    var noOfBookings = from b in bookings
                                       where b.IsActive && d >= b.StartDate && d <= b.EndDate
                                       select b;
                    if (noOfBookings.Count() >= noOfRooms)
                        fullyOccupiedDates.Add(d);
                }
            }
            return fullyOccupiedDates;
        }

        public List<Booking> GetBookingsByOtel(int? otelId)
        {
            return bookingRepository.GetBookingsByOtel(otelId);
        }

    }
}
