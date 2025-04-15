﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OtoServisSatis.Data;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OtoServisSatis.Entities.Demirbas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FaturaNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FaturaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<string>("Notlar")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Resim1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resim2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resim3")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SeriNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrunTipi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ZimmetliMi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.HasIndex("MarkaId");

                    b.ToTable("Demirbaslar");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Kullanan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Adres")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DemirbasId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DemirbasId1")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notlar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TcNo")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Telefon")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("DemirbasId1");

                    b.ToTable("Kullananlar");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KullaniciAdi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Adi = "Feride",
                            AktifMi = true,
                            EklenmeTarihi = new DateTime(2025, 4, 14, 10, 4, 43, 955, DateTimeKind.Local).AddTicks(4967),
                            Email = "feride@gmail.com",
                            KullaniciAdi = "feridegndz",
                            RolId = 1,
                            Sifre = "123456",
                            Soyadi = "Gündüz",
                            Telefon = "1234567890",
                            UserGuid = new Guid("94bf8281-e710-47ef-9e3a-7ef4a4e34a3b")
                        });
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Marka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Markalar");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roller");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adi = "Admin"
                        });
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Baslik")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Link")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resim")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Zimmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DemirbasId")
                        .HasColumnType("int");

                    b.Property<int?>("KullananId")
                        .HasColumnType("int");

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ZimmetTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DemirbasId");

                    b.HasIndex("KullananId");

                    b.ToTable("Zimmetler");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Demirbas", b =>
                {
                    b.HasOne("OtoServisSatis.Entities.Kategori", "Kategori")
                        .WithMany()
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OtoServisSatis.Entities.Marka", "Marka")
                        .WithMany()
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Kullanan", b =>
                {
                    b.HasOne("OtoServisSatis.Entities.Demirbas", "Demirbas")
                        .WithMany()
                        .HasForeignKey("DemirbasId1");

                    b.Navigation("Demirbas");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Kullanici", b =>
                {
                    b.HasOne("OtoServisSatis.Entities.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Zimmet", b =>
                {
                    b.HasOne("OtoServisSatis.Entities.Demirbas", "Demirbas")
                        .WithMany()
                        .HasForeignKey("DemirbasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OtoServisSatis.Entities.Kullanan", "Kullanan")
                        .WithMany()
                        .HasForeignKey("KullananId");

                    b.Navigation("Demirbas");

                    b.Navigation("Kullanan");
                });
#pragma warning restore 612, 618
        }
    }
}
