using Microsoft.AspNetCore.Mvc;
using ResitalTurizmWEB.BUSINESS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.ViewComponents
{
    public class OtelsViewComponent : ViewComponent
    {
        private IOtelService _otelService;
        public OtelsViewComponent(IOtelService otelService)
        {
            this._otelService = otelService;
        }


        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["otel"] != null)
                ViewBag.SelectedOtel = RouteData?.Values["otel"];
            return View(_otelService.GetAll());
        }
    }
}
