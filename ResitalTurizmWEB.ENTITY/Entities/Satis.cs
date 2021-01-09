using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Satis
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime KonaklamaTarihBaslangic { get; set; }
        public DateTime KonaklamaTarihBitis { get; set; }
        public string PnrNo { get; set; }
        public string SatisCariKod { get; set; }
        public virtual Calisan SaticiCalisan { get; set; }
        public virtual Dosya Dosya { get; set; }
    }
}
