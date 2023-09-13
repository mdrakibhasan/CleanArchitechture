using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "ProductName", "Status" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 9, 11, 23, 41, 23, 739, DateTimeKind.Unspecified).AddTicks(5877), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Apple", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "ProductName", "Status" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2023, 9, 11, 23, 41, 23, 753, DateTimeKind.Unspecified).AddTicks(5920), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Mango", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
