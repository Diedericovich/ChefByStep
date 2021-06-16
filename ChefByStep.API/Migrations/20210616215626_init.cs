using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefByStep.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMin = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecipe",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecipe", x => new { x.IngredientsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeRatings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRatings", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeRatings_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    StepsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => new { x.RecipesId, x.StepsId });
                    table.ForeignKey(
                        name: "FK_RecipeStep_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeStep_Steps_StepsId",
                        column: x => x.StepsId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompletedRecipes",
                columns: table => new
                {
                    CompletedById = table.Column<int>(type: "int", nullable: false),
                    CompletedRecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompletedRecipes", x => new { x.CompletedById, x.CompletedRecipesId });
                    table.ForeignKey(
                        name: "FK_UserCompletedRecipes_Recipes_CompletedRecipesId",
                        column: x => x.CompletedRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompletedRecipes_Users_CompletedById",
                        column: x => x.CompletedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavouriteRecipes",
                columns: table => new
                {
                    FavoriteRecipesId = table.Column<int>(type: "int", nullable: false),
                    FavouritedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavouriteRecipes", x => new { x.FavoriteRecipesId, x.FavouritedById });
                    table.ForeignKey(
                        name: "FK_UserFavouriteRecipes_Recipes_FavoriteRecipesId",
                        column: x => x.FavoriteRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavouriteRecipes_Users_FavouritedById",
                        column: x => x.FavouritedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "lemons", 0.0 },
                    { 34, "black mustard seeds", 0.0 },
                    { 35, "urad dal", 0.0 },
                    { 36, "asafetida", 0.0 },
                    { 37, "shallot", 0.0 },
                    { 38, "green chile", 0.0 },
                    { 39, "fresh curry leaves", 0.0 },
                    { 40, "ground turmeric", 0.0 },
                    { 41, "cauliflower florets", 0.0 },
                    { 42, "frozen peas", 0.0 },
                    { 43, "plain full-fat yogurt", 0.0 },
                    { 44, "cilantro", 0.0 },
                    { 45, "fried egg", 0.0 },
                    { 46, "key lime fillling", 0.0 },
                    { 33, "cashews", 0.0 },
                    { 47, "key lime juice", 0.0 },
                    { 49, "sweetened condensed milk", 0.0 },
                    { 50, "coarse salt", 0.0 },
                    { 51, "cornstarch", 0.0 },
                    { 52, "cream cheese", 0.0 },
                    { 54, "graham crackers", 0.0 },
                    { 55, "neutral oil", 0.0 },
                    { 56, "flour", 0.0 },
                    { 57, "cake flour", 0.0 },
                    { 58, "baking soda", 0.0 },
                    { 59, "large eggs", 0.0 },
                    { 60, "pure vanilla extract", 0.0 },
                    { 61, "buttermilk", 0.0 },
                    { 62, "confectioners' sugar", 0.0 },
                    { 48, "egg", 0.0 },
                    { 32, "sourdough bread", 0.0 },
                    { 53, "granulated sugar", 0.0 },
                    { 30, "pepper", 0.0 },
                    { 31, "oil", 0.0 },
                    { 2, "unsalted butter", 0.0 },
                    { 3, "prepared horseradish", 0.0 },
                    { 4, "kosher salt", 0.0 },
                    { 5, "shrimp", 0.0 },
                    { 6, "chopped dill", 0.0 },
                    { 8, "pasta\"", 0.0 },
                    { 9, "red onion", 0.0 },
                    { 10, "salt", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 11, "cubed roasted chicken", 0.0 },
                    { 12, "peppadews peppers", 0.0 },
                    { 13, "marinated artichoke hearts", 0.0 },
                    { 14, "smoked almonds", 0.0 },
                    { 15, "thyme", 0.0 },
                    { 7, "crusty bread", 0.0 },
                    { 17, "sherry vinegar", 0.0 },
                    { 29, "parsley", 0.0 },
                    { 16, "mustard", 0.0 },
                    { 28, "spaghetti", 0.0 },
                    { 27, "linguine", 0.0 },
                    { 25, "white wine", 0.0 },
                    { 24, "salted capers", 0.0 },
                    { 26, "tomatoes", 0.0 },
                    { 22, "olives", 0.0 },
                    { 21, "garlic", 0.0 },
                    { 20, "black pepper", 0.0 },
                    { 19, "olive oil", 0.0 },
                    { 18, "lemon", 0.0 },
                    { 23, "white fish", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 62, 0, "  Transfer the bowl to the mixer and whip on high speed until firm peaks form, about 5 minutes.  ", false },
                    { 56, 0, "  Scatter a third of the graham cracker crumbs over the filling and top with another layer of cake.  ", false },
                    { 63, 0, " Remove the skewer from the chilled cake and dollop the meringue on top, piling it high.   ", false },
                    { 61, 0, " Set the bowl over a pan of gently simmering water and heat, whisking occasionally, until the sugar is dissolved and the mixture reads 160�F (71�C) on a thermometer  ", false },
                    { 60, 0, " To make a Swiss meringue, place the egg whites and sugar in the heatproof bowl of an electric mixer.   ", false },
                    { 59, 0, " Chill the assembled cake until you�re ready to make the meringue.  ", false },
                    { 58, 0, " Slide a long wooden skewer vertically through the center of the cake if it feels wobbly.   ", false },
                    { 57, 0, "  Continue assembling in this manner with the remaining filling and cake layers.   ", false },
                    { 55, 0, " Stir the lime filling briefly to loosen it, then use a small offset spatula to spread about one-third of the filling over the cake, getting it right up to the edge.  ", false },
                    { 49, 0, " Strain the mixture through the fine-mesh sieve into the bowl and stir gently with a rubber spatula to let off some of the steam.  ", false },
                    { 53, 0, " Use a serrated knife to trim the domes from the tops of the cakes and slice each in half horizontally to create four layers.   ", false },
                    { 52, 0, " Make the lime soaker by stirring the sugar into the juice until it�s dissolved. Set aside.  ", false },
                    { 51, 0, " Place a piece of plastic film or wax paper directly on the surface of the custard to prevent a skin from forming and refrigerate until firm, at least 4 hours, preferably overnight.  ", false },
                    { 50, 0, "  Add the cream cheese, one or two pieces at a time, and stir until all of it has been incorporated.   ", false },
                    { 48, 0, " Reduce the temperature a bit as the mixture thickens dramatically and keep whisking as it boils for 2 minutes, being especially careful to keep the edges of the pot from scorching.   ", false },
                    { 47, 0, " Whisk everything together until it�s nice and smooth and then set over medium heat. Don�t stop whisking.  ", false },
                    { 64, 0, " Gently brown the meringue with a kitchen torch.   ", false },
                    { 46, 0, " Squeeze every last drop of juice from the limes and combine in a small saucepan with the yolks, condensed milk, salt, and cornstarch.   ", false },
                    { 54, 0, " Place one layer on a serving platter and brush the top with about 2 tablespoons of the soaker.   ", false },
                    { 65, 0, " Serve at cool room temperature.   ", false },
                    { 80, 0, "When the cake is in the oven, start worrying about how you�re going to cool it. Clear off a substantial section of your counter and spread out a clean, lint-free kitchen towel ", false },
                    { 67, 0, " Pan Goo & Perfect Chiffon Cake Pan Goo In a small container with a lid, whisk the oil and flour together until combined. ", false }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 45, 0, "Do yourself a favor and make the filling the night before you plan to assemble this cake. Have a fine-mesh sieve and a large bowl on standby near the stove.   ", false },
                    { 86, 0, "Round layers can be frozen for up to 1 month\"", false },
                    { 85, 0, "The cooled cakes can be used immediately or wrapped and refrigerated for up to 2 days. ", false },
                    { 84, 0, "Transfer the cake to a wire rack and let it cool completely. ", false },
                    { 83, 0, "Dust the top with additional confectioners� sugar and, beginning at a short end, roll the cake and towel into a tight log. ", false },
                    { 82, 0, "When the cake is ready, run a knife around the edge of the pan. Invert onto the towel and remove the silicone baking mat or parchment. ", false },
                    { 81, 0, "Sift a liberal amount of confectioners� sugar over the towel.", false },
                    { 79, 0, "Bake the roulade until the cake is golden brown and springs back in the center and a cake tester comes out clean, about 16 minutes.", false },
                    { 78, 0, "Roulade Pour the batter into the prepared baking sheet and spread it evenly to the corners with an offset spatula.", false },
                    { 77, 0, " Turn them right side up on the racks and let them cool completely.", false },
                    { 76, 0, "Transfer the pans to wire racks. Let the cakes rest in their pans for about 2 minutes, then carefully flip them out onto the racks. ", false },
                    { 75, 0, "Bake until the cakes are golden brown and spring back excitedly when gently pressed and a cake tester inserted into the centers comes out clean, about 25 minutes.", false },
                    { 74, 0, "Divide the batter evenly into the two prepared pans, filling each about halfway.", false },
                    { 73, 0, " Add the rest of the egg whites in two additions, folding gently until just combined.", false },
                    { 72, 0, "Then use a large rubber spatula to scoop about a third of the whipped egg whites into the batter and whisk to lighten the mixture. ", false },
                    { 71, 0, "Make sure there are no lumps ", false },
                    { 70, 0, "Grab the dry ingredients and whisk them into the yolk mixture. ", false },
                    { 69, 0, "Using an electric mixer fitted with the whisk attachment, whip the egg whites on a healthy medium speed. When they look good and frothy, shake in the remaining 1/2 cup of the granulated sugar a little at a time, while slowly increasing the mixer speed to high. Keep whipping until the egg whites reach sturdy but not firm peaks.", false },
                    { 68, 0, "Brush onto baking pans in place of parchment paper or cooking spray. Keep it in the fridge for a couple of weeks. Perfect Chiffon Cake Heat the oven to 350�F (180�C) and select your pans. For round layers, use two 8x2-inch round cake pans brushed with Pan Goo. For a roulade, use a 13x18-inch rimmed baking sheet lined with a silicone baking mat or parchment paper and brushed with Pan Goo. In a small bowl, whisk together the flour, salt, and baking soda. Set aside.In a large bowl, place the egg yolks and whisk in 1/2 cup of the granulated sugar, the vanilla, oil, and buttermilk. Set aside. ", false },
                    { 66, 0, " The cake can be stored, loosely covered, in the refrigerator for up to 2 days.  ", false },
                    { 44, 0, "\"Key Lime Fillling ", false },
                    { 14, 0, " Squeeze in lemon juice.  ", false },
                    { 42, 0, "Once the upma has crisped up to your desired texture, divide among bowls   ", false },
                    { 19, 0, "saute three tablespoons of oil with garlic for two minutes or so over medium heat ", false },
                    { 18, 0, " deskin fish and cut into bite sized chunks ", false },
                    { 17, 0, "dice garlic ", false },
                    { 16, 0, "\"chop tomatoes roughly ", false },
                    { 15, 0, " Serve.", false },
                    { 13, 0, " Pour the dressing over the chicken and fold together.  ", false },
                    { 12, 0, " Season with salt and pepper.  ", false },
                    { 11, 0, " Gradually whisk in the oil.  ", false },
                    { 43, 0, " serve with chopped cilantro and a fried egg \"", false },
                    { 10, 0, " In a small bowl, whisk together the thyme, mustard and vinegar.  ", false },
                    { 8, 0, " Squeeze the onions to drain any juices. ", false },
                    { 7, 0, " Let sit for 15 minutes.  ", false },
                    { 6, 0, "Sprinkle the onion with salt and toss to coat.  ", false },
                    { 5, 0, "Top with the lemon zest and dill, plus a sprinkle of salt (flaky is nice if you�ve got it), and serve with crusty bread for mopping up the sauce.", false },
                    { 4, 0, "Stir in the remaining 1� tablespoons of butter and 1 tablespoon of horseradish. Taste and increase the horseradish, if you�d like. ", false },
                    { 3, 0, "As soon as that comes to a boil, add the shrimp and another big pinch of salt. Simmer for 2 to 4 minutes, flipping each shrimp halfway through, until pink and firm. ", false },
                    { 2, 0, "Melt 1� tablespoons of butter in a large skillet over medium heat. Stir in 1 tablespoon of horseradish, the lemon water, and a big pinch of salt. ", false },
                    { 1, 0, "Finely grate the zest of 1 lemon and set aside. Now juice both lemons into a liquid measuring cup�you should get about 6 tablespoons. Add enough cold water to reach 1/2 cup of liquid total.", false },
                    { 9, 0, "In a bowl, toss together the onion, chicken, peppadews, artichoke hearts and almonds.  ", false }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 21, 0, "once browned, add salt and pepper, then half glass of white wine and turn up heat. stir carefully till wine is nearly evaporated. ", false },
                    { 20, 0, "add fish, stirring carefully until browned. try not to break it up. ", false },
                    { 23, 0, "when wine is nearly evaporated, reduce heat, add tomatoes and cook for 10 minutes  ", false },
                    { 41, 0, "  cook for 2 to 3 minutes more, stirring only occasionally, so the upma browns and crisps up some more, helped along with the lactose sugar in the yogurt.  ", false },
                    { 40, 0, " Carefully drizzle the yogurt over the upma and stir to combine so the bread and vegetables are completely coated", false },
                    { 39, 0, " Add the peas and cook for another minute.   ", false },
                    { 38, 0, "Add the reserved bread and cashews to the pan with the vegetables and stir everything together, ensuring the onion mixture and cauliflower florets are evenly dispersed with the bread, cook together for about a minute more.   ", false },
                    { 37, 0, "  Add the cauliflower florets and stir, cooking for 3 to 5 minutes longer until they�ve softened and are completely coated with the spice and onion mixture.  ", false },
                    { 36, 0, " raise the heat to medium-high and cook until the onions have softened and turned translucent, about 3 minutes.  ", false },
                    { 35, 0, " Add the onions, chile, salt, turmeric, and curry leaves and stir to combine   ", false },
                    { 34, 0, " Add the mustard seeds, urad dal, and asafetida and shake the pan vigorously to coat everything in the fat. In 20 to 30 seconds, the seeds will burst and the dal will become a deeply golden-brown color.   ", false },
                    { 22, 0, "meantime, heat pot of hot water for pasta, generously salted. ", false },
                    { 33, 0, " Lower the flame to medium and add the second tablespoon of cooking fat to the pan, heating until it�s shimmering.   ", false },
                    { 31, 0, " Add the cubed bread and raw cashews to the pan and toast in oil until crunchy and golden brown, shaking the pan frequently and tossing the bread so it doesn�t burn. This will take 5 to 6 minutes.   ", false },
                    { 30, 0, "\"In a large skillet or wok set over medium-high heat, add 1 tablespoon of the ghee or oil and heat until shimmering.  ", false },
                    { 29, 0, " serve.\"", false },
                    { 28, 0, " stir gently for a minute or two  ", false },
                    { 27, 0, " carefully add the sauce to the pasta over a little heat.  ", false },
                    { 26, 0, "cook pasta al dente. ", false },
                    { 25, 0, "when the tomato juice is released and the sauce is just thickening, turn off heat.  ", false },
                    { 24, 0, " add capers, parsley and olives.  ", false },
                    { 32, 0, " Remove the toasted bread and cashews and set aside  ", false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "Name", "RoleId" },
                values: new object[,]
                {
                    { 3, 0, "Octaaf", 0 },
                    { 1, 0, "Frieda", 0 },
                    { 2, 0, "Alberto", 0 },
                    { 4, 0, "Gert", 0 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedById", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 3, 0, 1, "Fish Pasta can be made with any flakey white fish. Snapper good but its best with fresh striped bass. Be very careful stirring the sauce: the fish should remain intact. The tomatoes should be fresh and cooked al crudo, till the juices are released but they are still a little raw. By adding the fish early on, its flavor infuses the whole sauce, so the tomatoes and fish are no longer separate entities, but fully integrated into the sauce. And the capers and olives reinforce the flavor of the fish with brine. It ends up being a more vibrant version of puttanesca. ", "https://images.food52.com/mlooIQOUxc3VtpQefZvmZiUY1Jw=/1008x672/filters:format(webp)/0afceb53-8c13-4b96-82ba-45235cf98176--fishpastalowres_2417.JPG", "Fish Pasta" },
                    { 4, 0, 2, "South Indian breakfast staple. Upma is a state of mind. The refrain is simple: Carb of choice, toasted in ghee-bloomed spices, then cooked with assorted vegetables and curry leaves and topped with tomato ketchup. In South India, the carb of choice is typically toasted semolina, thickened into a creamy, savory porridge. But it can also be made with bread. ", "https://images.food52.com/38ws8x4bhNB0a9zHq6ZSduhKXCY=/1008x672/filters:format(webp)/eb712a59-16c6-4f57-a6cf-8e523aa97e4e--2021-0312_bread-upma_3x2_mark-weinberg-193.jpg", "My Favorite Bread Upma " },
                    { 5, 0, 2, "Key Lime Cake tastes like summer. Beachy. Floral. Have you ever rubbed your fingers across a wicker armrest and gotten lost in the undulating cords like waves?  ", "https://images.food52.com/NL2-zUmt3I_hFG3qnUfdKY6-bZQ=/1008x672/filters:format(webp)/7247d84f-cd2f-49ab-af78-4714ce5b0f92--Fruit_Cake_Key_Lime_Cake.jpg", "Key Lime Cake" },
                    { 1, 0, 3, "A simple, scampi-inspired dinner that needs neither a lot of time, nor a lot of ingredients. The key is to swiftly simmer the shrimp and to rely on extrovert ingredients for seasoning. Lemon juice and lemon zest deliver loads of sunny acidity. So much so that we�re also using water, not stock, to stretch the brightness, and to ensure that there�s enough sauce for bread-sopping.", "https://images.food52.com/_51_B8XLkaL7wou2THrl1WXuadA=/1008x672/filters:format(webp)/3871c07e-9765-4a8d-9fdd-2f996094b105--2021-0518_speedy-shrimp_3x2_james-ransom-031.jpg", "Speedy Shrimp With Horseradish�Butter" },
                    { 2, 0, 3, "If you like a good mayonnaise-based chicken salad, but one with more candid flavors, you should try this recipe! With a glass of white wine it would feel like the perfect weekend luch.", "https://images.food52.com/OOqBZEjQhcOLodgRlnXoOfVI5RY=/1008x672/filters:format(webp)/d8634211-6145-4329-81ca-711c45e4750a--2017-0427_chicken-salad_james-ransom-297.jpg", "Chicken Salad" }
                });
            migrationBuilder.InsertData(
            table: "IngredientRecipe",
            columns: new[] { "IngredientsId", "RecipesId" },
            values: new object[,]
            {
                {1,1},
                {2,1},
                {3,1},
                {4,1},
                {5,1}
            });
            migrationBuilder.InsertData(
            table: "RecipeStep",
            columns: new[] { "RecipesId", "StepsId" },
            values: new object[,]
            {
                    {1,1},
                    {1,2},
                    {1,3},
                    {1,4},
                    {1,5},

                    {2,6},
                    {2,7},
                    {2,8},
                    {2,9},
                    {2,10},
                    {2,11},
                    {2,12},
                    {2,13},
                    {2,14},
                    {2,15},

                    {3,16},
                    {3,17},
                    {3,18},
                    {3,19},
                    {3,20},
                    {3,21},
                    {3,22},
                    {3,23},
                    {3,24},
                    {3,25},
                    {3,26},
                    {3,27},
                    {3,28},

                    {4,30},
                    {4,31},
                    {4,32},
                    {4,33},
                    {4,34},
                    {4,35},
                    {4,36},
                    {4,37},
                    {4,38},
                    {4,39},
                    {4,40},
                    {4,41},
                    {4,42},
                    {4,43},

                    {5,44},
                    {5,45},
                    {5,46},
                    {5,47},
                    {5,48},
                    {5,49},
                    {5,50},
                    {5,51},
                    {5,52},
                    {5,53},
                    {5,54},
                    {5,55},
                    {5,56},
                    {5,57},
                    {5,58},
                    {5,59},
                    {5,60},
                    {5,61},
                    {5,62},
                    {5,63},
                    {5,64},
                    {5,65},
            });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientRecipe_RecipesId",
                table: "IngredientRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatedById",
                table: "Recipes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStep_StepsId",
                table: "RecipeStep",
                column: "StepsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompletedRecipes_CompletedRecipesId",
                table: "UserCompletedRecipes",
                column: "CompletedRecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouriteRecipes_FavouritedById",
                table: "UserFavouriteRecipes",
                column: "FavouritedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientRecipe");

            migrationBuilder.DropTable(
                name: "RecipeRatings");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "UserCompletedRecipes");

            migrationBuilder.DropTable(
                name: "UserFavouriteRecipes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}