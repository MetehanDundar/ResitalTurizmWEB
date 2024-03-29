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
    [Migration("20210128191243_Order")]
    partial class Order
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OtelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OtelId");

                    b.HasIndex("RoomId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
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

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
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

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OtelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OtelId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Tur", b =>
                {
                    b.Property<int>("TurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.CartItem", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Gemi", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.GemiFirma", "GemiFirma")
                        .WithMany("Gemiler")
                        .HasForeignKey("GemiFirmaID");

                    b.Navigation("GemiFirma");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.OrderItem", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Order");
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

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Tur", b =>
                {
                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.TurArac", "TurArac")
                        .WithMany("Turlar")
                        .HasForeignKey("TurAracID");

                    b.HasOne("ResitalTurizmWEB.ENTITY.Entities.TurSirket", "TurSirket")
                        .WithMany("Turlar")
                        .HasForeignKey("TurSirketID");

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

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.CategoryOtel", b =>
                {
                    b.Navigation("Oteller");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.GemiFirma", b =>
                {
                    b.Navigation("Gemiler");
                });

            modelBuilder.Entity("ResitalTurizmWEB.ENTITY.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
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
#pragma warning restore 612, 618
        }
    }
}
