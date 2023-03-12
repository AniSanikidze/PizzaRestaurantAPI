using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedToPizzaAndImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");
        }
    }
}
