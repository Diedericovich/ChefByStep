using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefByStep.API.Migrations
{
    public partial class entitiesmodelbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeUser_Recipes_CompletedRecipesId",
                table: "RecipeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeUser_Users_CompletedById",
                table: "RecipeUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeUser1_Recipes_FavoriteRecipesId",
                table: "RecipeUser1");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeUser1_Users_FavouritedById",
                table: "RecipeUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeUser1",
                table: "RecipeUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeUser",
                table: "RecipeUser");

            migrationBuilder.RenameTable(
                name: "RecipeUser1",
                newName: "UserFavouritedRecipe");

            migrationBuilder.RenameTable(
                name: "RecipeUser",
                newName: "UserCompletedRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeUser1_FavouritedById",
                table: "UserFavouritedRecipe",
                newName: "IX_UserFavouritedRecipe_FavouritedById");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeUser_CompletedRecipesId",
                table: "UserCompletedRecipe",
                newName: "IX_UserCompletedRecipe_CompletedRecipesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavouritedRecipe",
                table: "UserFavouritedRecipe",
                columns: new[] { "FavoriteRecipesId", "FavouritedById" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompletedRecipe",
                table: "UserCompletedRecipe",
                columns: new[] { "CompletedById", "CompletedRecipesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompletedRecipe_Recipes_CompletedRecipesId",
                table: "UserCompletedRecipe",
                column: "CompletedRecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompletedRecipe_Users_CompletedById",
                table: "UserCompletedRecipe",
                column: "CompletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouritedRecipe_Recipes_FavoriteRecipesId",
                table: "UserFavouritedRecipe",
                column: "FavoriteRecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouritedRecipe_Users_FavouritedById",
                table: "UserFavouritedRecipe",
                column: "FavouritedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompletedRecipe_Recipes_CompletedRecipesId",
                table: "UserCompletedRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompletedRecipe_Users_CompletedById",
                table: "UserCompletedRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouritedRecipe_Recipes_FavoriteRecipesId",
                table: "UserFavouritedRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouritedRecipe_Users_FavouritedById",
                table: "UserFavouritedRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavouritedRecipe",
                table: "UserFavouritedRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompletedRecipe",
                table: "UserCompletedRecipe");

            migrationBuilder.RenameTable(
                name: "UserFavouritedRecipe",
                newName: "RecipeUser1");

            migrationBuilder.RenameTable(
                name: "UserCompletedRecipe",
                newName: "RecipeUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavouritedRecipe_FavouritedById",
                table: "RecipeUser1",
                newName: "IX_RecipeUser1_FavouritedById");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompletedRecipe_CompletedRecipesId",
                table: "RecipeUser",
                newName: "IX_RecipeUser_CompletedRecipesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeUser1",
                table: "RecipeUser1",
                columns: new[] { "FavoriteRecipesId", "FavouritedById" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeUser",
                table: "RecipeUser",
                columns: new[] { "CompletedById", "CompletedRecipesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeUser_Recipes_CompletedRecipesId",
                table: "RecipeUser",
                column: "CompletedRecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeUser_Users_CompletedById",
                table: "RecipeUser",
                column: "CompletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeUser1_Recipes_FavoriteRecipesId",
                table: "RecipeUser1",
                column: "FavoriteRecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeUser1_Users_FavouritedById",
                table: "RecipeUser1",
                column: "FavouritedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
