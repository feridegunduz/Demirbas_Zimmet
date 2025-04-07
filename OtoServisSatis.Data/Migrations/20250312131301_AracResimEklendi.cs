using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class AracResimEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Demirbaslar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 2,
                column: "EklenmeTarihi",
                value: new DateTime(2025, 3, 12, 16, 13, 0, 749, DateTimeKind.Local).AddTicks(454));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Demirbaslar",
                columns: new[] { "Id", "FaturaNo", "FaturaTarihi", "Kategori", "MarkaId", "Notlar", "SeriNo", "UrunTipi", "ZimmetliMi" },
                values: new object[] { 1, "123456", new DateTime(2025, 3, 5, 10, 28, 45, 353, DateTimeKind.Local).AddTicks(6989), "Bilgisayar", 1, "Notlar", "123456", "Laptop", false });

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 2,
                column: "EklenmeTarihi",
                value: new DateTime(2025, 3, 5, 10, 28, 45, 353, DateTimeKind.Local).AddTicks(5248));
        }
    }
}
