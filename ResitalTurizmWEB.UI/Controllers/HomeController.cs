using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Controllers
{
    public class HomeController : Controller
    {
        private IOtelService _otelService;
        public HomeController(IOtelService otelService)
        {
            this._otelService = otelService;
        }

        public IActionResult Index()
        {
            var otelViewModel = new OtelListViewModel()
            {
                Oteller = _otelService.GetAll()
            };
            return View(otelViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Gemi()
        {
            return View();
        }
    }
}
