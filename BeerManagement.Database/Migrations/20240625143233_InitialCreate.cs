using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeerManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bm");

            migrationBuilder.CreateTable(
                name: "Breweries",
                schema: "bm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wholesalers",
                schema: "bm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                schema: "bm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    AlcoholLevel = table.Column<decimal>(type: "TEXT", nullable: false),
                    BreweryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalSchema: "bm",
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WholesalerStocks",
                schema: "bm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BeerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WholesalerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholesalerStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WholesalerStocks_Beers_BeerId",
                        column: x => x.BeerId,
                        principalSchema: "bm",
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WholesalerStocks_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalSchema: "bm",
                        principalTable: "Wholesalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "bm",
                table: "Breweries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe" });

            migrationBuilder.InsertData(
                schema: "bm",
                table: "Wholesalers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092"), "GeneDrinks" });

            migrationBuilder.InsertData(
                schema: "bm",
                table: "Beers",
                columns: new[] { "Id", "AlcoholLevel", "BreweryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("38f9d512-b892-4149-a28b-0fddef0e75f1"), 0m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe Ruby 0.0", 2.4m },
                    { new Guid("4341fe34-68b6-49f1-aed1-d3ff0dd1a830"), 0m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe Blonde 0.0", 2.1m },
                    { new Guid("4814c82c-df0d-4794-8815-a15acf72f79a"), 9m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe rituel", 3m },
                    { new Guid("be795fdb-dfd8-4b81-b85f-fa372599ad3b"), 5m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe Ruby", 2.5m },
                    { new Guid("ccb534da-6a31-44f3-9995-faa0301a8f31"), 6.6m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe Blonde", 2.2m },
                    { new Guid("e762513e-eb38-4e16-a0e3-e0fb0203d89c"), 8.5m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe Prestige", 2.2m },
                    { new Guid("ec8405d7-c55c-41cb-9bfd-7a28696c36d5"), 6.6m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe ambrée", 2.8m },
                    { new Guid("f387ad39-e17a-4bc6-bab0-a12236451943"), 8.5m, new Guid("49949cfb-6027-499a-9208-ec6b8ceb0ba6"), "Leffe tripple", 3m }
                });

            migrationBuilder.InsertData(
                schema: "bm",
                table: "WholesalerStocks",
                columns: new[] { "Id", "BeerId", "Quantity", "WholesalerId" },
                values: new object[,]
                {
                    { new Guid("2e55da49-70a9-4343-a4b2-6d64a8e31722"), new Guid("be795fdb-dfd8-4b81-b85f-fa372599ad3b"), 20, new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092") },
                    { new Guid("394e073a-6355-434a-aebe-694dda77488e"), new Guid("4341fe34-68b6-49f1-aed1-d3ff0dd1a830"), 20, new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092") },
                    { new Guid("6f2084e5-99de-4759-9d86-a357e92c4252"), new Guid("ccb534da-6a31-44f3-9995-faa0301a8f31"), 20, new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092") },
                    { new Guid("b2e4e9e3-b4b2-4cd1-8223-b348710390d7"), new Guid("e762513e-eb38-4e16-a0e3-e0fb0203d89c"), 20, new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092") },
                    { new Guid("d6b746ac-5dc7-4a49-ade3-83cb4e90be9f"), new Guid("38f9d512-b892-4149-a28b-0fddef0e75f1"), 20, new Guid("adfb1b02-b2b8-45e1-bcf1-b29eada93092") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                schema: "bm",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesalerStocks_BeerId",
                schema: "bm",
                table: "WholesalerStocks",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesalerStocks_WholesalerId",
                schema: "bm",
                table: "WholesalerStocks",
                column: "WholesalerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WholesalerStocks",
                schema: "bm");

            migrationBuilder.DropTable(
                name: "Beers",
                schema: "bm");

            migrationBuilder.DropTable(
                name: "Wholesalers",
                schema: "bm");

            migrationBuilder.DropTable(
                name: "Breweries",
                schema: "bm");
        }
    }
}
