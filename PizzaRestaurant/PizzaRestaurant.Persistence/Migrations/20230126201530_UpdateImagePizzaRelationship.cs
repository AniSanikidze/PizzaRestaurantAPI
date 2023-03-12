using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImagePizzaRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Images_ImageId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ImageId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Pizzas");

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PizzaId",
                table: "Images",
                column: "PizzaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Pizzas_PizzaId",
                table: "Images",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Pizzas_PizzaId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PizzaId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ImageId",
                table: "Pizzas",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Images_ImageId",
                table: "Pizzas",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
