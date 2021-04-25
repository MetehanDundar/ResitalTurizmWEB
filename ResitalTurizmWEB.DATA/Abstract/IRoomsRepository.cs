using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.DATA.Abstract
{
    public interface IRoomsRepository : IBookingRepository<Room>
    {
        List<Room> GetRoomsByOtel(int otelId);
    }
}
