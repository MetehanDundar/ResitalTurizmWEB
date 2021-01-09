using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Ucak
    {
        [Key]
        public int UcakID { get; set; }
        public string UcakTipi { get; set; }
        public virtual UcakFirma UcakFirma { get; set; }
    }
}
