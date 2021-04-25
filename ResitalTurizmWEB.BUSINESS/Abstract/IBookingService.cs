using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Abstract
{
    public interface IBookingService
    {
        List<Booking> GetBookingsByOtel(int? otelId);
        
    }
}
