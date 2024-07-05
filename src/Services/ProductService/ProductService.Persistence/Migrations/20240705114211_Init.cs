using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("8f5f0acc-727e-48b0-a7d9-ab69202bb835"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Computer", null },
                    { new Guid("c8df2d54-377f-4b10-8540-78e17a6c2418"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Phone", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2b7f8b22-176b-42b6-8218-a18a9df2a28d"), new Guid("c8df2d54-377f-4b10-8540-78e17a6c2418"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "iPhone 13 128 Gb Akıllı Telefon Mavi", 25000m, null },
                    { new Guid("32cbdcda-453c-4c43-9bbf-64f641309948"), new Guid("8f5f0acc-727e-48b0-a7d9-ab69202bb835"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EXPER XERA XC136 INTEL CORE İ5 13400F 2.5GHZ 16GB", 15000m, null },
                    { new Guid("659f84b4-7299-42b4-8818-e413b6816a88"), new Guid("c8df2d54-377f-4b10-8540-78e17a6c2418"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "iPhone 13 128 Gb Akıllı Telefon Yıldız Işığı", 12000m, null },
                    { new Guid("a2fb2a7c-7cae-4a6f-88bd-419fc61383c4"), new Guid("8f5f0acc-727e-48b0-a7d9-ab69202bb835"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HP 898B7EA INTEL CORE İ5 1335U 3.4 GHZ 8 GB 512 GB", 16500m, null },
                    { new Guid("b275118d-9788-418f-8a67-e097b8c1100a"), new Guid("8f5f0acc-727e-48b0-a7d9-ab69202bb835"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EXPER DIAMOND DEX600 INTEL CORE İ5 11400 2.6GHZ 8GB 256GB SSD INTEL UHD730", 35000m, null },
                    { new Guid("bd7714a0-0a16-4674-a95b-58e9e7ad3979"), new Guid("8f5f0acc-727e-48b0-a7d9-ab69202bb835"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CASPER Excalibur E650 İ5 12400F 2.5GHZ 32GB 500GB", 15400m, null },
                    { new Guid("d2c968b9-80ec-4c8d-a4df-f4a43ae2832c"), new Guid("c8df2d54-377f-4b10-8540-78e17a6c2418"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xiaomi Redmi 12 8/128 GB Gece Yarısı Siyahı Akıllı Telefon", 25400m, null },
                    { new Guid("ee003206-5809-4bc9-8972-d91d2a8a7f59"), new Guid("8f5f0acc-727e-48b0-a7d9-ab69202bb835"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "LENOVO AIO 3 INTEL CORE İ5 12450H 3.3 GHZ 8 GB 512 GB", 16000m, null },
                    { new Guid("fae057c3-4ea0-44c8-9fa2-038525cb8eb1"), new Guid("c8df2d54-377f-4b10-8540-78e17a6c2418"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Samsung Galaxy A15 6/128 Gb Akıllı Telefon Siyah", 35000m, null }
                });

            migrationBuilder.CreateIndex(
                name: "UK_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UK_Product_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
