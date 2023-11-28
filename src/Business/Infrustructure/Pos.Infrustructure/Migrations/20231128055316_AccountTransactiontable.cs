using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class AccountTransactiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTransactionMst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    AuthRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthRefId = table.Column<int>(type: "int", nullable: true),
                    VoucherType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    VoucherNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManualVoucherNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuthBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransactionMst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransactionDtl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTransactionMstID = table.Column<int>(type: "int", nullable: false),
                    AccountsHeadId = table.Column<int>(type: "int", nullable: false),
                    CreditedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineNo = table.Column<int>(type: "int", nullable: false),
                    DebitedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransactionDtl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransactionDtl_AccountsHeads_AccountsHeadId",
                        column: x => x.AccountsHeadId,
                        principalTable: "AccountsHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransactionDtl_AccountTransactionMst_AccountTransactionMstID",
                        column: x => x.AccountTransactionMstID,
                        principalTable: "AccountTransactionMst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 28, 11, 53, 16, 193, DateTimeKind.Unspecified).AddTicks(6871), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 28, 11, 53, 16, 195, DateTimeKind.Unspecified).AddTicks(5435), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 28, 11, 53, 16, 217, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 28, 11, 53, 16, 217, DateTimeKind.Unspecified).AddTicks(1216), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactionDtl_AccountsHeadId",
                table: "AccountTransactionDtl",
                column: "AccountsHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactionDtl_AccountTransactionMstID",
                table: "AccountTransactionDtl",
                column: "AccountTransactionMstID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransactionDtl");

            migrationBuilder.DropTable(
                name: "AccountTransactionMst");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 15, 55, 49, 372, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 15, 55, 49, 373, DateTimeKind.Unspecified).AddTicks(8903), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 15, 55, 49, 395, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 11, 26, 15, 55, 49, 395, DateTimeKind.Unspecified).AddTicks(3443), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
