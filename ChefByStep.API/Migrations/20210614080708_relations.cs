using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefByStep.API.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId1",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId2",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserId1",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "UserId2",
                table: "Recipes",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_UserId2",
                table: "Recipes",
                newName: "IX_Recipes_CreatedById");

            migrationBuilder.CreateTable(
                name: "RecipeUser",
                columns: table => new
                {
                    CompletedById = table.Column<int>(type: "int", nullable: false),
                    CompletedRecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser", x => new { x.CompletedById, x.CompletedRecipesId });
                    table.ForeignKey(
                        name: "FK_RecipeUser_Recipes_CompletedRecipesId",
                        column: x => x.CompletedRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUser_Users_CompletedById",
                        column: x => x.CompletedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeUser1",
                columns: table => new
                {
                    FavoriteRecipesId = table.Column<int>(type: "int", nullable: false),
                    FavouritedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser1", x => new { x.FavoriteRecipesId, x.FavouritedById });
                    table.ForeignKey(
                        name: "FK_RecipeUser1_Recipes_FavoriteRecipesId",
                        column: x => x.FavoriteRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUser1_Users_FavouritedById",
                        column: x => x.FavouritedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUser_CompletedRecipesId",
                table: "RecipeUser",
                column: "CompletedRecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUser1_FavouritedById",
                table: "RecipeUser1",
                column: "FavouritedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_CreatedById",
                table: "Recipes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_CreatedById",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeUser");

            migrationBuilder.DropTable(
                name: "RecipeUser1");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Recipes",
                newName: "UserId2");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_CreatedById",
                table: "Recipes",
                newName: "IX_Recipes_UserId2");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId1",
                table: "Recipes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId1",
                table: "Recipes",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId2",
                table: "Recipes",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
