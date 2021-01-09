using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Kisi
    {
        [Key]
        public int KisiID { get; set; }
        public string KisiTipi { get; set; }
        public string KisiAdi { get; set; }
    }
}
