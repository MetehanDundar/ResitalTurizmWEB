using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Calisan
    {
        [Key]
        public int CalisanID { get; set; }
        public string CalisanAd { get; set; }
        public string CalisanSoyad { get; set; }
        public string CalisanAdres { get; set; }
        public int? CalisanCariKod { get; set; }
        public string CalisanGorev { get; set; }
        public virtual Ofis Ofis { get; set; }
        public virtual List<Satis> Satislar { get; set; }

    }
}
