using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class GemiFirma
    {
        [Key]
        public int GemiFirmaID { get; set; }
        public string GemiFirmaAdi { get; set; }
        public string GemiFirmaAdres { get; set; }
        public virtual List<Gemi> Gemiler { get; set; }
        

    }
}
