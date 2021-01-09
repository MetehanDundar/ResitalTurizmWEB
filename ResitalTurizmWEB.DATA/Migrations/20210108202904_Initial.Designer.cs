﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResitalTurizmWEB.DATA.Concrete.EfCore;

namespace ResitalTurizmWEB.DATA.Migrations
{
    [DbContext(typeof(ResitalContext))]
    [Migration("20210108202904_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("RehberRehberDil", b =>
                {
                    b.Property<int>("RehberDillerDilID")
                        .HasColumnType("int");

                    b.Property<int>("RehberlerTurRehberD")
                        .HasColumnType("int");

                    b.HasKey("RehberDillerDilID", "RehberlerTurRehberD");

                    b.HasIndex("RehberlerTurRehberD");

                    b.ToTable("RehberRehberDil");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OtelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OtelId");

                    b.HasIndex("RoomId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Calisan", b =>
                {
                    b.Property<int>("CalisanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CalisanAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CalisanCariKod")
                        .HasColumnType("int");

                    b.Property<string>("CalisanGorev")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalisanSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfisID")
                        .HasColumnType("int");

                    b.HasKey("CalisanID");

                    b.HasIndex("OfisID");

                    b.ToTable("Calisanlar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.CategoryOtel", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("OtelKategorisi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("OtelKategorileri");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Dosya", b =>
                {
                    b.Property<int>("DosyaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("DosyaAlisFiyat")
                        .HasColumnType("real");

                    b.Property<float>("DosyaSatisFiyat")
                        .HasColumnType("real");

                    b.Property<string>("DosyaTipi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DosyaID");

                    b.ToTable("Dosyalar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Gemi", b =>
                {
                    b.Property<int>("GemiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("GemiAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GemiFirmaID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.HasKey("GemiID");

                    b.HasIndex("GemiFirmaID");

                    b.ToTable("Gemiler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.GemiFirma", b =>
                {
                    b.Property<int>("GemiFirmaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GemiFirmaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GemiFirmaAdres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GemiFirmaID");

                    b.ToTable("GemiFirmalar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Kisi", b =>
                {
                    b.Property<int>("KisiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("KisiAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KisiTipi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KisiID");

                    b.ToTable("Kisiler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Konaklama", b =>
                {
                    b.Property<int>("KonaklamaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DosyaID")
                        .HasColumnType("int");

                    b.Property<int?>("GemiID")
                        .HasColumnType("int");

                    b.Property<int?>("KisiID")
                        .HasColumnType("int");

                    b.Property<double>("KonaklamaFiyat")
                        .HasColumnType("float");

                    b.Property<string>("KonaklamaTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OtelID")
                        .HasColumnType("int");

                    b.HasKey("KonaklamaID");

                    b.HasIndex("DosyaID");

                    b.HasIndex("GemiID");

                    b.HasIndex("KisiID");

                    b.HasIndex("OtelID");

                    b.ToTable("Konaklamalar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Ofis", b =>
                {
                    b.Property<int>("OfisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("OfisAdres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfisID");

                    b.ToTable("Ofisler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Otel", b =>
                {
                    b.Property<int>("OtelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("OtelAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtelAdı")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtelKategorisi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OtelID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Oteller");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Rehber", b =>
                {
                    b.Property<int>("TurRehberD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TurRehberAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurRehberAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurSirketID")
                        .HasColumnType("int");

                    b.HasKey("TurRehberD");

                    b.HasIndex("TurSirketID");

                    b.ToTable("Rehberler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.RehberDil", b =>
                {
                    b.Property<int>("DilID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DilAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DilID");

                    b.ToTable("RehberDiller");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OtelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OtelId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Satis", b =>
                {
                    b.Property<int>("SatisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DosyaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("KonaklamaTarihBaslangic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KonaklamaTarihBitis")
                        .HasColumnType("datetime2");

                    b.Property<string>("PnrNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SaticiCalisanCalisanID")
                        .HasColumnType("int");

                    b.Property<string>("SatisCariKod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SatisID");

                    b.HasIndex("DosyaID");

                    b.HasIndex("SaticiCalisanCalisanID");

                    b.ToTable("Satislar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.SeferBolge", b =>
                {
                    b.Property<int>("UcakSeferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UCakSeferBolgesi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UcakFirmaID")
                        .HasColumnType("int");

                    b.HasKey("UcakSeferID");

                    b.HasIndex("UcakFirmaID");

                    b.ToTable("SeferBolgeler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Transfer", b =>
                {
                    b.Property<int>("TransferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DosyaID")
                        .HasColumnType("int");

                    b.Property<int?>("TransferFirmaID")
                        .HasColumnType("int");

                    b.Property<int>("TransferFiyat")
                        .HasColumnType("int");

                    b.Property<string>("TransferGüzergah")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransferID");

                    b.HasIndex("DosyaID");

                    b.HasIndex("TransferFirmaID");

                    b.ToTable("Transferler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.TransferFirma", b =>
                {
                    b.Property<int>("TransferFirmaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BolgeBilgisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferFirmaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferFirmaAdres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransferFirmaID");

                    b.ToTable("TransferFirmalar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Tur", b =>
                {
                    b.Property<int>("TurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DosyaID")
                        .HasColumnType("int");

                    b.Property<string>("TurAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurAracID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TurBaslangic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TurBitis")
                        .HasColumnType("datetime2");

                    b.Property<int>("TurFiyat")
                        .HasColumnType("int");

                    b.Property<int?>("TurSirketID")
                        .HasColumnType("int");

                    b.HasKey("TurID");

                    b.HasIndex("DosyaID");

                    b.HasIndex("TurAracID");

                    b.HasIndex("TurSirketID");

                    b.ToTable("Turlar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.TurArac", b =>
                {
                    b.Property<int>("TurAracID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TurAracTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurSirketID")
                        .HasColumnType("int");

                    b.HasKey("TurAracID");

                    b.HasIndex("TurSirketID");

                    b.ToTable("TurAraclar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.TurSirket", b =>
                {
                    b.Property<int>("TurSirketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BolgeBilgisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurSirketAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurSirketAdres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurSirketID");

                    b.ToTable("TurSirketler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Ucak", b =>
                {
                    b.Property<int>("UcakID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("UcakFirmaID")
                        .HasColumnType("int");

                    b.Property<string>("UcakTipi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UcakID");

                    b.HasIndex("UcakFirmaID");

                    b.ToTable("Ucaklar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.UcakFirma", b =>
                {
                    b.Property<int>("UcakFirmaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UcakFirmaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UcakFirmaAdres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UcakFirmaID");

                    b.ToTable("UcakFirmalar");
                });

            modelBuilder.Entity("RehberRehberDil", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.RehberDil", null)
                        .WithMany()
                        .HasForeignKey("RehberDillerDilID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Rehber", null)
                        .WithMany()
                        .HasForeignKey("RehberlerTurRehberD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Booking", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Otel", "Otel")
                        .WithMany("Bookings")
                        .HasForeignKey("OtelId");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Otel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Calisan", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Ofis", "Ofis")
                        .WithMany("Calisanlar")
                        .HasForeignKey("OfisID");

                    b.Navigation("Ofis");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Gemi", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.GemiFirma", "GemiFirma")
                        .WithMany("Gemiler")
                        .HasForeignKey("GemiFirmaID");

                    b.Navigation("GemiFirma");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Konaklama", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Dosya", "Dosya")
                        .WithMany("Konaklamalar")
                        .HasForeignKey("DosyaID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Gemi", "Gemi")
                        .WithMany()
                        .HasForeignKey("GemiID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("KisiID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Otel", "Otel")
                        .WithMany()
                        .HasForeignKey("OtelID");

                    b.Navigation("Dosya");

                    b.Navigation("Gemi");

                    b.Navigation("Kisi");

                    b.Navigation("Otel");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Otel", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.CategoryOtel", "CategoryOtel")
                        .WithMany("Oteller")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryOtel");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Rehber", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.TurSirket", "TurSirket")
                        .WithMany("Rehberler")
                        .HasForeignKey("TurSirketID");

                    b.Navigation("TurSirket");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Room", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Otel", "Otel")
                        .WithMany("Rooms")
                        .HasForeignKey("OtelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Otel");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Satis", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Dosya", "Dosya")
                        .WithMany()
                        .HasForeignKey("DosyaID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Calisan", "SaticiCalisan")
                        .WithMany("Satislar")
                        .HasForeignKey("SaticiCalisanCalisanID");

                    b.Navigation("Dosya");

                    b.Navigation("SaticiCalisan");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.SeferBolge", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.UcakFirma", "UcakFirma")
                        .WithMany("UcakSeferBolgeler")
                        .HasForeignKey("UcakFirmaID");

                    b.Navigation("UcakFirma");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Transfer", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Dosya", "Dosya")
                        .WithMany("Transferler")
                        .HasForeignKey("DosyaID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.TransferFirma", "TransferFirma")
                        .WithMany("Transferler")
                        .HasForeignKey("TransferFirmaID");

                    b.Navigation("Dosya");

                    b.Navigation("TransferFirma");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Tur", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Dosya", "Dosya")
                        .WithMany("Turlar")
                        .HasForeignKey("DosyaID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.TurArac", "TurArac")
                        .WithMany("Turlar")
                        .HasForeignKey("TurAracID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.TurSirket", "TurSirket")
                        .WithMany("Turlar")
                        .HasForeignKey("TurSirketID");

                    b.Navigation("Dosya");

                    b.Navigation("TurArac");

                    b.Navigation("TurSirket");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.TurArac", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.TurSirket", "TurSirket")
                        .WithMany("TurAraclar")
                        .HasForeignKey("TurSirketID");

                    b.Navigation("TurSirket");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Ucak", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.UcakFirma", "UcakFirma")
                        .WithMany("Ucaklar")
                        .HasForeignKey("UcakFirmaID");

                    b.Navigation("UcakFirma");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Calisan", b =>
                {
                    b.Navigation("Satislar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.CategoryOtel", b =>
                {
                    b.Navigation("Oteller");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Dosya", b =>
                {
                    b.Navigation("Konaklamalar");

                    b.Navigation("Transferler");

                    b.Navigation("Turlar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.GemiFirma", b =>
                {
                    b.Navigation("Gemiler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Ofis", b =>
                {
                    b.Navigation("Calisanlar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Otel", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Room", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.TransferFirma", b =>
                {
                    b.Navigation("Transferler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.TurArac", b =>
                {
                    b.Navigation("Turlar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.TurSirket", b =>
                {
                    b.Navigation("Rehberler");

                    b.Navigation("TurAraclar");

                    b.Navigation("Turlar");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.UcakFirma", b =>
                {
                    b.Navigation("Ucaklar");

                    b.Navigation("UcakSeferBolgeler");
                });
#pragma warning restore 612, 618
        }
    }
}
