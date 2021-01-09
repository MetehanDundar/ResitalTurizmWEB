using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class UcakFirma
    {
        [Key]
        public int UcakFirmaID { get; set; }
        public string UcakFirmaAdi { get; set; }
        public string UcakFirmaAdres { get; set; }
        public virtual List<SeferBolge> UcakSeferBolgeler { get; set; }
        public virtual List<Ucak> Ucaklar { get; set; }
    }
}
