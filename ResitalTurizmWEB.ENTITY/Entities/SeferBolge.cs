using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class SeferBolge
    {
        [Key]
        public int UcakSeferID { get; set; }
        public string UCakSeferBolgesi { get; set; }
        public virtual UcakFirma UcakFirma { get; set; }
    }
}
