using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Models
{
    //otel detayında hem otel hem de kategori bilgisini alabilmek icin bu sekilde bir model olusturdum.
    public class OtelDetailModel
    {
        public Otel Otel { get; set; }
        public CategoryOtel CategoryOtel { get; set; }
    }
}
