using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixZimmetTarihiType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demirbaslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeriNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FaturaNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UrunTipi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FaturaTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    ZimmetliMi = table.Column<bool>(type: "bit", nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demirbaslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demirbaslar_Markalar_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Markalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullananlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemirbasId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DemirbasId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullananlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullananlar_Demirbaslar_DemirbasId1",
                        column: x => x.DemirbasId1,
                        principalTable: "Demirbaslar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zimmetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemirbasId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    ZimmetTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullananId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zimmetler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Demirbaslar_DemirbasId",
                        column: x => x.DemirbasId,
                        principalTable: "Demirbaslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Kullananlar_KullananId",
                        column: x => x.KullananId,
                        principalTable: "Kullananlar",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "Adi" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "Adi", "AktifMi", "EklenmeTarihi", "Email", "KullaniciAdi", "RolId", "Sifre", "Soyadi", "Telefon" },
                values: new object[] { 2, "Feride", true, new DateTime(2025, 3, 3, 13, 45, 50, 972, DateTimeKind.Local).AddTicks(1590), "feride@gmail.com", "feridegndz", 1, "123456", "Gündüz", "1234567890" });

            migrationBuilder.CreateIndex(
                name: "IX_Demirbaslar_MarkaId",
                table: "Demirbaslar",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullananlar_DemirbasId1",
                table: "Kullananlar",
                column: "DemirbasId1");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_RolId",
                table: "Kullanicilar",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_DemirbasId",
                table: "Zimmetler",
                column: "DemirbasId");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_KullananId",
                table: "Zimmetler",
                column: "KullananId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Zimmetler");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Kullananlar");

            migrationBuilder.DropTable(
                name: "Demirbaslar");

            migrationBuilder.DropTable(
                name: "Markalar");
        }
    }
}
