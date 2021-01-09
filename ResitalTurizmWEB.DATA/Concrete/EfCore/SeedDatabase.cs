using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResitalTurizmWEB.DATA.Concrete.EfCore
{
    public static class SeedDatabase
    {

        //    public static void Seed()
        //    {
        //        var context = new ResitalContext();

        //        if (context.Database.GetPendingMigrations().Count() == 0) //bekleyen migration yoksa
        //        {
        //            if (context.OtelKategorileri.Count() == 0)
        //            {
        //                context.OtelKategorileri.AddRange(OtelKategorileri);
        //            }
        //            if (context.Oteller.Count() == 0)
        //            {
        //                context.Oteller.AddRange(Oteller);
        //            }
        //        }
        //        context.SaveChanges();
        //    }

        //    private static CategoryOtel[] OtelKategorileri = {
        //            new CategoryOtel() {OtelKategorisi="Yurtdışı"},
        //            new CategoryOtel() {OtelKategorisi="Yurtiçi"}
        //        };

        //    private static Otel[] Oteller = {
        //            new Otel() {OtelAdı="Kuştur Otel",CategoryID=2,OtelKategorisi="Yurtiçi", Fiyat=300, ImageUrl="kustur.jpg", 
        //                OtelAdres="Kuşadası/Aydın", IsApproved=true},
        //            new Otel() {OtelAdı="Letonia Otel",CategoryID=2,OtelKategorisi="Yurtiçi", Fiyat=500,ImageUrl="letonia.jpg",
        //                OtelAdres="Fethiye/Muğla", IsApproved=true},
        //            new Otel() {OtelAdı="The Grove Resort",CategoryID=1,OtelKategorisi="Yurtdışı", Fiyat=1200, ImageUrl="thegroveresort.jpg",OtelAdres="Orlando/ABD",IsApproved=true} // TODO: kategori düzenle burada
        //        };



        public static void Seed(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                ResitalContext context = serviceScope.ServiceProvider.GetService<ResitalContext>();


                context.Database.Migrate();

                if (!context.OtelKategorileri.Any())
                {
                    context.OtelKategorileri.AddRange(
                        new CategoryOtel() { OtelKategorisi = "Yurtdışı" },
                new CategoryOtel() { OtelKategorisi = "Yurtiçi" }
                        );
                }

                if (!context.Oteller.Any())
                {
                    context.Oteller.AddRange(
                          new Otel()
                          {
                              OtelAdı = "Kuştur Otel",
                              Fiyat = 300,
                              ImageUrl = "kustur.jpg",
                              OtelAdres = "Kuşadası/Aydın",
                              CategoryID = 2,
                              OtelKategorisi = "Yurtiçi",
                              IsApproved = true
                          },
                new Otel()
                {
                    OtelAdı = "Letonia Otel",
                    Fiyat = 500,
                    ImageUrl = "letonia.jpg",
                    OtelAdres = "Fethiye/Muğla",
                    CategoryID = 2,
                    OtelKategorisi = "Yurtiçi",
                    IsApproved = true
                },
                new Otel()
                {
                    OtelAdı = "The Grove Resort",
                    Fiyat = 1200,
                    ImageUrl = "thegroveresort.jpg",
                    OtelAdres = "Orlando/ABD",
                    CategoryID = 1,
                    OtelKategorisi = "Yurtdışı",
                    IsApproved = true
                } // TODO: kategori düzenle burada
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
