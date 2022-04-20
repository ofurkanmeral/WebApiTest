using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ürünler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ürünler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ürünler_Kategoriler_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Kategoriler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFicir",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFicir", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductFicir_Ürünler_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Ürünler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "ID", "CreatedDate", "Name" },
                values: new object[] { 1, new DateTime(2022, 4, 20, 12, 34, 21, 605, DateTimeKind.Local).AddTicks(5657), "Category1" });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "ID", "CreatedDate", "Name" },
                values: new object[] { 2, new DateTime(2022, 4, 20, 12, 34, 21, 605, DateTimeKind.Local).AddTicks(6045), "Category2" });

            migrationBuilder.InsertData(
                table: "Ürünler",
                columns: new[] { "ID", "CategoryID", "CreatedDate", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(2435), "Product1", 100m, 10 },
                    { 2, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3194), "Product2", 200m, 20 },
                    { 3, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3205), "Product3", 300m, 30 },
                    { 4, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3214), "Product4", 400m, 40 },
                    { 5, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3269), "Product5", 500m, 50 },
                    { 6, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3282), "Product6", 600m, 60 },
                    { 7, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3291), "Product7", 700m, 70 },
                    { 8, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3300), "Product8", 800m, 80 },
                    { 9, 1, new DateTime(2022, 4, 20, 12, 34, 21, 607, DateTimeKind.Local).AddTicks(3308), "Product9", 900m, 90 }
                });

            migrationBuilder.InsertData(
                table: "ProductFicir",
                columns: new[] { "ID", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 1, "mavi", null, 1, null });

            migrationBuilder.InsertData(
                table: "ProductFicir",
                columns: new[] { "ID", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 2, "kırmızı", null, 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFicir_ProductId",
                table: "ProductFicir",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ürünler_CategoryID",
                table: "Ürünler",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFicir");

            migrationBuilder.DropTable(
                name: "Ürünler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
