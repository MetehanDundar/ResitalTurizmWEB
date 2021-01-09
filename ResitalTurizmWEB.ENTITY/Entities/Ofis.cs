using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Ofis
    {
        [Key]
        public int OfisID { get; set; }
        public string OfisAdres { get; set; }
        public virtual List<Calisan> Calisanlar { get; set; }
    }
}
