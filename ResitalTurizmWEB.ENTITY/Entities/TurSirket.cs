using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class TurSirket
    {
        [Key]
        public int TurSirketID { get; set; }
        public string TurSirketAdi { get; set; }
        public string TurSirketAdres { get; set; }
        public string BolgeBilgisi { get; set; }
        public virtual List<Tur> Turlar { get; set; }
        public virtual List<TurArac> TurAraclar { get; set; }
        public virtual List<Rehber> Rehberler { get; set; }
    }
}
