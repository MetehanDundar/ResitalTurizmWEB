using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.BUSINESS.Concrete;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete;
using ResitalTurizmWEB.ENTITY.Entities;
using ResitalTurizmWEB.MODELS.Common;
using ResitalTurizmWEB.UI.Identity;
using ResitalTurizmWEB.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepository<Booking> bookingRepository = new BookingRepository();
        private IBookingRepository<Room> roomRepository = new RoomRepository();
        private BookingManager bookingManager = new BookingManager();
        private BookingViewModel bookingViewModel = new BookingViewModel();
        private IBookingService _bookingService;
        private UserManager<User> _userManager;
        public BookingController(IBookingService bookingService, UserManager<User> userManager)
        {
            this._bookingService = bookingService;
            _userManager = userManager;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index(int? id, int? otelId)
        {
            var bookingViewModel = new BookingViewModel()
            {
                Bookings = _bookingService.GetBookingsByOtel(otelId)
            };
            TempData["bookingId"] = otelId;
            bookingViewModel.YearToDisplay = (id == null) ? DateTime.Today.Year : id.Value;
            return View(bookingViewModel);
        }

        // GET: Booking/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = bookingRepository.Get(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [Authorize]
        public IActionResult Create(int roomId)
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = DateTime.Today.AddDays(1);
            //var room = _bookingService.GetRoom(roomId);
            var room = roomRepository.Get(roomId);
            var model = new Booking()
            {
                RoomId = roomId,
                EndDate = tomorrow,
                StartDate = today,
                OtelId = room.OtelId,
                UserId = _userManager.GetUserId(User),
        };
            
            //ViewData["CustomerId"] = new SelectList(customerRepository.GetAll(), "Id", "Name", booking.UserId);

            return View(model);
        }

        [HttpPost]
        public IActionResult GetRoomPrice(int roomId, DateTime startDate, DateTime endDate)
        {
            var fark = endDate - startDate;
            var totalDays = fark.TotalDays;
            var room = roomRepository.Get(roomId);
            var result = room.Fiyat * totalDays;
            

            return PartialView("~/Views/Shared/_roomPrice.cshtml", result);
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StartDate,EndDate,UserId,RoomId,OtelId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                ServiceCallResult created = bookingManager.CreateBooking(booking);

                if (created.Success)
                {
                    TempData["SuccessNotification"] = created.SuccessMessages;
                    //return RedirectToAction(nameof(Index));
                    return View(booking);
                }
                else
                {
                    TempData["ErrorNotification"] = created.ErrorMessages;
                    return View(booking);
                }
            }

            //ViewData["CustomerId"] = new SelectList(customerRepository.GetAll(),"Id", "Name", booking.UserId);
            ViewBag.Status = "Rezervasyon oluşturulamadı, mevcut oda bulunmamakta.";
            return View(booking);
        }

        // GET: Booking/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = bookingRepository.Get(id.Value);
            if (booking == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(customerRepository.GetAll(), "Id", "Name", booking.UserId);
            ViewData["RoomId"] = new SelectList(roomRepository.GetAll(), "Id", "Description", booking.RoomId);
            return View(booking);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,StartDate,EndDate,IsActive,UserId,RoomId,OtelId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bookingRepository.Edit(booking);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (bookingRepository.Get(booking.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("~/booking/index");
                
            }
            //ViewData["CustomerId"] = new SelectList(customerRepository.GetAll(), "Id", "Name", booking.UserId);
            ViewData["RoomId"] = new SelectList(roomRepository.GetAll(), "Id", "Description", booking.RoomId);
            return View(booking);
        }

        // GET: Booking/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = bookingRepository.Get(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bookingRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
