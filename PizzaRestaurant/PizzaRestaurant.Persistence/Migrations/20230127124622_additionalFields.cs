using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class additionalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankHistory_Pizzas_PizzaId",
                table: "RankHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RankHistory_Users_UserId",
                table: "RankHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RankHistory",
                table: "RankHistory");

            migrationBuilder.RenameTable(
                name: "RankHistory",
                newName: "RankHistories");

            migrationBuilder.RenameIndex(
                name: "IX_RankHistory_UserId",
                table: "RankHistories",
                newName: "IX_RankHistories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RankHistory_PizzaId",
                table: "RankHistories",
                newName: "IX_RankHistories_PizzaId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RankHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RankHistories",
                table: "RankHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RankHistories_Pizzas_PizzaId",
                table: "RankHistories",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RankHistories_Users_UserId",
                table: "RankHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankHistories_Pizzas_PizzaId",
                table: "RankHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_RankHistories_Users_UserId",
                table: "RankHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RankHistories",
                table: "RankHistories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RankHistories");

            migrationBuilder.RenameTable(
                name: "RankHistories",
                newName: "RankHistory");

            migrationBuilder.RenameIndex(
                name: "IX_RankHistories_UserId",
                table: "RankHistory",
                newName: "IX_RankHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RankHistories_PizzaId",
                table: "RankHistory",
                newName: "IX_RankHistory_PizzaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RankHistory",
                table: "RankHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RankHistory_Pizzas_PizzaId",
                table: "RankHistory",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RankHistory_Users_UserId",
                table: "RankHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
