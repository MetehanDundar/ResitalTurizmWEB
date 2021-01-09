using Microsoft.AspNetCore.Mvc;
using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using ResitalTurizmWEB.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Controllers
{
    public class OtelController : Controller
    {
        private IOtelService _otelService;
        public OtelController(IOtelService otelService)
        {
            this._otelService = otelService;
        }
        // localhost/otels/yurtdışı?page=1
        public IActionResult List(string categoryotel, int page=1)
        {
            const int pageSize = 3; //sabit tanımladım, her sayfada kaç ürün gösterilsin
            var otelViewModel = new OtelListViewModel()
            {
                PageInfo = new PageInfo()
                {
                  ToTalItems = _otelService.GetCountByCategory(categoryotel),
                  CurrentPage = page,
                  ItemsPerPage = pageSize,
                  CurrentCategoryOtel = categoryotel
                },
                Oteller = _otelService.GetOtelsByCategoryOtel(categoryotel, page, pageSize)
            };
            return View(otelViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Otel otel = _otelService.GetOtelDetails((int)id);

            if (otel==null)
            {
                return NotFound();
            }
            return View(new OtelDetailModel
            {
                Otel = otel,
                CategoryOtel = otel.CategoryOtel //kategori bilgisini kategori tablosundan çekemedim otel tablosundan çektim
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Otel o) 
        {
            //OtelRepository.AddOtel(o);  TO DO
            return View();
        }

        public IActionResult Search(string q, DateTime startDate, DateTime endDate)
        {
            var otelViewModel = new OtelListViewModel()
            {
                Oteller = _otelService.GetSearchResult(q,startDate,endDate)
            };
            return View(otelViewModel);
        }
    }
}
