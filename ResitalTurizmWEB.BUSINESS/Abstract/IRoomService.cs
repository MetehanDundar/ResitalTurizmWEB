using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Abstract
{
    public interface IRoomService
    {
        List<Room> GetRoomsByOtel(int otelId);
    }
}
