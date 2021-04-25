using ResitalTurizmWEB.DATA.Concrete;
//using ResitalTurizmWEB.DATA.Migrations;
using System;
using ResitalTurizmWEB.ENTITY.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResitalTurizmWEB.BUSINESS.Concrete;

namespace ResitalTurizmWEB.UI.Models
{
    public class BookingViewModel : IBookingViewModel
    {
        private BookingRepository bookingRepository = new BookingRepository();
        private BookingManager bookingManager = new BookingManager();
        private int yearToDisplay;

        public IEnumerable<Booking> Bookings
        {
            get
            {
                return bookingRepository.GetAll();
            }
            set { }
        }


        //public List<Booking> GetBookingsByOtel(int? otelId)
        //{
        //    return bookingRepository.GetBookingsByOtel(otelId);
        //}



        public int YearToDisplay
        {
            get
            {
                int minBookingYear = MinBookingDate.Year;
                int maxBookingYear = MaxBookingDate.Year;
                if (yearToDisplay < minBookingYear)
                    return minBookingYear;
                else if (yearToDisplay > maxBookingYear)
                    return maxBookingYear;
                else
                    return yearToDisplay;
            }
            set { yearToDisplay = value; }
        }

        public string GetMonthName(int month)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
        }

        public bool DateIsOccupied(int year, int month, int day)
        {
            bool occupied = false;
            if (day <= DateTime.DaysInMonth(year, month))
            {
                DateTime dt = new DateTime(year, month, day);
                DateTime occupiedDate = FullyOccupiedDates.FirstOrDefault(d => d == dt);
                if (occupiedDate > DateTime.MinValue)
                    occupied = true;
            }
            return occupied;
        }

        

        public List<DateTime> FullyOccupiedDates
        {
            get
            {
                return bookingManager.GetFullyOccupiedDates(MinBookingDate, MaxBookingDate);
            }
        }

        private DateTime MinBookingDate
        {
            get
            {
                var bookingStartDates = Bookings.Select(b => b.StartDate);
                return bookingStartDates.Any() ? bookingStartDates.Min() : DateTime.MinValue;
            }
        }

        private DateTime MaxBookingDate
        {
            get
            {
                var bookingEndDates = Bookings.Select(b => b.EndDate);
                return bookingEndDates.Any() ? bookingEndDates.Max() : DateTime.MaxValue;
            }
        }

        //IEnumerable<DATA.Migrations.Booking> IBookingViewModel.bookings => throw new NotImplementedException();
    }
}
