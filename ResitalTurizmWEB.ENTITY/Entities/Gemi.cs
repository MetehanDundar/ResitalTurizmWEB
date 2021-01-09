using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Gemi
    {
        [Key]
        public int GemiID { get; set; }
        public string GemiAdi { get; set; }
        public string ImageUrl { get; set; }
        public double Fiyat { get; set; }
        //varsayılan false gelir
        public bool IsApproved { get; set; }
        public virtual GemiFirma GemiFirma { get; set; }
    }
}
