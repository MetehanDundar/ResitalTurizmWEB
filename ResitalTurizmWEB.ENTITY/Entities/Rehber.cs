using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Rehber
    {
        [Key]
        public int TurRehberD { get; set; }
        public string TurRehberAdi { get; set; }
        public string TurRehberAdres { get; set; }
        public virtual TurSirket TurSirket { get; set; }
        public virtual List<RehberDil> RehberDiller { get; set; }
    }
}
