using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class TurArac
    {
        [Key]
        public int TurAracID { get; set; }
        public string TurAracTipi { get; set; }
        public virtual TurSirket TurSirket { get; set; }
        public virtual List<Tur> Turlar { get; set; }
    }
}
