using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Models
{
    public class PageInfo
    {
        public int ToTalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategoryOtel { get; set; }
        // 10/3=3.3 => 4
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)ToTalItems / ItemsPerPage);
        }
    }

    public class OtelListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Otel> Oteller { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
