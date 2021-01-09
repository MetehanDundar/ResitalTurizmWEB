using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class CategoryOtel
    {
        [Key]
        public int CategoryID { get; set; }
        public string OtelKategorisi { get; set; }
        public List<Otel> Oteller { get; set; }
    }
}
