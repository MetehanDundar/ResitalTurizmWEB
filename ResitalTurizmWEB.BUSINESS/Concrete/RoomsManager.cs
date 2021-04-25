using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Concrete
{
    public class RoomsManager : IRoomService
    {
        private IRoomsRepository _roomsRepository;
        public RoomsManager(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public List<Room> GetRoomsByOtel(int otelId)
        {
            return _roomsRepository.GetRoomsByOtel(otelId);
        }
    }
}
