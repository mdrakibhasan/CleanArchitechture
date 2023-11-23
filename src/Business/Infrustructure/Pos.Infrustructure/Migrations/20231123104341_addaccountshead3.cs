using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class addaccountshead3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountsHeadId",
                table: "AccountsHeadTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 43, 41, 245, DateTimeKind.Unspecified).AddTicks(7795), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 43, 41, 247, DateTimeKind.Unspecified).AddTicks(5931), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 43, 41, 268, DateTimeKind.Unspecified).AddTicks(7088), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 43, 41, 268, DateTimeKind.Unspecified).AddTicks(7870), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_AccountsHeadTypes_AccountsHeadId",
                table: "AccountsHeadTypes",
                column: "AccountsHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsHeadTypes_AccountsHeads_AccountsHeadId",
                table: "AccountsHeadTypes",
                column: "AccountsHeadId",
                principalTable: "AccountsHeads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsHeadTypes_AccountsHeads_AccountsHeadId",
                table: "AccountsHeadTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccountsHeadTypes_AccountsHeadId",
                table: "AccountsHeadTypes");

            migrationBuilder.DropColumn(
                name: "AccountsHeadId",
                table: "AccountsHeadTypes");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 24, 34, 474, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 24, 34, 476, DateTimeKind.Unspecified).AddTicks(1641), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 24, 34, 497, DateTimeKind.Unspecified).AddTicks(4216), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 24, 34, 497, DateTimeKind.Unspecified).AddTicks(5123), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
