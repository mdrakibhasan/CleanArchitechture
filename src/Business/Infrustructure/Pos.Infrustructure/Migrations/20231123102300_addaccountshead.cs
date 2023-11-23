using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class addaccountshead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsHeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootTLeaf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningBal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RootId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountsHeadTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountsHeadTypeId1 = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsHeads_AccountsHeads_RootId",
                        column: x => x.RootId,
                        principalTable: "AccountsHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsHeads_AccountsHeadTypes_AccountsHeadTypeId1",
                        column: x => x.AccountsHeadTypeId1,
                        principalTable: "AccountsHeadTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AccountsHeads_RootId",
                table: "AccountsHeads",
                column: "RootId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsHeads");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 15, 38, 21, 902, DateTimeKind.Unspecified).AddTicks(1553), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 15, 38, 21, 903, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 15, 38, 22, 25, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 23, 15, 38, 22, 25, DateTimeKind.Unspecified).AddTicks(7782), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
