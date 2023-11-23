using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class second2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BarCode",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 10, 8, 12, 31, 32, 110, DateTimeKind.Unspecified).AddTicks(4449), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 10, 8, 12, 31, 32, 112, DateTimeKind.Unspecified).AddTicks(4201), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BarCode", "Created" },
                values: new object[] { "0001", new DateTimeOffset(new DateTime(2023, 10, 8, 12, 31, 32, 232, DateTimeKind.Unspecified).AddTicks(2208), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BarCode", "Created" },
                values: new object[] { "0002", new DateTimeOffset(new DateTime(2023, 10, 8, 12, 31, 32, 232, DateTimeKind.Unspecified).AddTicks(3099), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BarCode",
                table: "Products",
                column: "BarCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_BarCode",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "BarCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 10, 8, 12, 22, 23, 532, DateTimeKind.Unspecified).AddTicks(1521), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 10, 8, 12, 22, 23, 534, DateTimeKind.Unspecified).AddTicks(661), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BarCode", "Created" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2023, 10, 8, 12, 22, 23, 638, DateTimeKind.Unspecified).AddTicks(5134), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BarCode", "Created" },
                values: new object[] { null, new DateTimeOffset(new DateTime(2023, 10, 8, 12, 22, 23, 638, DateTimeKind.Unspecified).AddTicks(5886), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
