using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Persistence.Migrations
{
    public partial class AddTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Products_ProductsProductId",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Shops_ShopsShopId",
                table: "ProductShop");

            migrationBuilder.RenameColumn(
                name: "ShopsShopId",
                table: "ProductShop",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "ProductShop",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShop_ShopsShopId",
                table: "ProductShop",
                newName: "IX_ProductShop_ShopId");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ProductName" },
                values: new object[] { new Guid("09133c5e-9733-40f9-bed5-d485f27e448e"), "Vegetables", "Potato" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ProductName" },
                values: new object[] { new Guid("743a64ef-bccb-4e6d-8543-4a65bc0fe846"), "Vegetables", "Tomato" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "ClosingTime", "OpeningTime", "ShopAddress", "ShopName" },
                values: new object[] { new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d"), new DateTime(1, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 7, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), "Minsk", "Sosedi" });

            migrationBuilder.InsertData(
                table: "ProductShop",
                columns: new[] { "ProductId", "ShopId" },
                values: new object[] { new Guid("09133c5e-9733-40f9-bed5-d485f27e448e"), new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d") });

            migrationBuilder.InsertData(
                table: "ProductShop",
                columns: new[] { "ProductId", "ShopId" },
                values: new object[] { new Guid("743a64ef-bccb-4e6d-8543-4a65bc0fe846"), new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d") });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Products_ProductId",
                table: "ProductShop",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Shops_ShopId",
                table: "ProductShop",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Products_ProductId",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Shops_ShopId",
                table: "ProductShop");

            migrationBuilder.DeleteData(
                table: "ProductShop",
                keyColumns: new[] { "ProductId", "ShopId" },
                keyValues: new object[] { new Guid("09133c5e-9733-40f9-bed5-d485f27e448e"), new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d") });

            migrationBuilder.DeleteData(
                table: "ProductShop",
                keyColumns: new[] { "ProductId", "ShopId" },
                keyValues: new object[] { new Guid("743a64ef-bccb-4e6d-8543-4a65bc0fe846"), new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d") });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("09133c5e-9733-40f9-bed5-d485f27e448e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("743a64ef-bccb-4e6d-8543-4a65bc0fe846"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d"));

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "ProductShop",
                newName: "ShopsShopId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductShop",
                newName: "ProductsProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductShop_ShopId",
                table: "ProductShop",
                newName: "IX_ProductShop_ShopsShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Products_ProductsProductId",
                table: "ProductShop",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Shops_ShopsShopId",
                table: "ProductShop",
                column: "ShopsShopId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
