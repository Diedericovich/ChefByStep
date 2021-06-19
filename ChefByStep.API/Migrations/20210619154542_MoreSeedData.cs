using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefByStep.API.Migrations
{
    public partial class MoreSeedData : Migration
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
                    { 118, "dill pickles", 0.0 },
                    { 119, "iceberg lettuce", 0.0 },
                    { 120, "red pepper flakes", 0.0 },
                    { 121, "herbes de provence", 0.0 },
                    { 122, "red wine", 0.0 },
                    { 123, "worcestershire sauce", 0.0 },
                    { 124, "cremini mushrooms", 0.0 },
                    { 125, "carrots", 0.0 },
                    { 126, "mashed potatoes", 0.0 },
                    { 127, "panko bread crumbs", 0.0 },
                    { 128, "parsley", 0.0 },
                    { 129, "brown sugar", 0.0 },
                    { 130, "soy sauce", 0.0 },
                    { 131, "sparkling dessert wine", 0.0 },
                    { 132, "sesame oil", 0.0 },
                    { 133, "green onions", 0.0 },
                    { 134, "beef tenderloin", 0.0 },
                    { 135, "cucumber", 0.0 },
                    { 136, "gochugaru", 0.0 },
                    { 117, "potato chips", 0.0 },
                    { 137, "sugar", 0.0 },
                    { 116, "hamburger buns", 0.0 },
                    { 114, "cheddar", 0.0 },
                    { 95, "water", 0.0 },
                    { 96, "lemon curd", 0.0 },
                    { 97, "red beans", 0.0 },
                    { 98, "bay leaf", 0.0 },
                    { 99, "onion", 0.0 },
                    { 100, "chile", 0.0 },
                    { 101, "coriander seed", 0.0 },
                    { 102, "beef short ribs", 0.0 },
                    { 103, "yellow onion", 0.0 },
                    { 104, "oregano", 0.0 },
                    { 105, "tomato paste", 0.0 },
                    { 106, "fire roasted tomato", 0.0 },
                    { 107, "chocolate stout", 0.0 },
                    { 108, "tortilla chips", 0.0 },
                    { 109, "lime", 0.0 },
                    { 110, "ground beef", 0.0 },
                    { 111, "jalape�o", 0.0 },
                    { 112, "chili powder", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 113, "barbecue sauce", 0.0 },
                    { 115, "sweet onion", 0.0 },
                    { 94, "vanilla extract", 0.0 },
                    { 138, "rice vinegar", 0.0 },
                    { 140, "red wine vinegar", 0.0 },
                    { 165, "cheddar cheese", 0.0 },
                    { 166, "beef chuck roast", 0.0 },
                    { 167, "green bell pepper", 0.0 },
                    { 168, "red bell pepper", 0.0 },
                    { 169, "ground cumin", 0.0 },
                    { 170, "beef broth", 0.0 },
                    { 171, "crushed tomatoes", 0.0 },
                    { 172, "pimiento", 0.0 },
                    { 173, "ground pork", 0.0 },
                    { 174, "ground veal", 0.0 },
                    { 175, "dried basil", 0.0 },
                    { 176, "worcestershire sauce&1", 0.0 },
                    { 177, "milk", 0.0 },
                    { 178, "white bread", 0.0 },
                    { 179, "onions", 0.0 },
                    { 180, "blackberries", 0.0 },
                    { 181, "light brown sugar", 0.0 },
                    { 182, "ground ginger", 0.0 },
                    { 183, "cayenne pepper", 0.0 },
                    { 164, "butter puff-pastry", 0.0 },
                    { 139, "mayonnaise", 0.0 },
                    { 163, "beef stock", 0.0 },
                    { 160, "cilantro", 0.0 },
                    { 141, "blue cheese", 0.0 },
                    { 142, "rosemary", 0.0 },
                    { 143, "garlic powder", 0.0 },
                    { 144, "ground beef brisket", 0.0 },
                    { 145, "cumin", 0.0 },
                    { 146, "oil", 0.0 },
                    { 147, "brioche bun", 0.0 },
                    { 148, "arugula", 0.0 },
                    { 149, "onion powder", 0.0 },
                    { 150, "paprika", 0.0 },
                    { 151, "pepper", 0.0 },
                    { 152, "sirloin flap steak", 0.0 },
                    { 153, "red onion", 0.0 },
                    { 154, "black beans", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 155, "chile powder", 0.0 },
                    { 156, "cumin powder", 0.0 },
                    { 157, "lime juice", 0.0 },
                    { 158, "soft sandwich rolls", 0.0 },
                    { 159, "avocado", 0.0 },
                    { 162, "flour", 0.0 },
                    { 93, "strawberry pur�e", 0.0 },
                    { 161, "sour cream", 0.0 },
                    { 91, "fine sea salt", 0.0 },
                    { 25, "white wine", 0.0 },
                    { 26, "chopped tomatoe", 0.0 },
                    { 27, "spaghetti", 0.0 },
                    { 28, "chopped parsley", 0.0 },
                    { 29, "salt and pepper", 0.0 },
                    { 30, "neutral oil", 0.0 },
                    { 31, "sourdough bread", 0.0 },
                    { 32, "raw cashews", 0.0 },
                    { 33, "black mustard seeds", 0.0 },
                    { 34, "urad dal", 0.0 },
                    { 35, "asafetida", 0.0 },
                    { 36, "shallot", 0.0 },
                    { 37, "chopped green chile", 0.0 },
                    { 38, "curry leaves", 0.0 },
                    { 39, "ground turmeric", 0.0 },
                    { 40, "small cauliflower florets", 0.0 },
                    { 41, "frozen peas", 0.0 },
                    { 42, "plain full-fat yogurt", 0.0 },
                    { 43, "roughly chopped cilantro and stems and leaves", 0.0 },
                    { 24, "salted capers", 0.0 },
                    { 44, "fried egg", 0.0 },
                    { 23, "white fish", 0.0 },
                    { 21, "garlic", 0.0 },
                    { 92, "whole milk", 0.0 },
                    { 2, "unsalted butter", 0.0 },
                    { 3, "prepared horseradish", 0.0 },
                    { 4, "kosher salt", 0.0 },
                    { 5, "shrimp", 0.0 },
                    { 6, "chopped dill", 0.0 },
                    { 7, "crusty bread", 0.0 },
                    { 8, "hot pasta", 0.0 },
                    { 9, "sliced red onion", 0.0 },
                    { 10, "salt", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 11, "roasted chicken", 0.0 },
                    { 12, "peppadews peppers", 0.0 },
                    { 13, "marinated artichoke hearts", 0.0 },
                    { 15, "chopped thyme", 0.0 },
                    { 16, "whole-grain mustard", 0.0 },
                    { 17, "sherry vinegar", 0.0 },
                    { 18, "extra virgin olive oil", 0.0 },
                    { 19, "black pepper", 0.0 },
                    { 20, "olive oil", 0.0 },
                    { 22, "olive", 0.0 },
                    { 45, "key lime juice", 0.0 },
                    { 14, "chopped smoked almonds", 0.0 },
                    { 47, "sweetened condensed milk", 0.0 },
                    { 71, "cocoa powder", 0.0 },
                    { 72, "cream of tartar", 0.0 },
                    { 73, "mexican chocolate", 0.0 },
                    { 74, "heavy cream", 0.0 },
                    { 75, "chicken stock", 0.0 },
                    { 76, "white pepper", 0.0 },
                    { 77, "orzo", 0.0 },
                    { 78, "dash sugar", 0.0 },
                    { 79, "dill sprig", 0.0 },
                    { 70, "cinnamon", 0.0 },
                    { 80, "brie", 0.0 },
                    { 82, "basil leaves", 0.0 },
                    { 84, "dash pepper", 0.0 },
                    { 85, "curly pasta", 0.0 },
                    { 86, "zest of lemon", 0.0 },
                    { 87, "chopped strawberries", 0.0 },
                    { 88, "lemon juice", 0.0 },
                    { 89, "sea salt", 0.0 },
                    { 46, "large egg yolk", 0.0 },
                    { 90, "baking powder", 0.0 },
                    { 81, "tomatoe", 0.0 },
                    { 69, "confectioners' sugar", 0.0 },
                    { 83, "dash sea salt", 0.0 },
                    { 68, "almond flour", 0.0 },
                    { 49, "cornstarch", 0.0 },
                    { 48, "coarse salt", 0.0 },
                    { 50, "cream cheese", 0.0 },
                    { 51, "granulated sugar", 0.0 },
                    { 52, "coarsely crumbled graham crackers", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 54, "all-purpose flour", 0.0 },
                    { 55, "cake flour", 0.0 },
                    { 56, "baking soda", 0.0 },
                    { 57, "egg", 0.0 },
                    { 58, "pure vanilla extract", 0.0 },
                    { 53, "egg white", 0.0 },
                    { 60, "cherry tomatoe", 0.0 },
                    { 67, "pine nuts", 0.0 },
                    { 61, "ear corn", 0.0 },
                    { 62, "large sliced summer squash", 0.0 },
                    { 63, "large chopped red onion", 0.0 },
                    { 64, "penne pasta", 0.0 },
                    { 65, "torn basil leaves", 0.0 },
                    { 59, "buttermilk", 0.0 },
                    { 66, "fresh oregano leaves", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 88, 0, "Gently fold the strawberry pur�e into the frosting, drizzling it in about a third at a time and folding it a few times but not incorporating it fully. Use an ice cream scoop to transfer swirled frosting on top of each cupcake and use a small offset spatula to swirl it", false },
                    { 89, 0, "Top with a lemon slice and a strawberry half", false },
                    { 90, 0, "Pick over the beans to remove any stones or debris, and place them in a large pot. Add the water, bay leaf and onion, cover the pot, and bring it to a boil. Let boil for 2 minutes, then turn off the heat and let the beans stand, undrained, for an hour. Discard the onion and bay leaf.", false },
                    { 91, 0, "Using kitchen shears, snip off the stems of the dried peppers and shake out most of the seeds. Toast the peppers in a dry skillet until they are fragrant and beginning to soften, then place them in a bowl and cover them with the 2 cups of boiling water. Let soak until they are very soft.", false },
                    { 92, 0, "Toast the coriander and cumin seeds in the same dry skillet until fragrant. Transfer to a mortar and pestle, add the coarse salt, and grind. Place the softened peppers with their soaking liquid in a blender, adding the ground coriander/cumin mixture, the cinnamon, the chipotle powder, the cocoa powder, and the roasted bell pepper. Puree until smooth and set aside.", false },
                    { 95, 0, "Return the short ribs to the pot with any juices that have accumulated on the plate or platter, then add the chile puree, the beans with their cooking liquid, and the fire-roasted tomatoes. Add the stout and stir to incorporate. Cover and simmer over low heat for at least 3-4 hours, until the beans and beef are fully tender.", false },
                    { 94, 0, "Add the chopped onion and a pinch of salt and cook until translucent. Add the garlic and marjoram or Mexican oregano and cook until fragrant. Clear a space in the bottom of the pot, add the tomato paste, and cook for a minute until it gets a little caramelized before stirring it through the onion mixture.", false },
                    { 96, 0, "Add the crushed tortilla chips about an hour before serving, stirring them in so they break down and thicken the chili. Taste for salt and add a bit more if necessary, stir in the fresh lime juice off the heat, then serve with garnishes and plenty of cold beer.", false },
                    { 97, 0, "Heat your grill to medium-high. Brush the grill with oil to prevent sticking.", false },
                    { 87, 0, "With the mixer running on medium speed gradually add the butter a few tablespoons at a time mixing to fully combine before adding more. This will take several minutes and the mixture will look light and fluffy. Remove the bowl from the mixer and mix in the lemon curd with a silicone spatula. I use sort of a folding motion to incorporate it, because it helps to deflate the frosting a bit and make it smoother.", false },
                    { 98, 0, "To make the patties, combine the beef, jalape�os, salt, pepper, and chili powder in a large bowl, handling it as little as possible. Shape into 6 patties to fit the bun size. Loosely cover with plastic wrap and set aside.", false },
                    { 99, 0, "Prepare the barbecue cheese: Mix the barbecue sauce, cheese, and onions and set it aside. Do not refrigerate (you will be using it shortly and you don�t want it to be really cold).", false },
                    { 93, 0, "Cut the short ribs into bite-sized chunks, season well with salt, and set aside. Place a small amount of oil in a deep, heavy-bottomed pot and warm until shimmering. Brown the short rib pieces in batches, removing them to a plate or platter as you finish browning.", false },
                    { 86, 0, "Cook the sugar mixture until it reads 235�F/115�C. Begin whipping the egg whites on medium speed raising to medium-high speed once the mixture looks frothy. When the sugar mixture reaches 240�F remove the pot from the heat and gradually add the hot sugar syrup to the mixer in a slow steady stream. Continue whipping until the meringue has reached full volume and the bowl is no longer warm to the touch for 5 to 6 minutes", false },
                    { 77, 0, "bring a large pot of heavily salted water to a boil and cook the pasta until just al dente. Strain it and tip it into the bowl with the sauce. Fold everything together until it is well combined, the Brie has begun to melt, and the pasta is slicked with cheese and tomato goodness. Serve immediately with a big green salad", false },
                    { 84, 0, "Bake the cupcakes until a toothpick inserted into the center comes out clean (or with just a few moist crumbs) in 17 to 20 minutes. Cool completely", false },
                    { 71, 0, "beat egg whites in a medium-size bowl until soft peaks form", false },
                    { 100, 0, "Place the patties on the grill rack and cook, turning once, until they're cooked to your preference, 5 to 7 minutes on each side for medium. In the last 3 minutes of grilling, carefully place equal amounts of the barbecue cheese on each patty. During the last 2 minutes of grilling, place the buns cut side-down, on the outer edges of the rack to toast lightly.", false },
                    { 72, 0, "Beat in the egg yolks and lemon juice. Pour 2 cups of reserved hot stock slowly into the lemon and egg mixture, whisking continuously until all is incorporated. Return soup to medium-low heat and whisk in lemon-egg mixture. Add chicken stock back into the soup and simmer until thickened slightly, about 20 minutes", false },
                    { 73, 0, "ladle into warm bowls and garnish with white pepper, chopped dill, a dill sprig, and sliced lemon", false },
                    { 74, 0, "Put the Brie in the freezer for about 20 minutes to firm up a little. This will make it easier to cut when the time comes", false },
                    { 75, 0, "Roughly chop the tomatoes and put them in a large serving bowl. Finely chop the garlic and add it to the bowl. Chiffonade or roughly chop the basil and add that to the bowl too. Pour in the olive oil and add a generous amount of salt and pepper. Gently stir everything together", false },
                    { 85, 0, "Make the lemon curd buttercream: Place the egg whites and cream of tartar in the bowl of an electric mixer fitted with the whisk attachment. In a medium saucepan combine the sugar and water and bring to a boil over medium heat. Stir until the mixture begins to bubble but as soon as it begins to boil, stop stirring. If necessary dip a brush in cool water to brush away granules of sugar that appear on the side of the pot", false },
                    { 76, 0, "Once the Brie is firm enough, cut it into 1/2-inch cubes and add these to the bowl. Gently fold to combine the cheese with the rest of the ingredients. Cover the bowl and let it sit at room temperature for at least 2 to 8 hours -- the longer the better", false },
                    { 78, 0, "Make the pur�e: In a small bowl and rub the granulated sugar and lemon zest together. In a medium pot toss the strawberries and lemon juice to combine. Add the sugar and salt tossing everything to combine. Cook over medium heat stirring frequently until the mixture becomes saucy and the strawberries start to break down in 8 to 10 minutes", false },
                    { 79, 0, "Use an immersion blender to pur�e the mixture in the pot. Continue to cook the mixture over medium-low heat stirring often until it reduces to 2/3 cup in 10 to 15 minutes more. Cool completely before using. This can be done up to 2 days ahead and refrigerated", false },
                    { 80, 0, "Make the cake: Heat the oven to 350�F/175�C. Line two 12-cup muffin tins with cupcake liners", false }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 81, 0, "In the bowl of an electric mixer fitted with the paddle attachment mix the flour, sugar, baking powder, baking soda and salt to combine. Drop half tablespoon-size portions of butter into the bowl and mix on low speed until the butter is distributed and the mixture looks a bit crumbly", false },
                    { 82, 0, "In a large liquid measuring cup whisk the egg whites, milk, strawberry pur�e, vanilla, and lemon zest to combine. Add this mixture in two equal additions mixing on medium speed until the batter is smooth and combined and scraping well after each addition. If desired tint the batter deeper pink with food coloring", false },
                    { 83, 0, "Scoop the batter into the prepared pan using an ice cream scoop filling each cavity three-quarters full", false },
                    { 70, 0, "bring stock to a boil in a large saucepan. Lower heat to a simmer and add salt, pepper, and orzo. Cook until al dente, about 8 minutes. Remove from heat. Set aside 2 cups of stock", false },
                    { 101, 0, "To assemble the burgers, place an equal layer of barbecue kettle chips on each bottom bun. Add a cheese-covered patty on top, followed by a layer of pickles and an equal amount of lettuce. Add the bun tops and serve with an ice-cold beer or a big ol' pitcher of tea.", false },
                    { 123, 0, "Whisk the egg in a bowl. Brush the edges of the pastry overlap with the egg mixture and top with smaller pastry rounds. Press around the edges of the pies using the tines of a fork to create a seal. Cut a small slit into the top of each pie. Use the remaining egg to brush the tops of each pie. Place the tray in the freezer to chill for 15 mins before baking.", false },
                    { 103, 0, "Add the shallot, garlic, tomato paste, red pepper flakes, herbes de Provence, and bay leaf", false },
                    { 134, 0, "Once cooked, remove from the oven and let it cool for roughly five minutes. In the meantime, warm up more of the bbq sauce. Remove the loaf to a serving dish, and drizzle the sauce on the top. Serve with your favorite sides. I served mine with mashed potatoes. Trust me, this one is really delicious.", false },
                    { 69, 0, "When the cookies and filling are cool, spread or pipe the ganache on the flat side of one macaron and create a sandwich with a second one", false },
                    { 133, 0, "Heat your oven to 350 degrees F. In a large bowl, combine all of your ingredients, with the exception of the bbq sauce. Get in there, get dirty and greasy from the meat. Once combined, add to your bread/loaf pan which is typically 5�9. Shape into the pan, then add your sauce to the top, roughly a half cup. Place in the oven for nearly one hour and 25 minutes.", false },
                    { 132, 0, "Make the Sauce: Add the above ingredients to a blender, and puree until nice and smooth. Add this to a small pot, and cook on medium to low heat for about 20 minutes. Stir, and remove from the heat. When you make the meatloaf, add the sauce to the top before baking, and spread on the plate before serving.", false },
                    { 131, 0, "Stir in the parsley and season with salt and pepper to taste. Serve over white rice.", false },
                    { 130, 0, "Transfer the beef to a plate and shred. Return shredded beef to sauce.Stir in the olives (optional). Simmer uncovered for 30 minutes to thicken.", false },
                    { 129, 0, "Return the beef to the pot. Bring to a simmer and cover for 2 to 3 hours or until the beef is fork-tender.", false },
                    { 128, 0, "Add the beef broth and crushed tomatoes. Bring to a simmer.", false },
                    { 127, 0, "Add the onion and peppers to the pot and cook over medium heat for 15 to 20 minutes until caramelized. Add the garlic, oregano, cumin, and paprika. Cook for another minute. Add the white wine and bring to a boil, scraping the bottom of the pan with the flat edge of a spatula to deglaze.", false },
                    { 126, 0, "Heat olive oil in a pot over high heat. Add the beef and brown on all sides. Then transfer to a plate.", false },
                    { 125, 0, "Season beef liberally with salt and freshly ground black pepper.", false },
                    { 124, 0, "While the pies are chilling preheat the oven to 425� F. Bake pies for 20-25 minutes, until golden brown. Let cool 10 minutes before serving.", false },
                    { 122, 0, "Remove the chilled beef mixture from the fridge. Stir in the diced cheese. Evenly divide filling between each pie, packing them right to the top.", false },
                    { 121, 0, "Lightly grease a 12-cup muffin tin. Place larger puff pastry rounds in the base of each muffin tin, pressing along the sides so they are flush with the bottom and sides of the tin. The dough should slightly overlap the rims, stretch dough slightly if needed.", false },
                    { 120, 0, "Remove puff pastry from fridge. Roll sheets to 1/8-inch thick. Cut puff pastry into twelve 4-inch rounds and twelve 3-inch rounds. Pre-mark where you will cut each round as you will have just enough dough for all the rounds. Place onto a parchment-lined baking sheet and let chill in the fridge for 30 minutes.", false },
                    { 119, 0, "Scrape beef mixture into a bowl and let cool to room temperature. Cover and refrigerate until completely chilled, this will take at least 1-2 hours. The filling can easily be made the day before.", false },
                    { 118, 0, "Stir in salt and a few cracks of black pepper. Sprinkle flour over beef and cook, 1 minute. Pour in beef stock and Worcestershire sauce. Bring to a boil, scraping all the brown bits off the bottom of the pan. Reduce heat to medium-low and let simmer until gravy has reduced and thickened, about 6-8 minutes.", false },
                    { 104, 0, "Marinate the bulgogi: In a large bowl, whisk together the brown sugar, soy sauce, wine, sesame oil, green onions, garlic, and pepper until well combined. Add the beef and coat it completely in marinade. Cover and refrigerate for 4 to 5 hours.", false },
                    { 105, 0, "To make the cucumber kimchi salad: In a medium bowl, combine the cucumbers, green onions, garlic, gochugaru, sugar, vinegar, sesame oil, and salt to taste and stir gently. Cover and refrigerate until ready to serve.", false },
                    { 106, 0, "Prepare a hot grill. If the pieces of beef are so small that they may fall through the grates, use a grilling skillet or place a sheet of foil on the grill.", false },
                    { 107, 0, "Grill the beef on both sides until medium-well, 3 to 5 minutes, flipping halfway through cooking. Don�t crowd the skillet or foil, so do this in batches if necessary. As you finish each batch, transfer it to a serving platter and continue with the remaining beef.", false },
                    { 108, 0, "Serve the bulgogi on top of steamed rice. Garnish with green onion and toasted sesame seeds and spoon the cucumber kimchi salad alongside.", false },
                    { 109, 0, "For the mayo, mix all of the ingredients together and set aside. If not using right away, keep in an airtight container in the fridge.", false },
                    { 102, 0, "Preheat the oven to 325�F. Generously season the short ribs with salt and pepper and heat a small (1 1/2 to 3�quart) oven-safe saucepan over medium-high heat. Add 1 tablespoon olive oil and sear the short ribs, 2 to 3 minutes per side, until browned on all over. Remove meat to a plate, leaving rendered fat in the pan.", false },
                    { 110, 0, "For the burger, gently mix together the ground beef, onion, Worcestershire, rosemary, cumin, cinnamon, salt, and pepper until just combined. Form into a single patty, about the size of your burger bun, making sure to press a shallow indentation in the center so it stays flat when you sear it.", false },
                    { 112, 0, "To assemble, lay the bottom bun with a healthy pile of arugula, then the warm brisket patty (which will wilt the lettuce slightly), followed by the top bun, which should be smeared generously with the prepared blue cheese mayo.", false },
                    { 113, 0, "Mix together the garlic, onion powder, paprika, pepper, and 2 tablespoons of oil. Toss the steak in the marinade to coat and let it sit at room temperature 30 minutes or refrigerate it for up to 8 hours. Heat the grill to medium-high. Season the steak with salt and grill until its internal temperature reaches 125� F and it is nicely browned. Let the steak rest for ten minutes before slicing it very thinly against the grain.", false },
                    { 114, 0, "Heat the vinegar, water, salt, and sugar in a saucepan. Add the onion and jalape�o and let simmer for a couple of minutes. Set aside to cool.", false },
                    { 115, 0, "Mash the beans with chipotle, cumin, lime, and salt and pepper. Taste the mixture and add salt and acid as needed. Add a spoon or two of water and heat gently before serving.", false },
                    { 116, 0, "Toast the insides of the rolls slightly, then top them with the beans, steak, pickled vegetables, avocado slices, cilantro, and a drizzle of crema.", false },
                    { 117, 0, "Heat oil in a large frying pan over medium heat. Add onion, cook, stirring often until tender and starting to brown on the edges, about 2-3 minutes. Add garlic, cook 1 minute. Add ground beef to pan and cook, breaking up with a wooden spoon, until no pink remains, about 5-6 minutes.", false },
                    { 111, 0, "Brush the prepared patty with some oil and plop onto a hot griddle or small frying pan, cooking 3 minutes on the first side and 2 on the second. (Or until the internal temperature reaches 145�F for medium-rare and 160�F for medium.) Let rest about 5 minutes.", false },
                    { 68, 0, "Make ganache while the cookies cool. Melt chocolate in double boiler. Whisk in heavy cream and butter and stir mixture over gently boiling water until it is smooth and shiny", false },
                    { 24, 0, "when wine is nearly evaporated, reduce heat, add tomatoes and cook for 10 minutes", false },
                    { 66, 0, "Spoon the mixture into a pastry bag or a ziplock. If using a zip-top bag, cut off a 1/4-inch tip from the corner. Pipe the mixture in a spiral to fill each 1.5-inch circle on the parchment paper. Allow the unbaked cookies to sit out for 30 minutes, until the cookies have a matte texture and are no longer sticky", false }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 31, 0, "Remove the toasted bread and cashews and set aside", false },
                    { 30, 0, "Add the cubed bread and raw cashews to the pan and toast in oil until crunchy and golden brown, shaking the pan frequently and tossing the bread so it doesn't burn. This will take 5 to 6 minutes", false },
                    { 29, 0, "In a wok set over medium-high heat, add 1 tablespoon of oil and heat until shimmering", false },
                    { 28, 0, "carefully add the sauce to the pasta over a little heat and stir gently for a minute or two", false },
                    { 27, 0, "cook pasta al dente", false },
                    { 26, 0, "when the tomato juice is released and the sauce is just thickening, turn off heat", false },
                    { 25, 0, "add capers, parsley and olives", false },
                    { 23, 0, "meantime heat pot of hot water for pasta, generously salted", false },
                    { 22, 0, "stir carefully till wine is nearly evaporated", false },
                    { 21, 0, "once browned, add salt and pepper, then half glass of white wine and turn up heat", false },
                    { 20, 0, "add fish, stirring carefully until browned", false },
                    { 19, 0, "saute three tablespoons of oil with garlic for two minutes over medium heat", false },
                    { 18, 0, "deskin fish and cut into bite sized chunks", false },
                    { 17, 0, "dice garlic", false },
                    { 67, 0, "Bake for 12 to 15 minutes. Allow to cool and then peel very gently off the parchment paper", false },
                    { 16, 0, "chop tomatoes roughly", false },
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
                    { 15, 0, "Pour the dressing over the chicken and fold together. Squeeze in lemon juice", false },
                    { 33, 0, "Add the mustard seeds, urad dal and asafetida and shake the pan vigorously to coat everything in the fat. In 20 to 30 seconds the seeds will burst and the dal will become a deeply golden-brown color", false },
                    { 32, 0, "Lower the flame to medium and add the second tablespoon of cooking fat to the pan, heating until its shimmering", false },
                    { 35, 0, "raise the heat to medium-high and cook until the onions have softened and turned translucent", false },
                    { 65, 0, "Using a silicone spatula, fold the almond and sugar mixture into the egg whites one-third at a time. You do not have to be gentle, instead use brisk strokes to fold the mixture together completely, this will help reduce the air in the meringue and keep the macaroons from being too puffy", false },
                    { 64, 0, "Put egg whites in stainless steel bowl and beat on low with a hand mixer until frothy. Add salt and cream of tartar, and slowly mix in the granulated sugar. Once the sugar is all incorporated, increase mixer speed to medium and beat until meringue forms stiff peaks.The meringue should look glossy and remain in place when the bowl is tipped on its side", false },
                    { 63, 0, "Pulse the almond flour, confectioners' sugar, cinnamon, and cocoa in a food processor until it is a finely mixed powder. Sift into a large bowl", false },
                    { 62, 0, "Line two cookie pans with parchment paper and trace 1.5 inch circles on the paper, keeping the circles about one inch apart. Preheat your oven to 300� F", false },
                    { 61, 0, "Measure egg whites and allow to sit at room temperature for 24 hours in a covered bowl. Aging the whites helps them thin and will create a better textured macaron", false },
                    { 60, 0, "Add the roast vegetables, along with remaining 1 tbsp olive oil and a tiny bit of the cooking liquid, to the pasta. Toss in the basil and oregano. Top with toasted pine nuts if desired", false },
                    { 59, 0, "Cook pasta till tender but slightly al dente. Drain and return to pot, reserving a small amount of the cooking liquid", false },
                    { 58, 0, "If you're using the pine nuts, now is the time to toast them gently in a large frying pan set over medium heat. Stir them continually and remove them as soon as they�re becoming golden", false }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone" },
                values: new object[,]
                {
                    { 57, 0, "Divide all vegetables save corn onto baking sheets and start roasting them for 35 to 40 minutes. Fifteen minutes before the end of the roasting process, add the corn which cooks a little faster than the other vegetables", false },
                    { 56, 0, "Toss vegetables and garlic with olive oil and season well with salt and pepper, but keep the corn separate", false },
                    { 55, 0, "Preheat oven to 450 degrees. Set a pot of boiled water on the stove to boil", false },
                    { 54, 0, "Serve at cool room temperature", false },
                    { 53, 0, "Gently brown the meringue with a kitchen torch", false },
                    { 34, 0, "Add the onions, chile, salt, turmeric, curry leaves and stir to combine", false },
                    { 51, 0, "Transfer the bowl to the mixer and whip on high speed until firm peaks form, about 5 minutes", false },
                    { 52, 0, "Remove the skewer from the chilled cake and dollop the meringue on top, piling it high", false },
                    { 49, 0, "Use a serrated knife to trim the domes from the tops of the cakes and slice each in half horizontally to create four layers. Place one layer on a serving platter and brush the top with about 2 tablespoons of the soaker. Stir the lime filling briefly to loosen it. Then use a small offset spatula to spread about one-third of the filling over the cake, getting it right up to the edge. Scatter a third of the graham cracker crumbs over the filling and top with another layer of cake. Continue assembling in this manner with the remaining filling and cake layers. Slide a long wooden skewer vertically through the center of the cake if it feels wobbly. Chill the assembled cake until you are ready to make the meringue", false },
                    { 36, 0, "Add the cauliflower florets and stir, cooking for 3 to 5 minutes longer until they have softened and are completely coated with the spice and onion mixture", false },
                    { 37, 0, "Add the reserved bread and cashews to the pan with the vegetables and stir everything together, ensuring the onion mixture and cauliflower florets are evenly dispersed with the bread. Cook together for about a minute more", false },
                    { 38, 0, "Add the peas and cook for another minute", false },
                    { 39, 0, "Carefully drizzle the yogurt over the upma and stir to combine so the bread and vegetables are completely coated", false },
                    { 50, 0, "To make a Swiss meringue, place the egg whites and sugar in the heatproof bowl of an electric mixer. Set the bowl over a pan of gently simmering water and heat, whisking occasionally, until the sugar is dissolved and the mixture reads 160�F (71�C) on a thermometer", false },
                    { 41, 0, "Once the upma has crisped up to your desired texture, divide among bowls", false },
                    { 40, 0, "Cook for 2 to 3 minutes more, stirring only occasionally, so the upma browns and crisps up some more, helped along with the lactose sugar in the yogurt", false },
                    { 43, 0, "Do yourself a favor and make the filling the night before you plan to assemble this cake. Have a fine-mesh sieve and a large bowl on standby near the stove. Squeeze every last drop of juice from the limes and combine in a small saucepan with the yolks, condensed milk, salt and cornstarch. Whisk everything together until it's nice and smooth and then set over medium heat. Dont stop whisking", false },
                    { 44, 0, "Reduce the temperature a bit as the mixture thickens dramatically and keep whisking as it boils for 2 minutes", false },
                    { 45, 0, "Strain the mixture through the fine-mesh sieve into the bowl and stir gently with a rubber spatula to let off some of the steam", false },
                    { 46, 0, "Add the cream cheese, one or two pieces at a time, and stir until all of it has been incorporated", false },
                    { 47, 0, "Place a piece of plastic film or wax paper directly on the surface of the custard to prevent a skin from forming and refrigerate until firm, at least 4 hours, preferably overnight", false },
                    { 48, 0, "Make the lime soaker by stirring the sugar into the juice until it's dissolved. Set aside", false },
                    { 42, 0, "Add chopped cilantro and a fried egg", false }
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
                    { 8, 0, 1, "The name of this classic Greek soup emulsion of lemon and eggs comes from its two main ingredients: egg (avgo) and lemon juice (lemono). The key to this soup is tempering the egg and lemon mixture by slowly adding hot stock and then whisking constantly to prevent the eggs from curdling. You then stir the mixture into the soup, which becomes all velvety lush lemony goodness. A Greek salad and warm pita bread are wonderful accompaniments to this soup", "https://images.food52.com/Y4T3Uk-cKn799bjhWySmQJ9YxIA=/1008x672/filters:format(webp)/2311e33a-47e9-4504-99e4-dd3d61337348--2017-1212_egglands-best-sponsored_greek-soup-holiday_3x2_mark-weinberg_0128.jpg", "Greek Lemon Soup - Avgolemono" },
                    { 3, 0, 4, "Fish Pasta can be made with any flakey white fish. Snapper good but its best with fresh striped bass. Be very careful stirring the sauce: the fish should remain intact. The tomatoes should be fresh and cooked al crudo, till the juices are released but they are still a little raw. By adding the fish early on, its flavor infuses the whole sauce, so the tomatoes and fish are no longer separate entities, but fully integrated into the sauce. And the capers and olives reinforce the flavor of the fish with brine", "https://images.food52.com/mlooIQOUxc3VtpQefZvmZiUY1Jw=/1008x672/filters:format(webp)/0afceb53-8c13-4b96-82ba-45235cf98176--fishpastalowres_2417.JPG", "Fish Pasta" },
                    { 18, 0, 3, "A traditional beef stew from Cuba made with shredded beef that is often served with black beans and rice.", "https://images.food52.com/w-E3753Js_MvtbsBVHEQU_pOAso=/1008x672/filters:format(webp)/9c0278c5-ed16-4912-b8f5-1a3ccd3e5f09--2019-0618_ropa-vieja_3x2_bobbi-lin_4189.jpg", "Ropa Vieja" },
                    { 17, 0, 3, "These mince and cheese pies feature ground beef encased in a thick, dark, beefy gravy interspersed with pockets of melted white cheddar cheese.", "https://images.food52.com/EYhpqWDzO1OpxcmCUmsQF8FjQDg=/1008x672/filters:format(webp)/936c251b-b56b-4e31-8407-71ea86c72f3e--2018-0308_new-zealand-gas-station-beef-cheese-pies_3x2_james-ransom-0122.jpg", "New Zealand-Style Beef & Cheddar Pies" },
                    { 2, 0, 3, "If you like a good mayonnaise-based chicken salad, but one with more candid flavors, you should try this recipe! With a glass of white wine it feels like the perfect weekend lunch", "https://images.food52.com/OOqBZEjQhcOLodgRlnXoOfVI5RY=/1008x672/filters:format(webp)/d8634211-6145-4329-81ca-711c45e4750a--2017-0427_chicken-salad_james-ransom-297.jpg", "Chicken Salad" },
                    { 19, 0, 2, "For the best traditional meatloaf recipe relying on the classic triumvirate of ground veal, beef and pork. A little bread and milk. Garlic, onion and Worcestershire sauce. All are thoughtfully balanced, producing a savory, light-textured loaf.", "https://images.food52.com/SEoIY3KjCVcA_NwGD52FNaXydYM=/1008x672/filters:format(webp)/29e35312-3021-4491-9662-2d6d6f41b35e--2019-0423_meatloaf-with-blackberry-bbq-sauce_3x2_julia-gartland_0929.jpg", "Meatloaf with Blackberry Barbecue Sauce" },
                    { 14, 0, 2, "An American-Korean hybrid, much sweeter than traditional bulgogi, served on a bed of white rice.", "https://images.food52.com/8uquQ9jEsWl-YGubwhZZbfEXSBo=/1008x672/filters:format(webp)/59d62ed1-e083-404e-ad5a-34876e435dac--2018-0503_moms-bulgogi-cucumber-kimchi-salad_3x2_rocky-luten_049.jpg", "Bulgogi with Cucumber Kimchi Salad" },
                    { 13, 0, 2, "My take on boeuf bourguignon skips a couple ingredients�namely the bacon, whose fat traditionally adds luscious flavor to the classic French stew, and the flour, which would otherwise serve as a thickener for the sauce. I find that boneless beef short ribs, which are marbled with fat and collagen, do all the heavy lifting in this recipe and help you arrive at a final stew that�s just as glossy, satisfying, and full of deep, savory flavor as the original.", "https://images.food52.com/T4h0NggW-s84P3TvGLm2e556Xuk=/1008x672/filters:format(webp)/8ed76823-4e2e-45e0-b8be-a459eb1a915c--2020-0303_boeuf-bourguignon-for-one_3x2_ty-mecham.jpg", "Beef Short Rib Bourguignon With Garlicky Panko Gremolata" },
                    { 12, 0, 4, "A way to combine some tailgate favorites: burgers, barbecue, and chips. You will need either a cold beer or a Texas tea to wash this bad boy down!", "https://images.food52.com/GbbciGi20Daa9DrE_TDPc63Ty2g=/1008x672/filters:format(webp)/133eb19c-b40f-46cb-a8c5-0251afd60969--2014-0715_jalapeno-cheddar-burger-004.jpg", "Texas Tailgate Burger" },
                    { 9, 0, 2, "Alot of people make a summer pasta alla Caprese like this: the pasta�raw garlic or onion, tomatoes, basil, olive oil and fresh mozzarella. This recipe replaces the mozarella with brie. A bold but satisfying choice! A fine Brie is just as delicious at room temperature smeared on crusty bread as it is warm, oozing out of flaky pastry. And it's REALLY good folded into a fresh tomatoey, garlicky sauce for pasta. Put aside any residual anti-Brie sentiments and give this one a shot before tomatoes disappear for the year. You won't regret it", "https://images.food52.com/i8P83CvSSFTTVWinAuWJuXqAHFo=/1008x672/filters:format(webp)/547d4b4b-dfa0-494a-9415-04a97a103f05--20120804_food52_08-20-12-1466.jpg", "Pasta with Tomatoes, Garlic, Basil & Brie" },
                    { 6, 0, 2, "Think of this recipe as summer in a bowl. The sweet corn, bursting cherry tomatoes, and tender zucchini lighten up a savory, satisfying bowl of pasta. Proof that meatless dishes can be quick, easy, and a joy to eat", "https://images.food52.com/9-Z62AhfnO7vECg7gARyZVGIW9A=/1008x672/filters:format(webp)/fc3db569-3b62-4126-a92c-9598b7fdb120--food52_07-24-12-7723.jpg", "Penne with Sweet Summer Vegetables, Pine Nuts and�Herbs" },
                    { 5, 0, 2, "Key Lime Cake tastes like summer. Beachy. Floral. Have you ever rubbed your fingers across a wicker armrest and gotten lost in the undulating cords like waves", "https://images.food52.com/NL2-zUmt3I_hFG3qnUfdKY6-bZQ=/1008x672/filters:format(webp)/7247d84f-cd2f-49ab-af78-4714ce5b0f92--Fruit_Cake_Key_Lime_Cake.jpg", "Key Lime Cake" },
                    { 4, 0, 2, "People know upma as a South Indian breakfast staple, but its more. Upma is a state of mind. The refrain is simple: Carb of choice, toasted in ghee-bloomed spices, then cooked with assorted vegetables and curry leaves and topped with tomato ketchup. In South India the carb of choice is typically toasted semolina, thickened into a creamy, savory porridge. But it can also be made with bread. Bread upma can be made in two contrasting ways. This version captures the best of both", "https://images.food52.com/38ws8x4bhNB0a9zHq6ZSduhKXCY=/1008x672/filters:format(webp)/eb712a59-16c6-4f57-a6cf-8e523aa97e4e--2021-0312_bread-upma_3x2_mark-weinberg-193.jpg", "My Favorite Bread Upma" },
                    { 1, 0, 2, "A simple scampi-inspired dinner that needs neither a lot of time nor a lot of ingredients. The key is to swiftly simmer the shrimp and to rely on extrovert ingredients for seasoning. Lemon juice and lemon zest deliver loads of sunny acidity. So much so that we are also using water, not stock, to stretch the brightness, and to ensure that there is enough sauce for bread-sopping", "https://images.food52.com/_51_B8XLkaL7wou2THrl1WXuadA=/1008x672/filters:format(webp)/3871c07e-9765-4a8d-9fdd-2f996094b105--2021-0518_speedy-shrimp_3x2_james-ransom-031.jpg", "Speedy Shrimp With Horseradish�Butter" },
                    { 15, 0, 1, "This stovetop blue cheese burger recipe makes a single portion. But because it's exactly for one, the math to double or quadruple or octuple the patty is fairly simple. Scale up as many times as you want�no matter what you do, make a lot of the blue cheese mayo. You won't be sorry.", "https://images.food52.com/choh0ovckbNRzRvpo6Y7hXBOjqU=/1008x672/filters:format(webp)/f55f7e17-489f-43ac-9097-a9da39d9701b--2019-0618_blue-cheese-burger-for-one_3x2_bobbi-lin_4166.jpg", "Blue Cheese Burger" },
                    { 11, 0, 1, "We love a good pot of chili, and our kitchen has turned out dozens of variations over the years. Boneless grass-fed beef short ribs, trimmed and cut into chunks, with a puree of chiles and spices, added fire-roasted tomatoes and some rich dark beer.", "https://images.food52.com/VZkTIa68tHfebPSUso6QEyFV5X0=/1008x672/filters:format(webp)/2535541d-3f88-433e-b52e-43d8ea83350e--food52_02-07-12-8044.jpeg", "Short Rib Chili" },
                    { 10, 0, 1, "This is variant on the boxed strawberry cake but made with fresh strawberries. It takes a bit of time to reduce the strawberry mixture to a thick, jammy pur�e, but it's worth it, since it gets used both in the cake and also the frosting to create a beautiful - and delicious - swirl effect. Its best decorated with lemon wedges and/or strawberries but you can never miss with sprinkles", "https://images.food52.com/TRW26JcClLEecmYmv3tOpia1DXY=/1008x672/filters:format(webp)/157f3d99-a272-4002-9353-867d70731001--2021-0512_strawberry-lemonade-cupcakes_4x5_julia-gartland_063.jpg", "Strawberry Lemonade Cupcakes" },
                    { 7, 0, 2, "In the Mexican city of Oaxaca, almonds are ground into a rough paste with cacao, cinnamon, and sugar and hardened into thin fingers of chocolate. The distinctive mixture is used in the city's famous mole sauces and melted into rich hot chocolate which the Oaxacans drink more regularly than coffee. The warm, spicy smell of toasted cacao, cinnamon and almonds fills the city, as crowded storefront grinders are endlessly turning and the mercado stalls are crowded with vendors selling secret family recipes. Ideal for inspiration and make macarons with the same flavors", "https://images.food52.com/fLevsOXvNogpjdYZFItNUwPVf-4=/1008x672/filters:format(webp)/3e4baffa-29dc-4e2e-aa6a-2f42f1f4414a--033010F_869.JPG", "Oaxacan Cinnamon Chocolate Macarons" },
                    { 16, 0, 4, " A go-to, weeknight torta with steak, beans, jalape�os, and avocado. That comes together in under an hour.", "https://images.food52.com/qgtCvxOACjNWH-Q8rPfNOzMQZYE=/1008x672/filters:format(webp)/f0e586ed-75e1-4d0b-a902-b2523e570638--2014-0923_steak-and-bean-torta-018.jpg", "Steak and Bean Torta" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 88, "8 cups", 75, 8 },
                    { 251, "1/2 pound", 173, 19 },
                    { 252, "1/2 pound", 174, 19 },
                    { 253, "1/2 cup diced", 103, 19 },
                    { 254, "1/2 teaspoon", 175, 19 },
                    { 255, "1/2 teaspoon", 4, 19 },
                    { 256, "1/2 teaspoon cracked", 19, 19 },
                    { 257, "3 cloves", 21, 19 },
                    { 258, "1 tablespoon", 176, 19 },
                    { 259, "3/4 cup", 177, 19 },
                    { 260, "3 pieces", 178, 19 },
                    { 261, "(for sauce) 2 small quartered", 179, 19 },
                    { 262, "(for sauce) 2 cloves", 21, 19 },
                    { 263, "(for sauce) 2 cups", 180, 19 },
                    { 264, "(for sauce) 1/2 cup", 181, 19 },
                    { 265, "(for sauce) 1 tablespoon", 182, 19 },
                    { 266, "(for sauce) 1 teaspoon", 183, 19 },
                    { 267, "(for sauce) generous pinch", 10, 19 },
                    { 268, "(for sauce) generous pinch", 19, 19 },
                    { 9, "1/4 cup", 9, 2 },
                    { 10, "", 10, 2 },
                    { 11, "4 cups", 11, 2 },
                    { 12, "3 tablespoons", 12, 2 },
                    { 13, "1 cup", 13, 2 },
                    { 14, "1/4 cup", 14, 2 },
                    { 15, "2 teaspoons", 15, 2 },
                    { 16, "1 tablespoon", 16, 2 },
                    { 17, "1 tablespoon", 17, 2 },
                    { 18, "1", 1, 2 },
                    { 19, "1/4 cup", 18, 2 },
                    { 250, "1/2 pound", 110, 19 },
                    { 186, "1/2 to 1 teaspoons", 4, 14 },
                    { 185, "1 teaspoon", 138, 14 },
                    { 184, "2 teaspoons", 137, 14 },
                    { 154, "1/2 pound boneless", 102, 13 },
                    { 155, "1 pinch", 10, 13 },
                    { 156, "1 pinch", 19, 13 },
                    { 157, "2 tablespoons", 20, 13 },
                    { 158, "1 large", 36, 13 },
                    { 159, "4 cloves", 21, 13 },
                    { 160, "1 tablespoon", 105, 13 },
                    { 161, "1/2 teaspoon crushed", 120, 13 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 162, "1 teaspoon", 121, 13 },
                    { 163, "1", 98, 13 },
                    { 164, "1 cup", 122, 13 },
                    { 165, "1 cup", 95, 13 },
                    { 166, "2 teaspoons", 123, 13 },
                    { 167, "4 ounces", 124, 13 },
                    { 20, "", 19, 2 },
                    { 168, "2 small", 125, 13 },
                    { 170, "2 tablespoons", 127, 13 },
                    { 171, "1/2 zested", 1, 13 },
                    { 172, "1/4 cup chopped fresh", 128, 13 },
                    { 173, "1 teaspoon", 20, 13 },
                    { 174, "3 cups packed light", 129, 14 },
                    { 175, "1 1/2 cups", 130, 14 },
                    { 176, "5 tablespoons", 131, 14 },
                    { 177, "4 tablespoons", 132, 14 },
                    { 178, "4", 133, 14 },
                    { 179, "4 cloves", 21, 14 },
                    { 180, "1 teaspoon", 19, 14 },
                    { 181, "4 to 5 pounds thinly sliced", 134, 14 },
                    { 182, "2 English", 135, 14 },
                    { 183, "1 to 2 teaspoons", 136, 14 },
                    { 169, "", 126, 13 },
                    { 223, "1 tablespoon", 20, 17 },
                    { 224, "1 small finely diced", 99, 17 },
                    { 225, "1 clove", 21, 17 },
                    { 142, "2 pounds", 110, 12 },
                    { 143, "1 cup", 111, 12 },
                    { 144, "1 teaspoon", 10, 12 },
                    { 145, "1 teaspoon", 19, 12 },
                    { 146, "1 teaspoon", 112, 12 },
                    { 147, "1 1/2 cups", 113, 12 },
                    { 148, "2 cups shredded", 114, 12 },
                    { 149, "1/2 cup diced", 115, 12 },
                    { 150, "6", 116, 12 },
                    { 151, "1 handful barbecue-flavored", 117, 12 },
                    { 152, "1 piece", 118, 12 },
                    { 153, "1 handful chopped", 119, 12 },
                    { 203, "2 cloves", 21, 16 },
                    { 204, "1 teaspoon", 149, 16 },
                    { 30, "", 29, 3 },
                    { 205, "1 teaspoon smoked", 150, 16 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 207, "2 tablespoons", 146, 16 },
                    { 208, "1 pound", 152, 16 },
                    { 209, "1/2 cup", 17, 16 },
                    { 210, "1/4 cup", 95, 16 },
                    { 211, "1/2 teaspoon", 10, 16 },
                    { 212, "1 teaspoon", 137, 16 },
                    { 213, "1 small", 153, 16 },
                    { 214, "1", 111, 16 },
                    { 215, "1 can", 154, 16 },
                    { 216, "1/4 teaspoon", 155, 16 },
                    { 217, "1/2 teaspoon", 156, 16 },
                    { 218, "2 teaspoons", 157, 16 },
                    { 219, "", 158, 16 },
                    { 220, "sliced", 159, 16 },
                    { 206, "1 teaspoon", 151, 16 },
                    { 104, "1 pound", 85, 9 },
                    { 29, "2 tablespoon", 28, 3 },
                    { 27, "4", 26, 3 },
                    { 226, "1 pound lean", 110, 17 },
                    { 227, "1/2 teaspoon", 10, 17 },
                    { 228, "3 tablespoons", 162, 17 },
                    { 229, "1 1/2 cups", 163, 17 },
                    { 230, "1 teaspoon", 123, 17 },
                    { 231, "2 450-gram packages pre-rolled", 164, 17 },
                    { 232, "3/4 cup (100g) aged white", 165, 17 },
                    { 233, "1", 57, 17 },
                    { 234, "2 pounds", 166, 18 },
                    { 235, "", 10, 18 },
                    { 236, "", 151, 18 },
                    { 237, "1/4 cup", 20, 18 },
                    { 238, "1 large", 103, 18 },
                    { 239, "1 large", 167, 18 },
                    { 28, "1 packet", 27, 3 },
                    { 240, "1 large", 168, 18 },
                    { 242, "1 teaspoon dried", 104, 18 },
                    { 243, "2 teaspoons", 169, 18 },
                    { 244, "2 teaspoons sweet", 150, 18 },
                    { 245, "1/2 cup dry", 25, 18 },
                    { 246, "1 cup", 170, 18 },
                    { 247, "16 ounces", 171, 18 },
                    { 248, "1 cup", 172, 18 },
                    { 249, "1/4 cup chopped fresh", 128, 18 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 21, "3 tablespoons", 20, 3 },
                    { 22, "2 cloves", 21, 3 },
                    { 23, "12", 22, 3 },
                    { 24, "1 pound", 23, 3 },
                    { 25, "1 tablespoon", 24, 3 },
                    { 26, "1/2 glass", 25, 3 },
                    { 241, "6 cloves", 21, 18 },
                    { 221, "", 160, 16 },
                    { 103, "1", 84, 9 },
                    { 101, "3/4 cup", 20, 9 },
                    { 131, "1 kosher", 89, 11 },
                    { 132, "1 1/2 pounds boneless", 102, 11 },
                    { 133, "1 splash", 30, 11 },
                    { 134, "2 cups", 103, 11 },
                    { 135, "2 large cloves", 21, 11 },
                    { 136, "1 tablespoon", 104, 11 },
                    { 137, "1 tablespoon", 105, 11 },
                    { 138, "1.28oz", 106, 11 },
                    { 139, "1 cup", 107, 11 },
                    { 140, "1/2 cup", 108, 11 },
                    { 141, "1", 109, 11 },
                    { 187, "1/4 cup", 139, 15 },
                    { 188, "1 teaspoon", 140, 15 },
                    { 189, "1 1/2 ounces strong", 141, 15 },
                    { 130, "1 tablespoon", 71, 11 },
                    { 190, "1/2 teaspoon fresh", 142, 15 },
                    { 192, "1 pinch", 137, 15 },
                    { 193, "1 pinch", 4, 15 },
                    { 194, "", 19, 15 },
                    { 195, "1/4 pound", 144, 15 },
                    { 196, "1 tablespoon raw grated", 99, 15 },
                    { 197, "1 teaspoon", 123, 15 },
                    { 198, "1/2 teaspoon ground", 145, 15 },
                    { 199, "1/2 teaspoon ground", 70, 15 },
                    { 200, "Grape-seed or other high-heat", 146, 15 },
                    { 201, "1", 147, 15 },
                    { 202, "1 small handful", 148, 15 },
                    { 1, "2", 1, 1 },
                    { 2, "3 tablespoons", 2, 1 },
                    { 3, "2 tablespoons", 3, 1 },
                    { 191, "1/4 teaspoon", 143, 15 },
                    { 4, "", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 129, "1/2 teaspoon", 70, 11 },
                    { 127, "1 tablespoon", 101, 11 },
                    { 89, "1 1/2 teaspoons", 4, 8 },
                    { 90, "1/2 teaspoon", 76, 8 },
                    { 91, "1 1/2 cup", 77, 8 },
                    { 92, "1", 78, 8 },
                    { 93, "4", 57, 8 },
                    { 94, "3", 1, 8 },
                    { 95, "1/4 cup", 6, 8 },
                    { 96, "1", 79, 8 },
                    { 105, "2 cups", 51, 10 },
                    { 106, "1", 86, 10 },
                    { 107, "1 1/2 pounds", 87, 10 },
                    { 108, "1/4 cup", 88, 10 },
                    { 109, "1 pinch", 89, 10 },
                    { 110, "1 2/3 cups", 54, 10 },
                    { 128, "1 teaspoon", 48, 11 },
                    { 111, "1 teaspoon", 90, 10 },
                    { 113, "1/2 teaspoon", 91, 10 },
                    { 114, "1 1/3 cup", 2, 10 },
                    { 115, "5", 53, 10 },
                    { 116, "1/2 cup", 92, 10 },
                    { 117, "1/3 cup", 93, 10 },
                    { 118, "1 teaspoon", 94, 10 },
                    { 119, "1 pinch", 72, 10 },
                    { 120, "1/4 cup", 95, 10 },
                    { 121, "1/2 cup", 96, 10 },
                    { 122, "1/2 pound", 97, 11 },
                    { 123, "2 1/2 cups", 95, 11 },
                    { 124, "1", 98, 11 },
                    { 125, "1", 99, 11 },
                    { 126, "4", 100, 11 },
                    { 112, "1/2 teaspoon", 56, 10 },
                    { 102, "1", 83, 9 },
                    { 5, "1 pound", 5, 1 },
                    { 60, "1/2 teaspoon", 48, 5 },
                    { 62, "6", 57, 5 },
                    { 63, "1 tablespoon", 58, 5 },
                    { 64, "1/2 cup", 59, 5 },
                    { 65, "2", 60, 6 },
                    { 66, "2", 61, 6 },
                    { 67, "2", 62, 6 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 68, "1", 63, 6 },
                    { 69, "2 cloves", 21, 6 },
                    { 70, "4 tablespoons", 20, 6 },
                    { 71, "8 ounces", 64, 6 },
                    { 72, "1/3 cup", 65, 6 },
                    { 73, "1 tablespoon", 66, 6 },
                    { 74, "", 48, 6 },
                    { 75, "", 19, 6 },
                    { 61, "1/4 teaspoon", 56, 5 },
                    { 76, "1/4 cup", 67, 6 },
                    { 78, "3/4 cup", 51, 7 },
                    { 79, "1 cup", 68, 7 },
                    { 80, "1 1/2 cup", 69, 7 },
                    { 81, "2 teaspoons", 70, 7 },
                    { 82, "3 teaspoons", 71, 7 },
                    { 83, "1 pinch", 10, 7 },
                    { 84, "1 pinch", 72, 7 },
                    { 85, "1 1/4 cup", 73, 7 },
                    { 86, "1 tablespoon", 2, 7 },
                    { 87, "2 tablespoons", 74, 7 },
                    { 97, "3/4 pound", 80, 9 },
                    { 98, "4", 81, 9 },
                    { 99, "2 cloves", 21, 9 },
                    { 100, "1/2 cup", 82, 9 },
                    { 77, "4", 53, 7 },
                    { 6, "1 handful", 6, 1 },
                    { 222, "", 161, 16 },
                    { 58, "1/3 cup", 54, 5 },
                    { 7, "", 7, 1 },
                    { 8, "", 8, 1 },
                    { 31, "2 tablespoons", 30, 4 },
                    { 32, "4 slices", 31, 4 },
                    { 33, "1/4 cup", 32, 4 },
                    { 34, "1/2 teaspoon", 33, 4 },
                    { 35, "1/2 teaspoon", 34, 4 },
                    { 36, "1 pinch", 35, 4 },
                    { 37, "1", 36, 4 },
                    { 38, "1", 37, 4 },
                    { 39, "1 teaspoon", 4, 4 },
                    { 40, "6", 38, 4 },
                    { 41, "1/2 teaspoon", 39, 4 },
                    { 59, "1 1/2 cups", 55, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 42, "1 cup", 40, 4 },
                    { 44, "1/4 cup", 42, 4 },
                    { 57, "1/4 cup", 30, 5 },
                    { 56, "4", 53, 5 },
                    { 55, "1/2 cup", 52, 5 },
                    { 54, "1/4 cup", 45, 5 },
                    { 53, "2 1/4 cup", 51, 5 },
                    { 43, "1/4 cup", 41, 4 },
                    { 52, "1 cup", 50, 5 },
                    { 50, "1 pinch", 48, 5 },
                    { 49, "14 ounce", 47, 5 },
                    { 48, "4", 46, 5 },
                    { 47, "1/2 cup", 45, 5 },
                    { 46, "2", 44, 4 },
                    { 45, "1/4 cup", 43, 4 },
                    { 51, "2 tablespoons", 49, 5 }
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