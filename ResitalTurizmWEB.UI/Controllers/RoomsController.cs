﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoomsController : Controller
    {
        private IBookingRepository<Room> repository = new RoomRepository();

        // GET: Rooms
        public IActionResult Index()
        {
            return View(repository.GetAll().ToList());
        }

        // GET: Rooms/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = repository.Get(id.Value);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,OtelId,OtelAd,Fiyat,Description,ImageUrl")] Room room)
        {
            if (ModelState.IsValid)
            {
                repository.Add(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = repository.Get(id.Value);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,OtelId,OtelAd,Fiyat,Description,ImageUrl")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Edit(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (repository.Get(room.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = repository.Get(id.Value);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id > 0)
                repository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
