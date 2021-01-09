using Microsoft.AspNetCore.Mvc;
using ResitalTurizmWEB.BUSINESS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private ICategoryOtelService _categoryotelService;
        public CategoriesViewComponent(ICategoryOtelService categoryotelService)
        {
            this._categoryotelService = categoryotelService;
        }


        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["categoryotel"]!= null) 
                ViewBag.SelectedCategory = RouteData?.Values["categoryotel"];
            return View(_categoryotelService.GetAll());
        }
    }
}
