using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class TransferFirma
    {
        [Key]
        public int TransferFirmaID { get; set; }
        public string TransferFirmaAdi { get; set; }
        public string TransferFirmaAdres { get; set; }
        public virtual List<Transfer> Transferler { get; set; }
        public string BolgeBilgisi { get; set; }
    }
}
