using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Entities.Demirbas> Demirbaslar { get; set; }
        public DbSet<Entities.Kullanici> Kullanicilar { get; set; }
        public DbSet<Entities.Marka> Markalar { get; set; }
        public DbSet<Entities.Kullanan> Kullananlar { get; set; }
        public DbSet<Entities.Rol> Roller { get; set; }
        public DbSet<Entities.Zimmet> Zimmetler { get; set; }

        public DbSet<Entities.Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-L2S0U5A; database=OtoServisSatisNetCore; user id=sa; password=1234; TrustServerCertificate=true;");

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

            base.OnConfiguring(optionsBuilder);
        }

       
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            // Fluent API
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Rol>().HasData(new Rol 
            { 
                Id = 1, 
                Adi = "Admin" 
            });

            modelBuilder.Entity<Kullanici>().HasData(new Kullanici 
            {
                Id = 2,
                Adi = "Feride",
                AktifMi= true,
                EklenmeTarihi = DateTime.Now,
                Email = "feride@gmail.com",
                KullaniciAdi = "feridegndz",
                Sifre="123456",
                RolId = 1,
                Soyadi = "Gündüz",
                Telefon = "1234567890"

            });

            


            base.OnModelCreating(modelBuilder);

        }

    }
}
