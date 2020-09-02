using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyList.Infra.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Password = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyList_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TypeOfMeasure = table.Column<string>(type: "varchar(10)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Category = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListBuyItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    ListBuyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListBuyItems", x => new { x.ListBuyId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ListBuyItems_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListBuyItems_BuyList_ListBuyId",
                        column: x => x.ListBuyId,
                        principalTable: "BuyList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyList_OwnerId",
                table: "BuyList",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_OwnerId",
                table: "Item",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ListBuyItems_ItemId",
                table: "ListBuyItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListBuyItems");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "BuyList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
