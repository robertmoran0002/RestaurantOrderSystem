using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantOrderSystem.Migrations
{
    public partial class AddRestaurantToDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_OrderMains_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "OrderMainOrderId",
            //    table: "Payments",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LocationId",
                table: "Payments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Locations_LocationId",
                table: "Payments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_OrderMains_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "OrderMains",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Locations_LocationId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_OrderMains_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_LocationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_OrderMains_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "OrderMains",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
