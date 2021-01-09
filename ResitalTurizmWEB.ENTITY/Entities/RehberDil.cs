using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class RehberDil
    {
        [Key]
        public int DilID { get; set; }
        public string DilAdi { get; set; }
        public virtual List<Rehber> Rehberler { get; set; }
    }
}
