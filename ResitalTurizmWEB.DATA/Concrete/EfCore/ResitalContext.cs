using Microsoft.EntityFrameworkCore;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace ResitalTurizmWEB.DATA.Concrete.EfCore
{
    public class ResitalContext : DbContext
    {
        public DbSet<Gemi> Gemiler { get; set; }
        public DbSet<GemiFirma> GemiFirmalar { get; set; }
        public DbSet<Otel> Oteller { get; set; }
        public DbSet<Rehber> Rehberler { get; set; }
        public DbSet<Tur> Turlar { get; set; }
        public DbSet<TurArac> TurAraclar { get; set; }
        public DbSet<TurSirket> TurSirketler { get; set; }
        public DbSet<CategoryOtel> OtelKategorileri { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }



        //protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    //silme
        //    base.OnModelCreating(modelBuilder);
        //}


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.; database=ResitalDb; uid=sa; pwd=123; MultipleActiveResultSets=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public ResitalContext()
        {

        }

        // <> kısmı eklendi
        public ResitalContext(DbContextOptions<ResitalContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    //silme
        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=ResitalDb; uid=sa; pwd=123;");
            base.OnConfiguring(optionsBuilder); // Bu bilgilerle base'e göndermek lazım
        }
    }
}
