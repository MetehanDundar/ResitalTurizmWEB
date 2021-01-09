using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    //TODO: Nullable kısımlar olacak.
    public class Dosya
    {
        [Key]
        public int DosyaID { get; set; }
        public string DosyaTipi { get; set; }
        public virtual  List<Tur> Turlar { get; set; }
        public virtual List<Transfer> Transferler { get; set; }
        public float DosyaAlisFiyat { get; set; }
        public float DosyaSatisFiyat { get; set; }
        public virtual List<Konaklama> Konaklamalar { get; set; }
    }
}
