using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResitalTurizmWEB.BUSINESS.Concrete;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete;
using ResitalTurizmWEB.ENTITY.Entities;
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

        // GET: Booking
        public IActionResult Index(int? id)
        {
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

        // GET: Booking/Create
        public IActionResult Create()
        {
            //ViewData["CustomerId"] = new SelectList(customerRepository.GetAll(), "Id", "Name", booking.UserId);
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StartDate,EndDate,UserId,RoomId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                bool created = bookingManager.CreateBooking(booking);

                if (created)
                {
                    return RedirectToAction(nameof(Index));
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
        public IActionResult Edit(int id, [Bind("Id,StartDate,EndDate,IsActive,UserId,RoomId")] Booking booking)
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
