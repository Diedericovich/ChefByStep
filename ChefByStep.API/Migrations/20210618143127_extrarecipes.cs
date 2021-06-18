using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefByStep.API.Migrations
{
    public partial class extrarecipes : Migration
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
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
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
                    { 1, "lemon", 0.0 },
                    { 70, "cinnamon", 0.0 },
                    { 69, "confectioners' sugar", 0.0 },
                    { 68, "almond flour", 0.0 },
                    { 67, "pine nuts", 0.0 },
                    { 66, "fresh oregano leaves", 0.0 },
                    { 65, "torn basil leaves", 0.0 },
                    { 64, "penne pasta", 0.0 },
                    { 63, "large chopped red onion", 0.0 },
                    { 62, "large sliced summer squash", 0.0 },
                    { 71, "cocoa powder", 0.0 },
                    { 61, "ear corn", 0.0 },
                    { 59, "buttermilk", 0.0 },
                    { 58, "pure vanilla extract", 0.0 },
                    { 57, "egg", 0.0 },
                    { 56, "baking soda", 0.0 },
                    { 55, "cake flour", 0.0 },
                    { 54, "all-purpose flour", 0.0 },
                    { 53, "egg white", 0.0 },
                    { 52, "coarsely crumbled graham crackers", 0.0 },
                    { 51, "granulated sugar", 0.0 },
                    { 60, "cherry tomatoe", 0.0 },
                    { 72, "cream of tartar", 0.0 },
                    { 73, "mexican chocolate", 0.0 },
                    { 74, "heavy cream", 0.0 },
                    { 96, "lemon curd", 0.0 },
                    { 94, "vanilla extract", 0.0 },
                    { 93, "strawberry pur�e", 0.0 },
                    { 92, "whole milk", 0.0 },
                    { 91, "fine sea salt", 0.0 },
                    { 90, "baking powder", 0.0 },
                    { 89, "sea salt", 0.0 },
                    { 88, "lemon juice", 0.0 },
                    { 87, "chopped strawberries", 0.0 },
                    { 86, "zest of lemon", 0.0 },
                    { 85, "curly pasta", 0.0 },
                    { 84, "dash pepper", 0.0 },
                    { 83, "dash sea salt", 0.0 },
                    { 82, "basil leaves", 0.0 },
                    { 81, "tomatoe", 0.0 },
                    { 80, "brie", 0.0 },
                    { 79, "dill sprig", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 78, "dash sugar", 0.0 },
                    { 77, "orzo", 0.0 },
                    { 76, "white pepper", 0.0 },
                    { 75, "chicken stock", 0.0 },
                    { 50, "cream cheese", 0.0 },
                    { 49, "cornstarch", 0.0 },
                    { 95, "water", 0.0 },
                    { 47, "sweetened condensed milk", 0.0 },
                    { 21, "garlic", 0.0 },
                    { 20, "olive oil", 0.0 },
                    { 19, "black pepper", 0.0 },
                    { 18, "extra virgin olive oil", 0.0 },
                    { 17, "sherry vinegar", 0.0 },
                    { 16, "whole-grain mustard", 0.0 },
                    { 15, "chopped thyme", 0.0 },
                    { 48, "coarse salt", 0.0 },
                    { 13, "marinated artichoke hearts", 0.0 },
                    { 22, "olive", 0.0 },
                    { 12, "peppadews peppers", 0.0 },
                    { 10, "salt", 0.0 },
                    { 9, "sliced red onion", 0.0 },
                    { 8, "hot pasta", 0.0 },
                    { 7, "crusty bread", 0.0 },
                    { 6, "chopped dill", 0.0 },
                    { 5, "shrimp", 0.0 },
                    { 4, "kosher salt", 0.0 },
                    { 3, "prepared horseradish", 0.0 },
                    { 2, "unsalted butter", 0.0 },
                    { 11, "roasted chicken", 0.0 },
                    { 23, "white fish", 0.0 },
                    { 14, "chopped smoked almonds", 0.0 },
                    { 25, "white wine", 0.0 },
                    { 46, "large egg yolk", 0.0 },
                    { 24, "salted capers", 0.0 },
                    { 45, "key lime juice", 0.0 },
                    { 44, "fried egg", 0.0 },
                    { 43, "roughly chopped cilantro and stems and leaves", 0.0 },
                    { 42, "plain full-fat yogurt", 0.0 },
                    { 41, "frozen peas", 0.0 },
                    { 39, "ground turmeric", 0.0 },
                    { 38, "curry leaves", 0.0 },
                    { 37, "chopped green chile", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 40, "small cauliflower florets", 0.0 },
                    { 35, "asafetida", 0.0 },
                    { 26, "chopped tomatoe", 0.0 },
                    { 36, "shallot", 0.0 },
                    { 28, "chopped parsley", 0.0 },
                    { 29, "salt and pepper", 0.0 },
                    { 30, "neutral oil", 0.0 },
                    { 27, "spaghetti", 0.0 },
                    { 32, "raw cashews", 0.0 },
                    { 33, "black mustard seeds", 0.0 },
                    { 34, "urad dal", 0.0 },
                    { 31, "sourdough bread", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 59, 0, "Cook pasta till tender but slightly al dente. Drain and return to pot, reserving a small amount of the cooking liquid", false },
                    { 66, 0, "Spoon the mixture into a pastry bag or a ziplock. If using a zip-top bag, cut off a 1/4-inch tip from the corner. Pipe the mixture in a spiral to fill each 1.5-inch circle on the parchment paper. Allow the unbaked cookies to sit out for 30 minutes, until the cookies have a matte texture and are no longer sticky", false },
                    { 65, 0, "Using a silicone spatula, fold the almond and sugar mixture into the egg whites one-third at a time. You do not have to be gentle, instead use brisk strokes to fold the mixture together completely, this will help reduce the air in the meringue and keep the macaroons from being too puffy", false },
                    { 64, 0, "Put egg whites in stainless steel bowl and beat on low with a hand mixer until frothy. Add salt and cream of tartar, and slowly mix in the granulated sugar. Once the sugar is all incorporated, increase mixer speed to medium and beat until meringue forms stiff peaks.The meringue should look glossy and remain in place when the bowl is tipped on its side", false },
                    { 63, 0, "Pulse the almond flour, confectioners' sugar, cinnamon, and cocoa in a food processor until it is a finely mixed powder. Sift into a large bowl", false },
                    { 62, 0, "Line two cookie pans with parchment paper and trace 1.5 inch circles on the paper, keeping the circles about one inch apart. Preheat your oven to 300� F", false },
                    { 61, 0, "Measure egg whites and allow to sit at room temperature for 24 hours in a covered bowl. Aging the whites helps them thin and will create a better textured macaron", false },
                    { 60, 0, "Add the roast vegetables, along with remaining 1 tbsp olive oil and a tiny bit of the cooking liquid, to the pasta. Toss in the basil and oregano. Top with toasted pine nuts if desired", false },
                    { 58, 0, "If you're using the pine nuts, now is the time to toast them gently in a large frying pan set over medium heat. Stir them continually and remove them as soon as they�re becoming golden", false },
                    { 48, 0, "Make the lime soaker by stirring the sugar into the juice until it's dissolved. Set aside", false },
                    { 56, 0, "Toss vegetables and garlic with olive oil and season well with salt and pepper, but keep the corn separate", false },
                    { 55, 0, "Preheat oven to 450 degrees. Set a pot of boiled water on the stove to boil", false },
                    { 54, 0, "Serve at cool room temperature", false },
                    { 53, 0, "Gently brown the meringue with a kitchen torch", false },
                    { 52, 0, "Remove the skewer from the chilled cake and dollop the meringue on top, piling it high", false },
                    { 51, 0, "Transfer the bowl to the mixer and whip on high speed until firm peaks form, about 5 minutes", false },
                    { 50, 0, "To make a Swiss meringue, place the egg whites and sugar in the heatproof bowl of an electric mixer. Set the bowl over a pan of gently simmering water and heat, whisking occasionally, until the sugar is dissolved and the mixture reads 160�F (71�C) on a thermometer", false },
                    { 49, 0, "Use a serrated knife to trim the domes from the tops of the cakes and slice each in half horizontally to create four layers. Place one layer on a serving platter and brush the top with about 2 tablespoons of the soaker. Stir the lime filling briefly to loosen it. Then use a small offset spatula to spread about one-third of the filling over the cake, getting it right up to the edge. Scatter a third of the graham cracker crumbs over the filling and top with another layer of cake. Continue assembling in this manner with the remaining filling and cake layers. Slide a long wooden skewer vertically through the center of the cake if it feels wobbly. Chill the assembled cake until you are ready to make the meringue", false },
                    { 57, 0, "Divide all vegetables save corn onto baking sheets and start roasting them for 35 to 40 minutes. Fifteen minutes before the end of the roasting process, add the corn which cooks a little faster than the other vegetables", false },
                    { 67, 0, "Bake for 12 to 15 minutes. Allow to cool and then peel very gently off the parchment paper", false },
                    { 89, 0, "Top with a lemon slice and a strawberry half", false },
                    { 69, 0, "When the cookies and filling are cool, spread or pipe the ganache on the flat side of one macaron and create a sandwich with a second one", false },
                    { 47, 0, "Place a piece of plastic film or wax paper directly on the surface of the custard to prevent a skin from forming and refrigerate until firm, at least 4 hours, preferably overnight", false },
                    { 88, 0, "Gently fold the strawberry pur�e into the frosting, drizzling it in about a third at a time and folding it a few times but not incorporating it fully. Use an ice cream scoop to transfer swirled frosting on top of each cupcake and use a small offset spatula to swirl it", false },
                    { 87, 0, "With the mixer running on medium speed gradually add the butter a few tablespoons at a time mixing to fully combine before adding more. This will take several minutes and the mixture will look light and fluffy. Remove the bowl from the mixer and mix in the lemon curd with a silicone spatula. I use sort of a folding motion to incorporate it, because it helps to deflate the frosting a bit and make it smoother.", false },
                    { 86, 0, "Cook the sugar mixture until it reads 235�F/115�C. Begin whipping the egg whites on medium speed raising to medium-high speed once the mixture looks frothy. When the sugar mixture reaches 240�F remove the pot from the heat and gradually add the hot sugar syrup to the mixer in a slow steady stream. Continue whipping until the meringue has reached full volume and the bowl is no longer warm to the touch for 5 to 6 minutes", false },
                    { 85, 0, "Make the lemon curd buttercream: Place the egg whites and cream of tartar in the bowl of an electric mixer fitted with the whisk attachment. In a medium saucepan combine the sugar and water and bring to a boil over medium heat. Stir until the mixture begins to bubble but as soon as it begins to boil, stop stirring. If necessary dip a brush in cool water to brush away granules of sugar that appear on the side of the pot", false },
                    { 84, 0, "Bake the cupcakes until a toothpick inserted into the center comes out clean (or with just a few moist crumbs) in 17 to 20 minutes. Cool completely", false },
                    { 83, 0, "Scoop the batter into the prepared pan using an ice cream scoop filling each cavity three-quarters full", false },
                    { 82, 0, "In a large liquid measuring cup whisk the egg whites, milk, strawberry pur�e, vanilla, and lemon zest to combine. Add this mixture in two equal additions mixing on medium speed until the batter is smooth and combined and scraping well after each addition. If desired tint the batter deeper pink with food coloring", false }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 81, 0, "In the bowl of an electric mixer fitted with the paddle attachment mix the flour, sugar, baking powder, baking soda and salt to combine. Drop half tablespoon-size portions of butter into the bowl and mix on low speed until the butter is distributed and the mixture looks a bit crumbly", false },
                    { 68, 0, "Make ganache while the cookies cool. Melt chocolate in double boiler. Whisk in heavy cream and butter and stir mixture over gently boiling water until it is smooth and shiny", false },
                    { 80, 0, "Make the cake: Heat the oven to 350�F/175�C. Line two 12-cup muffin tins with cupcake liners", false },
                    { 78, 0, "Make the pur�e: In a small bowl and rub the granulated sugar and lemon zest together. In a medium pot toss the strawberries and lemon juice to combine. Add the sugar and salt tossing everything to combine. Cook over medium heat stirring frequently until the mixture becomes saucy and the strawberries start to break down in 8 to 10 minutes", false },
                    { 77, 0, "bring a large pot of heavily salted water to a boil and cook the pasta until just al dente. Strain it and tip it into the bowl with the sauce. Fold everything together until it is well combined, the Brie has begun to melt, and the pasta is slicked with cheese and tomato goodness. Serve immediately with a big green salad", false },
                    { 76, 0, "Once the Brie is firm enough, cut it into 1/2-inch cubes and add these to the bowl. Gently fold to combine the cheese with the rest of the ingredients. Cover the bowl and let it sit at room temperature for at least 2 to 8 hours -- the longer the better", false },
                    { 75, 0, "Roughly chop the tomatoes and put them in a large serving bowl. Finely chop the garlic and add it to the bowl. Chiffonade or roughly chop the basil and add that to the bowl too. Pour in the olive oil and add a generous amount of salt and pepper. Gently stir everything together", false },
                    { 74, 0, "Put the Brie in the freezer for about 20 minutes to firm up a little. This will make it easier to cut when the time comes", false },
                    { 73, 0, "ladle into warm bowls and garnish with white pepper, chopped dill, a dill sprig, and sliced lemon", false },
                    { 72, 0, "Beat in the egg yolks and lemon juice. Pour 2 cups of reserved hot stock slowly into the lemon and egg mixture, whisking continuously until all is incorporated. Return soup to medium-low heat and whisk in lemon-egg mixture. Add chicken stock back into the soup and simmer until thickened slightly, about 20 minutes", false },
                    { 71, 0, "beat egg whites in a medium-size bowl until soft peaks form", false },
                    { 70, 0, "bring stock to a boil in a large saucepan. Lower heat to a simmer and add salt, pepper, and orzo. Cook until al dente, about 8 minutes. Remove from heat. Set aside 2 cups of stock", false },
                    { 79, 0, "Use an immersion blender to pur�e the mixture in the pot. Continue to cook the mixture over medium-low heat stirring often until it reduces to 2/3 cup in 10 to 15 minutes more. Cool completely before using. This can be done up to 2 days ahead and refrigerated", false },
                    { 46, 0, "Add the cream cheese, one or two pieces at a time, and stir until all of it has been incorporated", false },
                    { 23, 0, "meantime heat pot of hot water for pasta, generously salted", false },
                    { 44, 0, "Reduce the temperature a bit as the mixture thickens dramatically and keep whisking as it boils for 2 minutes", false },
                    { 19, 0, "saute three tablespoons of oil with garlic for two minutes over medium heat", false },
                    { 18, 0, "deskin fish and cut into bite sized chunks", false },
                    { 17, 0, "dice garlic", false },
                    { 16, 0, "chop tomatoes roughly", false },
                    { 15, 0, "Pour the dressing over the chicken and fold together. Squeeze in lemon juice", false },
                    { 14, 0, "In a small bowl, whisk together the thyme, mustard and vinegar. Gradually whisk in the oil. Season with salt and pepper", false },
                    { 13, 0, "In a bowl toss together the onion, chicken, peppadews, artichoke hearts and almonds", false },
                    { 12, 0, "Squeeze the onions to drain any juices", false },
                    { 11, 0, "Let sit for 15 minutes", false },
                    { 10, 0, "Sprinkle the onion with salt and toss to coat", false },
                    { 9, 0, "serve with crusty bread for mopping up the sauce", false },
                    { 8, 0, "Top with the lemon zest and dill, plus a sprinkle of salt", false },
                    { 7, 0, "Stir in the remaining 1 and a half tablespoons of butter and 1 tablespoon of horseradish", false },
                    { 6, 0, "As soon as that comes to a boil, add the shrimp and another big pinch of salt. Simmer for 2 to 4 minutes flipping each shrimp halfway through, until pink and firm", false },
                    { 5, 0, "Stir in 1 tablespoon of horseradish, the lemon water, and a big pinch of salt", false },
                    { 4, 0, "Melt 1 and a half tablespoons of butter in a large skillet over medium heat", false },
                    { 3, 0, "Add enough cold water to reach half a cup of liquid total", false },
                    { 2, 0, "Now juice both lemons into about 6 tablespoons", false },
                    { 1, 0, " Finely grate the zest of 1 lemon and set aside", false },
                    { 45, 0, "Strain the mixture through the fine-mesh sieve into the bowl and stir gently with a rubber spatula to let off some of the steam", false },
                    { 21, 0, "once browned, add salt and pepper, then half glass of white wine and turn up heat", false },
                    { 20, 0, "add fish, stirring carefully until browned", false },
                    { 24, 0, "when wine is nearly evaporated, reduce heat, add tomatoes and cook for 10 minutes", false },
                    { 43, 0, "Do yourself a favor and make the filling the night before you plan to assemble this cake. Have a fine-mesh sieve and a large bowl on standby near the stove. Squeeze every last drop of juice from the limes and combine in a small saucepan with the yolks, condensed milk, salt and cornstarch. Whisk everything together until it's nice and smooth and then set over medium heat. Dont stop whisking", false },
                    { 42, 0, "Add chopped cilantro and a fried egg", false },
                    { 41, 0, "Once the upma has crisped up to your desired texture, divide among bowls", false }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 40, 0, "Cook for 2 to 3 minutes more, stirring only occasionally, so the upma browns and crisps up some more, helped along with the lactose sugar in the yogurt", false },
                    { 39, 0, "Carefully drizzle the yogurt over the upma and stir to combine so the bread and vegetables are completely coated", false },
                    { 38, 0, "Add the peas and cook for another minute", false },
                    { 37, 0, "Add the reserved bread and cashews to the pan with the vegetables and stir everything together, ensuring the onion mixture and cauliflower florets are evenly dispersed with the bread. Cook together for about a minute more", false },
                    { 22, 0, "stir carefully till wine is nearly evaporated", false },
                    { 35, 0, "raise the heat to medium-high and cook until the onions have softened and turned translucent", false },
                    { 36, 0, "Add the cauliflower florets and stir, cooking for 3 to 5 minutes longer until they have softened and are completely coated with the spice and onion mixture", false },
                    { 33, 0, "Add the mustard seeds, urad dal and asafetida and shake the pan vigorously to coat everything in the fat. In 20 to 30 seconds the seeds will burst and the dal will become a deeply golden-brown color", false },
                    { 32, 0, "Lower the flame to medium and add the second tablespoon of cooking fat to the pan, heating until its shimmering", false },
                    { 31, 0, "Remove the toasted bread and cashews and set aside", false },
                    { 30, 0, "Add the cubed bread and raw cashews to the pan and toast in oil until crunchy and golden brown, shaking the pan frequently and tossing the bread so it doesn't burn. This will take 5 to 6 minutes", false },
                    { 29, 0, "In a wok set over medium-high heat, add 1 tablespoon of oil and heat until shimmering", false },
                    { 28, 0, "carefully add the sauce to the pasta over a little heat and stir gently for a minute or two", false },
                    { 27, 0, "cook pasta al dente", false },
                    { 26, 0, "when the tomato juice is released and the sauce is just thickening, turn off heat", false },
                    { 25, 0, "add capers, parsley and olives", false },
                    { 34, 0, "Add the onions, chile, salt, turmeric, curry leaves and stir to combine", false }
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
                    { 6, 0, 1, "Think of this recipe as summer in a bowl. The sweet corn, bursting cherry tomatoes, and tender zucchini lighten up a savory, satisfying bowl of pasta. Proof that meatless dishes can be quick, easy, and a joy to eat", "https://images.food52.com/9-Z62AhfnO7vECg7gARyZVGIW9A=/1008x672/filters:format(webp)/fc3db569-3b62-4126-a92c-9598b7fdb120--food52_07-24-12-7723.jpg", "Penne with Sweet Summer Vegetables, Pine Nuts and�Herbs" },
                    { 7, 0, 1, "In the Mexican city of Oaxaca, almonds are ground into a rough paste with cacao, cinnamon, and sugar and hardened into thin fingers of chocolate. The distinctive mixture is used in the city's famous mole sauces and melted into rich hot chocolate which the Oaxacans drink more regularly than coffee. The warm, spicy smell of toasted cacao, cinnamon and almonds fills the city, as crowded storefront grinders are endlessly turning and the mercado stalls are crowded with vendors selling secret family recipes. Ideal for inspiration and make macarons with the same flavors", "https://images.food52.com/fLevsOXvNogpjdYZFItNUwPVf-4=/1008x672/filters:format(webp)/3e4baffa-29dc-4e2e-aa6a-2f42f1f4414a--033010F_869.JPG", "Oaxacan Cinnamon Chocolate Macarons" },
                    { 9, 0, 1, "Alot of people make a summer pasta alla Caprese like this: the pasta�raw garlic or onion, tomatoes, basil, olive oil and fresh mozzarella. This recipe replaces the mozarella with brie. A bold but satisfying choice! A fine Brie is just as delicious at room temperature smeared on crusty bread as it is warm, oozing out of flaky pastry. And it's REALLY good folded into a fresh tomatoey, garlicky sauce for pasta. Put aside any residual anti-Brie sentiments and give this one a shot before tomatoes disappear for the year. You won't regret it", "https://images.food52.com/i8P83CvSSFTTVWinAuWJuXqAHFo=/1008x672/filters:format(webp)/547d4b4b-dfa0-494a-9415-04a97a103f05--20120804_food52_08-20-12-1466.jpg", "Pasta with Tomatoes, Garlic, Basil & Brie" },
                    { 1, 0, 2, "A simple scampi-inspired dinner that needs neither a lot of time nor a lot of ingredients. The key is to swiftly simmer the shrimp and to rely on extrovert ingredients for seasoning. Lemon juice and lemon zest deliver loads of sunny acidity. So much so that we are also using water, not stock, to stretch the brightness, and to ensure that there is enough sauce for bread-sopping", "https://images.food52.com/_51_B8XLkaL7wou2THrl1WXuadA=/1008x672/filters:format(webp)/3871c07e-9765-4a8d-9fdd-2f996094b105--2021-0518_speedy-shrimp_3x2_james-ransom-031.jpg", "Speedy Shrimp With Horseradish�Butter" },
                    { 2, 0, 2, "If you like a good mayonnaise-based chicken salad, but one with more candid flavors, you should try this recipe! With a glass of white wine it feels like the perfect weekend lunch", "https://images.food52.com/OOqBZEjQhcOLodgRlnXoOfVI5RY=/1008x672/filters:format(webp)/d8634211-6145-4329-81ca-711c45e4750a--2017-0427_chicken-salad_james-ransom-297.jpg", "Chicken Salad" },
                    { 4, 0, 2, "People know upma as a South Indian breakfast staple, but its more. Upma is a state of mind. The refrain is simple: Carb of choice, toasted in ghee-bloomed spices, then cooked with assorted vegetables and curry leaves and topped with tomato ketchup. In South India the carb of choice is typically toasted semolina, thickened into a creamy, savory porridge. But it can also be made with bread. Bread upma can be made in two contrasting ways. This version captures the best of both", "https://images.food52.com/38ws8x4bhNB0a9zHq6ZSduhKXCY=/1008x672/filters:format(webp)/eb712a59-16c6-4f57-a6cf-8e523aa97e4e--2021-0312_bread-upma_3x2_mark-weinberg-193.jpg", "My Favorite Bread Upma" },
                    { 8, 0, 3, "The name of this classic Greek soup emulsion of lemon and eggs comes from its two main ingredients: egg (avgo) and lemon juice (lemono). The key to this soup is tempering the egg and lemon mixture by slowly adding hot stock and then whisking constantly to prevent the eggs from curdling. You then stir the mixture into the soup, which becomes all velvety lush lemony goodness. A Greek salad and warm pita bread are wonderful accompaniments to this soup", "https://images.food52.com/Y4T3Uk-cKn799bjhWySmQJ9YxIA=/1008x672/filters:format(webp)/2311e33a-47e9-4504-99e4-dd3d61337348--2017-1212_egglands-best-sponsored_greek-soup-holiday_3x2_mark-weinberg_0128.jpg", "Greek Lemon Soup - Avgolemono" },
                    { 10, 0, 3, "This is variant on the boxed strawberry cake but made with fresh strawberries. It takes a bit of time to reduce the strawberry mixture to a thick, jammy pur�e, but it's worth it, since it gets used both in the cake and also the frosting to create a beautiful - and delicious - swirl effect. Its best decorated with lemon wedges and/or strawberries but you can never miss with sprinkles", "https://images.food52.com/TRW26JcClLEecmYmv3tOpia1DXY=/1008x672/filters:format(webp)/157f3d99-a272-4002-9353-867d70731001--2021-0512_strawberry-lemonade-cupcakes_4x5_julia-gartland_063.jpg", "Strawberry Lemonade Cupcakes" },
                    { 3, 0, 4, "Fish Pasta can be made with any flakey white fish. Snapper good but its best with fresh striped bass. Be very careful stirring the sauce: the fish should remain intact. The tomatoes should be fresh and cooked al crudo, till the juices are released but they are still a little raw. By adding the fish early on, its flavor infuses the whole sauce, so the tomatoes and fish are no longer separate entities, but fully integrated into the sauce. And the capers and olives reinforce the flavor of the fish with brine", "https://images.food52.com/mlooIQOUxc3VtpQefZvmZiUY1Jw=/1008x672/filters:format(webp)/0afceb53-8c13-4b96-82ba-45235cf98176--fishpastalowres_2417.JPG", "Fish Pasta" },
                    { 5, 0, 4, "Key Lime Cake tastes like summer. Beachy. Floral. Have you ever rubbed your fingers across a wicker armrest and gotten lost in the undulating cords like waves", "https://images.food52.com/NL2-zUmt3I_hFG3qnUfdKY6-bZQ=/1008x672/filters:format(webp)/7247d84f-cd2f-49ab-af78-4714ce5b0f92--Fruit_Cake_Key_Lime_Cake.jpg", "Key Lime Cake" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 65, "2", 60, 6 },
                    { 116, "1/2 cup", 92, 10 },
                    { 115, "5", 53, 10 },
                    { 114, "1 1/3 cup", 2, 10 },
                    { 113, "1/2 teaspoon", 91, 10 },
                    { 112, "1/2 teaspoon", 56, 10 },
                    { 111, "1 teaspoon", 90, 10 },
                    { 110, "1 2/3 cups", 54, 10 },
                    { 109, "1 pinch", 89, 10 },
                    { 108, "1/4 cup", 88, 10 },
                    { 107, "1 1/2 pounds", 87, 10 },
                    { 106, "1", 86, 10 },
                    { 105, "2 cups", 51, 10 },
                    { 96, "1", 79, 8 },
                    { 95, "1/4 cup", 6, 8 },
                    { 94, "3", 1, 8 },
                    { 93, "4", 57, 8 },
                    { 92, "1", 78, 8 },
                    { 91, "1 1/2 cup", 77, 8 },
                    { 90, "1/2 teaspoon", 76, 8 },
                    { 89, "1 1/2 teaspoons", 4, 8 },
                    { 88, "8 cups", 75, 8 },
                    { 46, "2", 44, 4 },
                    { 45, "1/4 cup", 43, 4 },
                    { 44, "1/4 cup", 42, 4 },
                    { 43, "1/4 cup", 41, 4 },
                    { 42, "1 cup", 40, 4 },
                    { 41, "1/2 teaspoon", 39, 4 },
                    { 117, "1/3 cup", 93, 10 },
                    { 40, "6", 38, 4 },
                    { 118, "1 teaspoon", 94, 10 },
                    { 120, "1/4 cup", 95, 10 },
                    { 62, "6", 57, 5 },
                    { 61, "1/4 teaspoon", 56, 5 },
                    { 60, "1/2 teaspoon", 48, 5 },
                    { 59, "1 1/2 cups", 55, 5 },
                    { 58, "1/3 cup", 54, 5 },
                    { 57, "1/4 cup", 30, 5 },
                    { 56, "4", 53, 5 },
                    { 55, "1/2 cup", 52, 5 },
                    { 54, "1/4 cup", 45, 5 },
                    { 53, "2 1/4 cup", 51, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 52, "1 cup", 50, 5 },
                    { 51, "2 tablespoons", 49, 5 },
                    { 50, "1 pinch", 48, 5 },
                    { 49, "14 ounce", 47, 5 },
                    { 48, "4", 46, 5 },
                    { 47, "1/2 cup", 45, 5 },
                    { 30, "", 29, 3 },
                    { 29, "2 tablespoon", 28, 3 },
                    { 28, "1 packet", 27, 3 },
                    { 27, "4", 26, 3 },
                    { 26, "1/2 glass", 25, 3 },
                    { 25, "1 tablespoon", 24, 3 },
                    { 24, "1 pound", 23, 3 },
                    { 23, "12", 22, 3 },
                    { 22, "2 cloves", 21, 3 },
                    { 21, "3 tablespoons", 20, 3 },
                    { 121, "1/2 cup", 96, 10 },
                    { 119, "1 pinch", 72, 10 },
                    { 63, "1 tablespoon", 58, 5 },
                    { 39, "1 teaspoon", 4, 4 },
                    { 37, "1", 36, 4 },
                    { 101, "3/4 cup", 20, 9 },
                    { 100, "1/2 cup", 82, 9 },
                    { 99, "2 cloves", 21, 9 },
                    { 98, "4", 81, 9 },
                    { 97, "3/4 pound", 80, 9 },
                    { 87, "2 tablespoons", 74, 7 },
                    { 86, "1 tablespoon", 2, 7 },
                    { 85, "1 1/4 cup", 73, 7 },
                    { 84, "1 pinch", 72, 7 },
                    { 83, "1 pinch", 10, 7 },
                    { 82, "3 teaspoons", 71, 7 },
                    { 81, "2 teaspoons", 70, 7 },
                    { 80, "1 1/2 cup", 69, 7 },
                    { 79, "1 cup", 68, 7 },
                    { 78, "3/4 cup", 51, 7 },
                    { 77, "4", 53, 7 },
                    { 76, "1/4 cup", 67, 6 },
                    { 75, "", 19, 6 },
                    { 74, "", 48, 6 },
                    { 73, "1 tablespoon", 66, 6 },
                    { 72, "1/3 cup", 65, 6 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 71, "8 ounces", 64, 6 },
                    { 70, "4 tablespoons", 20, 6 },
                    { 69, "2 cloves", 21, 6 },
                    { 68, "1", 63, 6 },
                    { 67, "2", 62, 6 },
                    { 66, "2", 61, 6 },
                    { 102, "1", 83, 9 },
                    { 38, "1", 37, 4 },
                    { 103, "1", 84, 9 },
                    { 1, "2", 1, 1 },
                    { 36, "1 pinch", 35, 4 },
                    { 35, "1/2 teaspoon", 34, 4 },
                    { 34, "1/2 teaspoon", 33, 4 },
                    { 33, "1/4 cup", 32, 4 },
                    { 32, "4 slices", 31, 4 },
                    { 31, "2 tablespoons", 30, 4 },
                    { 20, "", 19, 2 },
                    { 19, "1/4 cup", 18, 2 },
                    { 18, "1", 1, 2 },
                    { 17, "1 tablespoon", 17, 2 },
                    { 16, "1 tablespoon", 16, 2 },
                    { 15, "2 teaspoons", 15, 2 },
                    { 104, "1 pound", 85, 9 },
                    { 14, "1/4 cup", 14, 2 },
                    { 12, "3 tablespoons", 12, 2 },
                    { 11, "4 cups", 11, 2 },
                    { 10, "", 10, 2 },
                    { 9, "1/4 cup", 9, 2 },
                    { 8, "", 8, 1 },
                    { 7, "", 7, 1 },
                    { 6, "1 handful", 6, 1 },
                    { 5, "1 pound", 5, 1 },
                    { 4, "", 4, 1 },
                    { 3, "2 tablespoons", 3, 1 },
                    { 2, "3 tablespoons", 2, 1 },
                    { 13, "1 cup", 13, 2 },
                    { 64, "1/2 cup", 59, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecipeRatings",
                columns: new[] { "RecipeId", "UserId", "Comment", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Verrrrrrrrry sweet", 10.0 },
                    { 2, 1, "Awful sweet", 10.0 }
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
                    {1,6},
                    {1,7},
                    {1,8},
                    {1,9},

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

                    {4,29},
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

                    {5,43},
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

                    {6,55},
                    {6,56},
                    {6,57},
                    {6,58},
                    {6,59},
                    {6,60},

                    {7,61},
                    {7,62},
                    {7,63},
                    {7,64},
                    {7,65},
                    {7,66},
                    {7,67},
                    {7,68},
                    {7,69},

                    {8,70},
                    {8,71},
                    {8,72},
                    {8,73},

                    {9,74},
                    {9,75},
                    {9,76},
                    {9,77},

                    {10,78},
                    {10,79},
                    {10,80},
                    {10,81},
                    {10,82},
                    {10,83},
                    {10,84},
                    {10,85},
                    {10,86},
                    {10,87},
                    {10,88},
                    {10,89},
        });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

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
                name: "RecipeIngredients");

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
