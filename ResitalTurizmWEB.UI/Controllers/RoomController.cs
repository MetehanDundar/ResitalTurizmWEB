using Microsoft.AspNetCore.Mvc;
using ResitalTurizmWEB.BUSINESS.Abstract;
using System;
using ResitalTurizmWEB.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        private IOtelService _otelService;
        public RoomController(IRoomService roomService, IOtelService otelService)
        {
            this._roomService = roomService;
            this._otelService = otelService;
        }

        

        public IActionResult List(int otelId)
        {
            var RoomListViewModel = new RoomListViewModel()
            {
                Odalar = _roomService.GetRoomsByOtel(otelId)
                
            };
            return View(RoomListViewModel);
        }
    }
}
