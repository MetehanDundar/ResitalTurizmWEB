using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Tur
    {
        [Key]
        public int TurID { get; set; }
        public string TurAdi { get; set; }
        public int TurFiyat { get; set; }
        public DateTime TurBaslangic { get; set; }
        public DateTime TurBitis { get; set; }
        public virtual TurSirket TurSirket { get; set; }
        public virtual TurArac TurArac { get; set; }

    }
}
