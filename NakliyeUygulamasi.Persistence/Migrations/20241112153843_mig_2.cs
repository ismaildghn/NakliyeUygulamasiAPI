using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NakliyeUygulamasi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Orders_ListingId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_PickupAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Listings");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PickupAddressId",
                table: "Listings",
                newName: "IX_Listings_PickupAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Listings",
                newName: "IX_Listings_DeliveryAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Listings",
                newName: "IX_Listings_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Addresses_DeliveryAddressId",
                table: "Listings",
                column: "DeliveryAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Addresses_PickupAddressId",
                table: "Listings",
                column: "PickupAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Customers_CustomerId",
                table: "Listings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Listings_ListingId",
                table: "Offers",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Addresses_DeliveryAddressId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Addresses_PickupAddressId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Customers_CustomerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Listings_ListingId",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_PickupAddressId",
                table: "Orders",
                newName: "IX_Orders_PickupAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_DeliveryAddressId",
                table: "Orders",
                newName: "IX_Orders_DeliveryAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Orders_ListingId",
                table: "Offers",
                column: "ListingId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_PickupAddressId",
                table: "Orders",
                column: "PickupAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
