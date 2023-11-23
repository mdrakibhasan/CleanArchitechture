using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class addaccountshead4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 46, 40, 354, DateTimeKind.Unspecified).AddTicks(9587), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 46, 40, 357, DateTimeKind.Unspecified).AddTicks(1203), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 46, 40, 382, DateTimeKind.Unspecified).AddTicks(5497), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 16, 46, 40, 382, DateTimeKind.Unspecified).AddTicks(6642), new TimeSpan(0, 6, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
