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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("53c0c7ae-747e-4dd6-9c55-4e2beb088a09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Phone", null },
                    { new Guid("68a7e592-7610-4458-a8a9-2e83bb9e5a12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Computer", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Image", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("13fd2cc8-7c81-49d8-914e-84ddaebdf725"), new Guid("53c0c7ae-747e-4dd6-9c55-4e2beb088a09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/129885-1_large.jpg", "iPhone 13 128 Gb Akıllı Telefon Yıldız Işığı", 12000m, null },
                    { new Guid("710cde63-a433-4f0e-93a1-f175d97ec869"), new Guid("68a7e592-7610-4458-a8a9-2e83bb9e5a12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/grundig/thumb/0001-layer-3_small.jpg", "EXPER XERA XC136 INTEL CORE İ5 13400F 2.5GHZ 16GB", 15000m, null },
                    { new Guid("734d45b1-fbc5-41ac-b423-31cc0bf48031"), new Guid("53c0c7ae-747e-4dd6-9c55-4e2beb088a09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/tcl/thumb/142148-1_large.jpg", "Xiaomi Redmi 12 8/128 GB Gece Yarısı Siyahı Akıllı Telefon", 25400m, null },
                    { new Guid("9b14f4b6-e6da-4f21-ab8f-78e5ef83b487"), new Guid("68a7e592-7610-4458-a8a9-2e83bb9e5a12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/acer/thumb/142883-4_small.jpg", "LENOVO AIO 3 INTEL CORE İ5 12450H 3.3 GHZ 8 GB 512 GB", 16000m, null },
                    { new Guid("c86535ef-33b9-4367-b9dd-789a6fd0a728"), new Guid("53c0c7ae-747e-4dd6-9c55-4e2beb088a09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/129743-1_large.jpg", "Samsung Galaxy A15 6/128 Gb Akıllı Telefon Siyah", 35000m, null },
                    { new Guid("c9ba11e2-0a37-416b-88f1-ff272ec75fb1"), new Guid("68a7e592-7610-4458-a8a9-2e83bb9e5a12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/exper/thumb/144179-1_large.jpg", "CASPER Excalibur E650 İ5 12400F 2.5GHZ 32GB 500GB", 15400m, null },
                    { new Guid("e3882ee9-2c8e-4d85-90b4-86217149fe1a"), new Guid("68a7e592-7610-4458-a8a9-2e83bb9e5a12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/philips/thumb/140996-1_large.jpg", "EXPER DIAMOND DEX600 INTEL CORE İ5 11400 2.6GHZ 8GB 256GB SSD INTEL UHD730", 35000m, null },
                    { new Guid("f173c6d3-1222-4742-8c69-5de31e63b602"), new Guid("53c0c7ae-747e-4dd6-9c55-4e2beb088a09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/129895-1_large.jpg", "iPhone 13 128 Gb Akıllı Telefon Mavi", 25000m, null },
                    { new Guid("fbb71f16-638a-4c7d-85d6-98a86ee5cf74"), new Guid("68a7e592-7610-4458-a8a9-2e83bb9e5a12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/hp/thumb/146251-1_small.jpg", "HP 898B7EA INTEL CORE İ5 1335U 3.4 GHZ 8 GB 512 GB", 16500m, null }
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
