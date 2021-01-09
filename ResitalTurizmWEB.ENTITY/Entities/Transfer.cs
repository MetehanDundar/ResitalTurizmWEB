using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResitalTurizmWEB.ENTITY.Entities
{
    public class Transfer
    {
        [Key]
        public int TransferID { get; set; }
        public string TransferGüzergah { get; set; }
        public int TransferFiyat { get; set; }
        public virtual TransferFirma TransferFirma { get; set; }
        public virtual Dosya Dosya { get; set; }
    }
}
