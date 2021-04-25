//using ResitalTurizmWEB.DATA.Migrations;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Models
{
    public interface IBookingViewModel
    {
        IEnumerable<Booking> Bookings { get; set; }
        //List<Booking> GetBookingsByOtel(int? otelId);
        List<DateTime> FullyOccupiedDates { get; }
        int YearToDisplay { get; set; }
        string GetMonthName(int month);
        bool DateIsOccupied(int year, int month, int day);
    }
}
