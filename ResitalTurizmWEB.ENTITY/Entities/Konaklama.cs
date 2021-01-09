using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Konaklama
    {
        //TODO: Nullable kısımlar eklenecek
        [Key]
        public int KonaklamaID { get; set; }
        public string KonaklamaTipi { get; set; }
        public double KonaklamaFiyat { get; set; }
        public virtual Dosya Dosya { get; set; }
        public virtual Kisi Kisi { get; set; }
        public virtual Otel Otel { get; set; }
        public virtual Gemi Gemi { get; set; }
    }
}
