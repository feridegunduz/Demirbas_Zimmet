using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class yenivtbgltsı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FaturaTarihi",
                table: "Demirbaslar",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Demirbaslar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FaturaTarihi",
                table: "Demirbaslar",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 2,
                column: "EklenmeTarihi",
                value: new DateTime(2025, 3, 3, 13, 45, 50, 972, DateTimeKind.Local).AddTicks(1590));
        }
    }
}
