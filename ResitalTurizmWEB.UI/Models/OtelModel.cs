using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Models
{
    public class OtelModel
    {
        //Ekledigim (validation gibi) ekstra islemleri entity(veritabanı) icerisinden yapmamak icin bu class'ı ekledim.

        public int OtelID { get; set; }

        [Display(Prompt = "Kategori ID giriniz..")]
        [Required(ErrorMessage = "CategoryID zorunlu bir alandır.")]
        public int CategoryID { get; set; }

        [Display(Prompt ="Otel adı giriniz..")]
        [Required(ErrorMessage ="Otel Adı zorunlu bir alandır.")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Otel ismi 5-30 karakter arası olmalıdır.")]
        public string OtelAdı { get; set; }

        [Display(Prompt = "Otel kategorisi giriniz..")]
        [Required(ErrorMessage = "Otel Kategorisi zorunlu bir alandır.")]
        public string OtelKategorisi { get; set; }

        [Display(Prompt = "Otel adresi giriniz..")]
        [Required(ErrorMessage = "Otel Adresi zorunlu bir alandır.")]
        public string OtelAdres { get; set; }

        [Display(Prompt = "Otel resmi giriniz..")]
        [Required(ErrorMessage = "ImageUrl zorunlu bir alandır.")]
        public string ImageUrl { get; set; }

        public bool IsApproved { get; set; }

        [Display(Prompt = "Otel fiyatı giriniz..")]
        [Required(ErrorMessage = "Fiyat zorunlu bir alandır.")]
        [Range(1,100000,ErrorMessage ="Fİyat için 1-100000 arası değer girmelisiniz.")]
        public double? Fiyat { get; set; }
    }
}
