using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class addaccountshead2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsHeads_AccountsHeadTypes_AccountsHeadTypeId1",
                table: "AccountsHeads");

            migrationBuilder.DropIndex(
                name: "IX_AccountsHeads_AccountsHeadTypeId1",
                table: "AccountsHeads");

            migrationBuilder.DropColumn(
                name: "AccountsHeadTypeId1",
                table: "AccountsHeads");

            migrationBuilder.AlterColumn<int>(
                name: "AccountsHeadTypeId",
                table: "AccountsHeads",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_AccountsHeads_AccountsHeadTypeId",
                table: "AccountsHeads",
                column: "AccountsHeadTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsHeads_AccountsHeadTypes_AccountsHeadTypeId",
                table: "AccountsHeads",
                column: "AccountsHeadTypeId",
                principalTable: "AccountsHeadTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsHeads_AccountsHeadTypes_AccountsHeadTypeId",
                table: "AccountsHeads");

            migrationBuilder.DropIndex(
                name: "IX_AccountsHeads_AccountsHeadTypeId",
                table: "AccountsHeads");

            migrationBuilder.AlterColumn<string>(
                name: "AccountsHeadTypeId",
                table: "AccountsHeads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccountsHeadTypeId1",
                table: "AccountsHeads",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 22, 59, 535, DateTimeKind.Unspecified).AddTicks(8576), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 22, 59, 537, DateTimeKind.Unspecified).AddTicks(6772), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 22, 59, 565, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 22, 59, 565, DateTimeKind.Unspecified).AddTicks(7578), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_AccountsHeads_AccountsHeadTypeId1",
                table: "AccountsHeads",
                column: "AccountsHeadTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsHeads_AccountsHeadTypes_AccountsHeadTypeId1",
                table: "AccountsHeads",
                column: "AccountsHeadTypeId1",
                principalTable: "AccountsHeadTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
