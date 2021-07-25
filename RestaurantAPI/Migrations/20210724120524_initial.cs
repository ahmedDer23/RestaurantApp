using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RestaurantAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "foodItems",
                columns: table => new
                {
                    foodItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    foodItemName = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodItems", x => x.foodItemId);
                });

            migrationBuilder.CreateTable(
                name: "orderMasters",
                columns: table => new
                {
                    orderMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderNumber = table.Column<string>(type: "text", nullable: true),
                    customerId = table.Column<int>(type: "integer", nullable: false),
                    paymentMethod = table.Column<string>(type: "text", nullable: true),
                    priceTotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderMasters", x => x.orderMasterId);
                    table.ForeignKey(
                        name: "FK_orderMasters_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    orderDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderMasterId = table.Column<long>(type: "bigint", nullable: false),
                    foodItemId = table.Column<int>(type: "integer", nullable: false),
                    foodItemPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.orderDetailId);
                    table.ForeignKey(
                        name: "FK_orderDetails_foodItems_foodItemId",
                        column: x => x.foodItemId,
                        principalTable: "foodItems",
                        principalColumn: "foodItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_orderMasters_orderMasterId",
                        column: x => x.orderMasterId,
                        principalTable: "orderMasters",
                        principalColumn: "orderMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_foodItemId",
                table: "orderDetails",
                column: "foodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_orderMasterId",
                table: "orderDetails",
                column: "orderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_orderMasters_customerId",
                table: "orderMasters",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "foodItems");

            migrationBuilder.DropTable(
                name: "orderMasters");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
