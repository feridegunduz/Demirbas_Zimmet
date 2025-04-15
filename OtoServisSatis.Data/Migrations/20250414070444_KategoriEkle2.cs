using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class KategoriEkle2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Demirbaslar");

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Demirbaslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklenmeTarihi", "UserGuid" },
                values: new object[] { new DateTime(2025, 4, 14, 10, 4, 43, 955, DateTimeKind.Local).AddTicks(4967), new Guid("94bf8281-e710-47ef-9e3a-7ef4a4e34a3b") });

            migrationBuilder.CreateIndex(
                name: "IX_Demirbaslar_KategoriId",
                table: "Demirbaslar",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demirbaslar_Kategoriler_KategoriId",
                table: "Demirbaslar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demirbaslar_Kategoriler_KategoriId",
                table: "Demirbaslar");

            migrationBuilder.DropIndex(
                name: "IX_Demirbaslar_KategoriId",
                table: "Demirbaslar");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Demirbaslar");

            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "Demirbaslar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklenmeTarihi", "UserGuid" },
                values: new object[] { new DateTime(2025, 4, 14, 9, 43, 36, 297, DateTimeKind.Local).AddTicks(1875), new Guid("1ae5a471-fdd2-45b4-a9e5-11ee1b2c36d8") });
        }
    }
}
