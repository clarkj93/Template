using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoSell.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemsStatus_ItemStatusId",
                        column: x => x.ItemStatusId,
                        principalTable: "ItemsStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemsStatus",
                columns: new[] { "Id", "Created", "LastUpdated", "Status" },
                values: new object[] { 1, new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(2618), new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(3593), "Available" });

            migrationBuilder.InsertData(
                table: "ItemsStatus",
                columns: new[] { "Id", "Created", "LastUpdated", "Status" },
                values: new object[] { 2, new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4409), new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4412), "Not Available" });

            migrationBuilder.InsertData(
                table: "ItemsStatus",
                columns: new[] { "Id", "Created", "LastUpdated", "Status" },
                values: new object[] { 3, new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4414), new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4415), "Sold" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Created", "ItemStatusId", "LastUpdated" },
                values: new object[] { 1, new DateTime(2021, 1, 15, 13, 42, 48, 478, DateTimeKind.Utc).AddTicks(3162), 1, new DateTime(2021, 1, 15, 13, 42, 48, 478, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemStatusId",
                table: "Items",
                column: "ItemStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemsStatus");
        }
    }
}
