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
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMin = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
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
                    { 148, "arugula", 0.0 },
                    { 149, "onion powder", 0.0 },
                    { 150, "paprika", 0.0 },
                    { 151, "pepper", 0.0 },
                    { 152, "sirloin flap steak", 0.0 },
                    { 153, "black beans", 0.0 },
                    { 154, "chile powder", 0.0 },
                    { 155, "cumin powder", 0.0 },
                    { 156, "lime juice", 0.0 },
                    { 157, "soft sandwich rolls", 0.0 },
                    { 158, "avocado", 0.0 },
                    { 147, "brioche bun", 0.0 },
                    { 159, "sour cream", 0.0 },
                    { 161, "beef stock", 0.0 },
                    { 162, "butter puff-pastry", 0.0 },
                    { 163, "cheddar cheese", 0.0 },
                    { 164, "beef chuck roast", 0.0 },
                    { 165, "green bell pepper", 0.0 },
                    { 166, "red bell pepper", 0.0 },
                    { 167, "ground cumin", 0.0 },
                    { 168, "beef broth", 0.0 },
                    { 169, "crushed tomatoes", 0.0 },
                    { 170, "pimiento", 0.0 },
                    { 171, "ground pork", 0.0 },
                    { 160, "flour", 0.0 },
                    { 146, "oil", 0.0 },
                    { 145, "cumin", 0.0 },
                    { 144, "ground beef brisket", 0.0 },
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
                    { 131, "sparkling dessert wine", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 132, "sesame oil", 0.0 },
                    { 133, "green onions", 0.0 },
                    { 134, "beef tenderloin", 0.0 },
                    { 135, "cucumber", 0.0 },
                    { 136, "gochugaru", 0.0 },
                    { 137, "sugar", 0.0 },
                    { 138, "rice vinegar", 0.0 },
                    { 139, "mayonnaise", 0.0 },
                    { 140, "red wine vinegar", 0.0 },
                    { 141, "blue cheese", 0.0 },
                    { 142, "rosemary", 0.0 },
                    { 143, "garlic powder", 0.0 },
                    { 172, "ground veal", 0.0 },
                    { 173, "dried basil", 0.0 },
                    { 174, "milk", 0.0 },
                    { 175, "white bread", 0.0 },
                    { 205, "walnuts", 0.0 },
                    { 206, "quinoa flakes", 0.0 },
                    { 207, "coconut flakes", 0.0 },
                    { 208, "dried apple rings", 0.0 },
                    { 209, "dried cranberries", 0.0 },
                    { 210, "pumpkin seeds", 0.0 },
                    { 211, "chia seeds", 0.0 },
                    { 212, "dried figs", 0.0 },
                    { 213, "ginger", 0.0 },
                    { 214, "orange juice", 0.0 },
                    { 215, "goldenberries", 0.0 },
                    { 216, "goji berries", 0.0 },
                    { 217, "dried mulberries", 0.0 },
                    { 218, "cacao nibs", 0.0 },
                    { 219, "butternut squash", 0.0 },
                    { 220, "nutmeg", 0.0 },
                    { 221, "salted butter", 0.0 },
                    { 222, "confectioners sugar", 0.0 },
                    { 223, "chocolate chips", 0.0 },
                    { 224, "coconut milk", 0.0 },
                    { 225, "chocolate", 0.0 },
                    { 226, "dark rum", 0.0 },
                    { 227, "eggs", 0.0 },
                    { 228, "whipping cream", 0.0 },
                    { 229, "cognac", 0.0 },
                    { 204, "almonds", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 118, "dill pickles", 0.0 },
                    { 203, "spelt flour", 0.0 },
                    { 201, "apple", 0.0 },
                    { 176, "onions", 0.0 },
                    { 177, "blackberries", 0.0 },
                    { 178, "light brown sugar", 0.0 },
                    { 179, "ground ginger", 0.0 },
                    { 180, "cayenne pepper", 0.0 },
                    { 181, "american cheese", 0.0 },
                    { 182, "vegetable oil", 0.0 },
                    { 183, "pickle", 0.0 },
                    { 184, "butter", 0.0 },
                    { 185, "raw buckwheat groats", 0.0 },
                    { 186, "almond milk", 0.0 },
                    { 187, "maple syrup", 0.0 },
                    { 188, "ground flax meal", 0.0 },
                    { 189, "coconut", 0.0 },
                    { 190, "ricotta", 0.0 },
                    { 191, "lemon zest", 0.0 },
                    { 192, "blueberries", 0.0 },
                    { 193, "almond extract", 0.0 },
                    { 194, "hamburger patty", 0.0 },
                    { 195, "english muffin", 0.0 },
                    { 196, "pesto", 0.0 },
                    { 197, "provolone cheese", 0.0 },
                    { 198, "bacon", 0.0 },
                    { 199, "banana", 0.0 },
                    { 200, "yoghurt", 0.0 },
                    { 202, "rolled oats", 0.0 },
                    { 116, "hamburger buns", 0.0 },
                    { 117, "potato chips", 0.0 },
                    { 114, "cheddar", 0.0 },
                    { 31, "sourdough bread", 0.0 },
                    { 32, "raw cashews", 0.0 },
                    { 33, "black mustard seeds", 0.0 },
                    { 34, "urad dal", 0.0 },
                    { 35, "asafetida", 0.0 },
                    { 36, "shallot", 0.0 },
                    { 37, "chopped green chile", 0.0 },
                    { 38, "curry leaves", 0.0 },
                    { 39, "ground turmeric", 0.0 },
                    { 40, "small cauliflower florets", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 41, "frozen peas", 0.0 },
                    { 42, "plain full-fat yogurt", 0.0 },
                    { 43, "cilantro", 0.0 },
                    { 44, "fried egg", 0.0 },
                    { 45, "key lime juice", 0.0 },
                    { 46, "large egg yolk", 0.0 },
                    { 47, "condensed milk", 0.0 },
                    { 48, "coarse salt", 0.0 },
                    { 49, "cornstarch", 0.0 },
                    { 50, "cream cheese", 0.0 },
                    { 51, "granulated sugar", 0.0 },
                    { 52, "graham crackers", 0.0 },
                    { 53, "egg white", 0.0 },
                    { 54, "all-purpose flour", 0.0 },
                    { 55, "cake flour", 0.0 },
                    { 30, "neutral oil", 0.0 },
                    { 56, "baking soda", 0.0 },
                    { 29, "salt and pepper", 0.0 },
                    { 27, "spaghetti", 0.0 },
                    { 2, "unsalted butter", 0.0 },
                    { 3, "prepared horseradish", 0.0 },
                    { 4, "kosher salt", 0.0 },
                    { 5, "shrimp", 0.0 },
                    { 6, "chopped dill", 0.0 },
                    { 7, "crusty bread", 0.0 },
                    { 8, "hot pasta", 0.0 },
                    { 9, "sliced red onion", 0.0 },
                    { 10, "salt", 0.0 },
                    { 11, "roasted chicken", 0.0 },
                    { 12, "peppadews peppers", 0.0 },
                    { 13, "marinated artichoke hearts", 0.0 },
                    { 14, "chopped smoked almonds", 0.0 },
                    { 15, "chopped thyme", 0.0 },
                    { 16, "whole-grain mustard", 0.0 },
                    { 17, "sherry vinegar", 0.0 },
                    { 18, "extra virgin olive oil", 0.0 },
                    { 19, "black pepper", 0.0 },
                    { 20, "olive oil", 0.0 },
                    { 21, "garlic", 0.0 },
                    { 22, "olive", 0.0 },
                    { 23, "white fish", 0.0 },
                    { 24, "salted capers", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 25, "white wine", 0.0 },
                    { 26, "chopped tomatoe", 0.0 },
                    { 28, "chopped parsley", 0.0 },
                    { 115, "sweet onion", 0.0 },
                    { 57, "egg", 0.0 },
                    { 59, "buttermilk", 0.0 },
                    { 89, "sea salt", 0.0 },
                    { 90, "baking powder", 0.0 },
                    { 91, "fine sea salt", 0.0 },
                    { 92, "whole milk", 0.0 },
                    { 93, "strawberry pur�e", 0.0 },
                    { 94, "vanilla extract", 0.0 },
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
                    { 112, "chili powder", 0.0 },
                    { 113, "barbecue sauce", 0.0 },
                    { 58, "pure vanilla extract", 0.0 },
                    { 87, "chopped strawberries", 0.0 },
                    { 88, "lemon juice", 0.0 },
                    { 85, "curly pasta", 0.0 },
                    { 60, "cherry tomatoe", 0.0 },
                    { 61, "ear corn", 0.0 },
                    { 62, "large sliced summer squash", 0.0 },
                    { 63, "red onion", 0.0 },
                    { 64, "penne pasta", 0.0 },
                    { 65, "torn basil leaves", 0.0 },
                    { 66, "fresh oregano leaves", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 67, "pine nuts", 0.0 },
                    { 68, "almond flour", 0.0 },
                    { 69, "confectioners' sugar", 0.0 },
                    { 86, "zest of lemon", 0.0 },
                    { 71, "cocoa powder", 0.0 },
                    { 70, "cinnamon", 0.0 },
                    { 73, "mexican chocolate", 0.0 },
                    { 84, "dash pepper", 0.0 },
                    { 83, "dash sea salt", 0.0 },
                    { 82, "basil leaves", 0.0 },
                    { 72, "cream of tartar", 0.0 },
                    { 80, "brie", 0.0 },
                    { 81, "tomatoe", 0.0 },
                    { 78, "dash sugar", 0.0 },
                    { 77, "orzo", 0.0 },
                    { 76, "white pepper", 0.0 },
                    { 75, "chicken stock", 0.0 },
                    { 74, "heavy cream", 0.0 },
                    { 79, "dill sprig", 0.0 }
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
                    { 2, 0, 1, "If you like a good mayonnaise-based chicken salad, but one with more candid flavors, you should try this recipe! With a glass of white wine it feels like the perfect weekend lunch", "https://images.food52.com/OOqBZEjQhcOLodgRlnXoOfVI5RY=/1008x672/filters:format(webp)/d8634211-6145-4329-81ca-711c45e4750a--2017-0427_chicken-salad_james-ransom-297.jpg", "Chicken Salad" },
                    { 22, 0, 4, "Three-bite pancakes topped with blueberries and a creamy maple butter that melts ever so slightly atop the warm pancakes.", "https://images.food52.com/sVihu6JyjCqAfzYCAgi63iumezY=/1008x672/filters:format(webp)/6948eb72-b218-4f07-878d-83a1bd25e1fe--food52_04-17-12-8757.jpeg", "Ricotta Hotcakes with Maple Butter" },
                    { 21, 0, 4, "This recipe has all of the satisfaction and comfort of hot cereal, sans heat, which makes it perfect for summer. Feel free to get creative with toppings and mix-ins!", "https://images.food52.com/96QJqyGLA0LoV4PoKQRX8FtD_Mk=/1008x672/filters:format(webp)/7e8c0fab-197f-419e-9687-d0b826c4e2ba--recipe1.jpg", "Raw Buckwheat Breakfast Porridge" },
                    { 18, 0, 4, "A traditional beef stew from Cuba made with shredded beef that is often served with black beans and rice.", "https://images.food52.com/w-E3753Js_MvtbsBVHEQU_pOAso=/1008x672/filters:format(webp)/9c0278c5-ed16-4912-b8f5-1a3ccd3e5f09--2019-0618_ropa-vieja_3x2_bobbi-lin_4189.jpg", "Ropa Vieja" },
                    { 7, 0, 4, "In the Mexican city of Oaxaca, almonds are ground into a rough paste with cacao, cinnamon, and sugar and hardened into thin fingers of chocolate. The distinctive mixture is used in the city's famous mole sauces and melted into rich hot chocolate which the Oaxacans drink more regularly than coffee. The warm, spicy smell of toasted cacao, cinnamon and almonds fills the city, as crowded storefront grinders are endlessly turning and the mercado stalls are crowded with vendors selling secret family recipes. Ideal for inspiration and make macarons with the same flavors", "https://images.food52.com/fLevsOXvNogpjdYZFItNUwPVf-4=/1008x672/filters:format(webp)/3e4baffa-29dc-4e2e-aa6a-2f42f1f4414a--033010F_869.JPG", "Oaxacan Cinnamon Chocolate Macarons" },
                    { 5, 0, 4, "Key Lime Cake tastes like summer. Beachy. Floral. Have you ever rubbed your fingers across a wicker armrest and gotten lost in the undulating cords like waves", "https://images.food52.com/NL2-zUmt3I_hFG3qnUfdKY6-bZQ=/1008x672/filters:format(webp)/7247d84f-cd2f-49ab-af78-4714ce5b0f92--Fruit_Cake_Key_Lime_Cake.jpg", "Key Lime Cake" },
                    { 29, 0, 3, "This fondue is silken and almost custardy, punctuated with rum and vanilla and generously salted, the way we like caramel to be. Not surprisingly, it is quite rich and sweet, and we found our favorite dipping instrument ended up being salty, extra-dark pretzels.", "https://images.food52.com/jIsJ6SEO8_LtNjMw9Z5y9280PGM=/1008x672/filters:format(webp)/d687384c-0945-4379-925a-2955606b8b3c--022211F_206.JPG", "Coconut Cajeta & Chocolate Fondue" },
                    { 28, 0, 3, "Sandwich buttery caramel between layers of melted semisweet chocolate and finely chopped almonds.", "https://images.food52.com/1cN4KGunMq_qzcugQa6d3RXPZPA=/1008x672/filters:format(webp)/3a109bf4-c892-44c9-ab26-ec940081fa9a--2014-1124_chocolate-almond-toffee-010.jpg", "Scottish Toffee" },
                    { 27, 0, 3, "Somewhere pleasantly between pumpkin and butterscotch, a very original take on a seasonal loaf cake. Your whole house will smell like rich, nutty brown butter since it's in both the cake and the icing.", "https://images.food52.com/73wSsJKEia05pf9F0ZZqTQLBk5c=/1008x672/filters:format(webp)/31eb95c5-4299-4321-a66d-877ae5625628--2016-0204_brown-butter-and-butternut-loaf_james-ransom-012.jpg", "Brown Butter and Butternut Loaf" },
                    { 24, 0, 3, "This muffin recipe is loaded with fruit, veggies and nuts so it gives you everything you need for a little morning or afternoon pick up!", "https://images.food52.com/69T0RTYvZH4VEMs_hhnxNyvOCwE=/1008x672/filters:format(webp)/717fccd2-48db-4812-830f-3eeaa4435e00--IMG_8013.JPG", "Breakfast carrot cake muffins" },
                    { 13, 0, 3, "My take on boeuf bourguignon skips a couple ingredients�namely the bacon, whose fat traditionally adds luscious flavor to the classic French stew, and the flour, which would otherwise serve as a thickener for the sauce. I find that boneless beef short ribs, which are marbled with fat and collagen, do all the heavy lifting in this recipe and help you arrive at a final stew that�s just as glossy, satisfying, and full of deep, savory flavor as the original.", "https://images.food52.com/T4h0NggW-s84P3TvGLm2e556Xuk=/1008x672/filters:format(webp)/8ed76823-4e2e-45e0-b8be-a459eb1a915c--2020-0303_boeuf-bourguignon-for-one_3x2_ty-mecham.jpg", "Beef Short Rib Bourguignon With Garlicky Panko Gremolata" },
                    { 10, 0, 3, "This is variant on the boxed strawberry cake but made with fresh strawberries. It takes a bit of time to reduce the strawberry mixture to a thick, jammy pur�e, but it's worth it, since it gets used both in the cake and also the frosting to create a beautiful - and delicious - swirl effect. Its best decorated with lemon wedges and/or strawberries but you can never miss with sprinkles", "https://images.food52.com/TRW26JcClLEecmYmv3tOpia1DXY=/1008x672/filters:format(webp)/157f3d99-a272-4002-9353-867d70731001--2021-0512_strawberry-lemonade-cupcakes_4x5_julia-gartland_063.jpg", "Strawberry Lemonade Cupcakes" },
                    { 9, 0, 3, "Alot of people make a summer pasta alla Caprese like this: the pasta�raw garlic or onion, tomatoes, basil, olive oil and fresh mozzarella. This recipe replaces the mozarella with brie. A bold but satisfying choice! A fine Brie is just as delicious at room temperature smeared on crusty bread as it is warm, oozing out of flaky pastry. And it's REALLY good folded into a fresh tomatoey, garlicky sauce for pasta. Put aside any residual anti-Brie sentiments and give this one a shot before tomatoes disappear for the year. You won't regret it", "https://images.food52.com/i8P83CvSSFTTVWinAuWJuXqAHFo=/1008x672/filters:format(webp)/547d4b4b-dfa0-494a-9415-04a97a103f05--20120804_food52_08-20-12-1466.jpg", "Pasta with Tomatoes, Garlic, Basil & Brie" },
                    { 17, 0, 2, "These mince and cheese pies feature ground beef encased in a thick, dark, beefy gravy interspersed with pockets of melted white cheddar cheese.", "https://images.food52.com/EYhpqWDzO1OpxcmCUmsQF8FjQDg=/1008x672/filters:format(webp)/936c251b-b56b-4e31-8407-71ea86c72f3e--2018-0308_new-zealand-gas-station-beef-cheese-pies_3x2_james-ransom-0122.jpg", "New Zealand-Style Beef & Cheddar Pies" },
                    { 15, 0, 2, "This stovetop blue cheese burger recipe makes a single portion. But because it's exactly for one, the math to double or quadruple or octuple the patty is fairly simple. Scale up as many times as you want�no matter what you do, make a lot of the blue cheese mayo. You won't be sorry.", "https://images.food52.com/choh0ovckbNRzRvpo6Y7hXBOjqU=/1008x672/filters:format(webp)/f55f7e17-489f-43ac-9097-a9da39d9701b--2019-0618_blue-cheese-burger-for-one_3x2_bobbi-lin_4166.jpg", "Blue Cheese Burger" },
                    { 12, 0, 2, "A way to combine some tailgate favorites: burgers, barbecue, and chips. You will need either a cold beer or a Texas tea to wash this bad boy down!", "https://images.food52.com/GbbciGi20Daa9DrE_TDPc63Ty2g=/1008x672/filters:format(webp)/133eb19c-b40f-46cb-a8c5-0251afd60969--2014-0715_jalapeno-cheddar-burger-004.jpg", "Texas Tailgate Burger" },
                    { 8, 0, 2, "The name of this classic Greek soup emulsion of lemon and eggs comes from its two main ingredients: egg (avgo) and lemon juice (lemono). The key to this soup is tempering the egg and lemon mixture by slowly adding hot stock and then whisking constantly to prevent the eggs from curdling. You then stir the mixture into the soup, which becomes all velvety lush lemony goodness. A Greek salad and warm pita bread are wonderful accompaniments to this soup", "https://images.food52.com/Y4T3Uk-cKn799bjhWySmQJ9YxIA=/1008x672/filters:format(webp)/2311e33a-47e9-4504-99e4-dd3d61337348--2017-1212_egglands-best-sponsored_greek-soup-holiday_3x2_mark-weinberg_0128.jpg", "Greek Lemon Soup - Avgolemono" },
                    { 1, 0, 2, "A simple scampi-inspired dinner that needs neither a lot of time nor a lot of ingredients. The key is to swiftly simmer the shrimp and to rely on extrovert ingredients for seasoning. Lemon juice and lemon zest deliver loads of sunny acidity. So much so that we are also using water, not stock, to stretch the brightness, and to ensure that there is enough sauce for bread-sopping", "https://images.food52.com/_51_B8XLkaL7wou2THrl1WXuadA=/1008x672/filters:format(webp)/3871c07e-9765-4a8d-9fdd-2f996094b105--2021-0518_speedy-shrimp_3x2_james-ransom-031.jpg", "Speedy Shrimp With Horseradish�Butter" },
                    { 30, 0, 1, "Lighter, frothier, and more refined than your classic one-cup-and-you're-out eggnog, this playful variation will keep the party going strong. The cognac shines through in every sip, so be sure to crack open the good stuff.", "https://images.food52.com/V1FO_XjnoNVhshY7CHZ9bnDMUBI=/1008x672/filters:format(webp)/7b1c12c1-1c2e-40ba-a391-ffa89d9ce499--2015-1207_warm-egg-nog_james-ransom-022_1-.jpg", "Warm Eggnog" },
                    { 26, 0, 1, "Whisk up your chia, toss on some superfood berries, like goji berries, goldenberries, and mulberries, a few cashews, and bam. Rockin' raw vegan power breakfast.", "https://images.food52.com/9R1JMNstuZlJ6-7HTlJEsnD2dLs=/1008x672/filters:format(webp)/0cb64378-a8e1-4ce2-a61a-15160e607ef2--Superfood_Berry_Chia_Breakfast.jpg", "Superfood Berry Chia Breakfast" },
                    { 20, 0, 1, "For the uninitiated, a Juicy Lucy is a burger where the cheese is set inside the beef instead of on top. The result of hot beef fat dripping onto a highly meltable cheese results in a molten concoction that brings immense amounts of joy.", "https://images.food52.com/KSs_q5YjQ-eGX1oG4bpHldx127I=/1008x672/filters:format(webp)/4b97e80b-0b9a-4522-8876-4a83015b2091--2018-0123_juicy-lucy-2-ways_3x2_james-ransom_0231.jpg", "Minnesota Juicy Lucy" },
                    { 19, 0, 1, "For the best traditional meatloaf recipe relying on the classic triumvirate of ground veal, beef and pork. A little bread and milk. Garlic, onion and Worcestershire sauce. All are thoughtfully balanced, producing a savory, light-textured loaf.", "https://images.food52.com/SEoIY3KjCVcA_NwGD52FNaXydYM=/1008x672/filters:format(webp)/29e35312-3021-4491-9662-2d6d6f41b35e--2019-0423_meatloaf-with-blackberry-bbq-sauce_3x2_julia-gartland_0929.jpg", "Meatloaf with Blackberry Barbecue Sauce" },
                    { 16, 0, 1, " A go-to, weeknight torta with steak, beans, jalape�os, and avocado. That comes together in under an hour.", "https://images.food52.com/qgtCvxOACjNWH-Q8rPfNOzMQZYE=/1008x672/filters:format(webp)/f0e586ed-75e1-4d0b-a902-b2523e570638--2014-0923_steak-and-bean-torta-018.jpg", "Steak and Bean Torta" },
                    { 14, 0, 1, "An American-Korean hybrid, much sweeter than traditional bulgogi, served on a bed of white rice.", "https://images.food52.com/8uquQ9jEsWl-YGubwhZZbfEXSBo=/1008x672/filters:format(webp)/59d62ed1-e083-404e-ad5a-34876e435dac--2018-0503_moms-bulgogi-cucumber-kimchi-salad_3x2_rocky-luten_049.jpg", "Bulgogi with Cucumber Kimchi Salad" },
                    { 11, 0, 1, "We love a good pot of chili, and our kitchen has turned out dozens of variations over the years. Boneless grass-fed beef short ribs, trimmed and cut into chunks, with a puree of chiles and spices, added fire-roasted tomatoes and some rich dark beer.", "https://images.food52.com/VZkTIa68tHfebPSUso6QEyFV5X0=/1008x672/filters:format(webp)/2535541d-3f88-433e-b52e-43d8ea83350e--food52_02-07-12-8044.jpeg", "Short Rib Chili" },
                    { 6, 0, 1, "Think of this recipe as summer in a bowl. The sweet corn, bursting cherry tomatoes, and tender zucchini lighten up a savory, satisfying bowl of pasta. Proof that meatless dishes can be quick, easy, and a joy to eat", "https://images.food52.com/9-Z62AhfnO7vECg7gARyZVGIW9A=/1008x672/filters:format(webp)/fc3db569-3b62-4126-a92c-9598b7fdb120--food52_07-24-12-7723.jpg", "Penne with Sweet Summer Vegetables, Pine Nuts and�Herbs" },
                    { 4, 0, 1, "People know upma as a South Indian breakfast staple, but its more. Upma is a state of mind. The refrain is simple: Carb of choice, toasted in ghee-bloomed spices, then cooked with assorted vegetables and curry leaves and topped with tomato ketchup. In South India the carb of choice is typically toasted semolina, thickened into a creamy, savory porridge. But it can also be made with bread. Bread upma can be made in two contrasting ways. This version captures the best of both", "https://images.food52.com/38ws8x4bhNB0a9zHq6ZSduhKXCY=/1008x672/filters:format(webp)/eb712a59-16c6-4f57-a6cf-8e523aa97e4e--2021-0312_bread-upma_3x2_mark-weinberg-193.jpg", "My Favorite Bread Upma" },
                    { 3, 0, 1, "Fish Pasta can be made with any flakey white fish. Snapper good but its best with fresh striped bass. Be very careful stirring the sauce: the fish should remain intact. The tomatoes should be fresh and cooked al crudo, till the juices are released but they are still a little raw. By adding the fish early on, its flavor infuses the whole sauce, so the tomatoes and fish are no longer separate entities, but fully integrated into the sauce. And the capers and olives reinforce the flavor of the fish with brine", "https://images.food52.com/mlooIQOUxc3VtpQefZvmZiUY1Jw=/1008x672/filters:format(webp)/0afceb53-8c13-4b96-82ba-45235cf98176--fishpastalowres_2417.JPG", "Fish Pasta" },
                    { 23, 0, 4, "Who said burgers were for dinner? When piled high with bacon and a delicate fried egg and then smashed between a toasted english muffin, they are just begging to be eaten for breakfast.", "https://images.food52.com/vi8yjvxGPI4PY1tXj1YPwpZ9k-Q=/1008x672/filters:format(webp)/cca18c11-98fa-4c59-8214-bf08030b3be5--Jun_17_2014_2674_edited-1.jpg", "Pesto Bacon Breakfast Burger" },
                    { 25, 0, 4, "These bars are gluten free, refined sugar free and oil free. The only fat is the natural fat in the quinoa. They are packed with slow release energy and lean proteins as well as essential amino acids.", "https://images.food52.com/8Kp-okomWEUp51v5gcP5Dgzs19g=/1008x672/filters:format(webp)/7be5de7c-5360-44ca-83a4-ce794b42da42--NobakequinoabarsF52_copy.jpg", "No bake quinoa breakfast bar" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 9, "1/4 cup", 9, 2 },
                    { 156, "1 pinch", 19, 13 },
                    { 155, "1 pinch", 10, 13 },
                    { 154, "1/2 pound boneless", 102, 13 },
                    { 121, "1/2 cup", 96, 10 },
                    { 120, "1/4 cup", 95, 10 },
                    { 119, "1 pinch", 72, 10 },
                    { 118, "1 teaspoon", 94, 10 },
                    { 117, "1/3 cup", 93, 10 },
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
                    { 104, "1 pound", 85, 9 },
                    { 103, "1", 84, 9 },
                    { 102, "1", 83, 9 },
                    { 157, "2 tablespoons", 20, 13 },
                    { 158, "1 large", 36, 13 },
                    { 159, "4 cloves", 21, 13 },
                    { 160, "1 tablespoon", 105, 13 },
                    { 317, "150 grams", 203, 24 },
                    { 316, "100 grams", 202, 24 },
                    { 315, "1 teaspoon", 70, 24 },
                    { 314, "1 teaspoon", 90, 24 },
                    { 313, "2-3", 125, 24 },
                    { 312, "1", 201, 24 },
                    { 311, "1", 57, 24 },
                    { 310, "150 grams plain", 200, 24 },
                    { 309, "1", 199, 24 },
                    { 308, "70 milliliters", 187, 24 },
                    { 307, "60 milliliters", 20, 24 },
                    { 101, "3/4 cup", 20, 9 },
                    { 173, "1 teaspoon", 20, 13 },
                    { 171, "1/2 zested", 1, 13 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 170, "2 tablespoons", 127, 13 },
                    { 169, "", 126, 13 },
                    { 168, "2 small", 125, 13 },
                    { 167, "4 ounces", 124, 13 },
                    { 166, "2 teaspoons", 123, 13 },
                    { 165, "1 cup", 95, 13 },
                    { 164, "1 cup", 122, 13 },
                    { 163, "1", 98, 13 },
                    { 162, "1 teaspoon", 121, 13 },
                    { 161, "1/2 teaspoon crushed", 120, 13 },
                    { 172, "1/4 cup chopped fresh", 128, 13 },
                    { 100, "1/2 cup", 82, 9 },
                    { 99, "2 cloves", 21, 9 },
                    { 98, "4", 81, 9 },
                    { 152, "1 piece", 118, 12 },
                    { 151, "1 handful barbecue-flavored", 117, 12 },
                    { 150, "6", 116, 12 },
                    { 149, "1/2 cup diced", 115, 12 },
                    { 148, "2 cups shredded", 114, 12 },
                    { 147, "1 1/2 cups", 113, 12 },
                    { 146, "1 teaspoon", 112, 12 },
                    { 145, "1 teaspoon", 19, 12 },
                    { 144, "1 teaspoon", 10, 12 },
                    { 143, "1 cup", 111, 12 },
                    { 142, "2 pounds", 110, 12 },
                    { 153, "1 handful chopped", 119, 12 },
                    { 96, "1", 79, 8 },
                    { 94, "3", 1, 8 },
                    { 93, "4", 57, 8 },
                    { 92, "1", 78, 8 },
                    { 91, "1 1/2 cup", 77, 8 },
                    { 90, "1/2 teaspoon", 76, 8 },
                    { 89, "1 1/2 teaspoons", 4, 8 },
                    { 88, "8 cups", 75, 8 },
                    { 8, "", 8, 1 },
                    { 7, "", 7, 1 },
                    { 6, "1 handful", 6, 1 },
                    { 5, "1 pound", 5, 1 },
                    { 95, "1/4 cup", 6, 8 },
                    { 318, "100 grams chopped", 204, 24 },
                    { 187, "1/4 cup", 139, 15 },
                    { 189, "1 1/2 ounces strong", 141, 15 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 97, "3/4 pound", 80, 9 },
                    { 233, "1", 57, 17 },
                    { 232, "3/4 cup (100g) aged white", 163, 17 },
                    { 231, "2 450-gram packages pre-rolled", 162, 17 },
                    { 230, "1 teaspoon", 123, 17 },
                    { 229, "1 1/2 cups", 161, 17 },
                    { 228, "3 tablespoons", 160, 17 },
                    { 227, "1/2 teaspoon", 10, 17 },
                    { 226, "1 pound lean", 110, 17 },
                    { 225, "1 clove", 21, 17 },
                    { 224, "1 small finely diced", 99, 17 },
                    { 188, "1 teaspoon", 140, 15 },
                    { 223, "1 tablespoon", 20, 17 },
                    { 201, "1", 147, 15 },
                    { 200, "Grape-seed or other high-heat", 146, 15 },
                    { 199, "1/2 teaspoon ground", 70, 15 },
                    { 198, "1/2 teaspoon ground", 145, 15 },
                    { 197, "1 teaspoon", 123, 15 },
                    { 196, "1 tablespoon raw grated", 99, 15 },
                    { 195, "1/4 pound", 144, 15 },
                    { 193, "1 pinch", 4, 15 },
                    { 192, "1 pinch", 137, 15 },
                    { 191, "1/4 teaspoon", 143, 15 },
                    { 190, "1/2 teaspoon fresh", 142, 15 },
                    { 202, "1 small handful", 148, 15 },
                    { 4, "", 4, 1 },
                    { 319, "", 205, 24 },
                    { 340, "3 large", 57, 27 },
                    { 288, "1/2 cup", 174, 22 },
                    { 287, "2 cups", 190, 22 },
                    { 286, "1/3 cup shredded unsweetened", 189, 21 },
                    { 285, "1 pinch", 89, 21 },
                    { 284, "1 tablespoon", 188, 21 },
                    { 283, "1 teaspoon", 94, 21 },
                    { 282, "1 teaspoon", 70, 21 },
                    { 281, "1/4 cup", 187, 21 },
                    { 280, "1 cup", 186, 21 },
                    { 279, "2 cups", 185, 21 },
                    { 249, "1/4 cup chopped fresh", 128, 18 },
                    { 248, "1 cup", 170, 18 },
                    { 247, "16 ounces", 169, 18 },
                    { 246, "1 cup", 168, 18 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 245, "1/2 cup dry", 25, 18 },
                    { 244, "2 teaspoons sweet", 150, 18 },
                    { 243, "2 teaspoons", 167, 18 },
                    { 242, "1 teaspoon dried", 104, 18 },
                    { 241, "6 cloves", 21, 18 },
                    { 240, "1 large", 166, 18 },
                    { 239, "1 large", 165, 18 },
                    { 238, "1 large", 103, 18 },
                    { 237, "1/4 cup", 20, 18 },
                    { 289, "4", 57, 22 },
                    { 290, "1 tablespoon", 137, 22 },
                    { 291, "1 cup", 160, 22 },
                    { 292, "1 teaspoon", 90, 22 },
                    { 329, "100ml Fresh ", 214, 25 },
                    { 328, "Small piece fresh", 213, 25 },
                    { 327, "3", 212, 25 },
                    { 326, "1 tablespoon", 211, 25 },
                    { 325, "2 tablespoons", 210, 25 },
                    { 324, "25g", 209, 25 },
                    { 323, "6 ", 208, 25 },
                    { 322, "25g", 207, 25 },
                    { 321, "50g flaked", 204, 25 },
                    { 320, "150g ", 206, 25 },
                    { 306, "2 tablespoons Pickled", 63, 23 },
                    { 236, "", 151, 18 },
                    { 305, "1 Fried", 57, 23 },
                    { 303, "1 piece", 197, 23 },
                    { 302, "2 tablespoons", 196, 23 },
                    { 301, "1 toasted", 195, 23 },
                    { 300, "1 Grilled", 194, 23 },
                    { 299, "1/2 teaspoon", 193, 22 },
                    { 298, "1/4 cup", 187, 22 },
                    { 297, "1/2 cup softened", 184, 22 },
                    { 296, "2 cups", 192, 22 },
                    { 295, "1 tablespoon", 184, 22 },
                    { 294, "1/2 teaspoon", 191, 22 },
                    { 293, "1/4 teaspoon", 10, 22 },
                    { 304, "2 pieces Thick Sliced", 198, 23 },
                    { 235, "", 10, 18 },
                    { 234, "2 pounds", 164, 18 },
                    { 87, "2 tablespoons", 74, 7 },
                    { 364, "3 tablespoons", 226, 29 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 363, "2 teaspoons", 94, 29 },
                    { 362, "3 ounces bittersweet", 225, 29 },
                    { 361, "3/4 teaspoon", 4, 29 },
                    { 360, "1 cup", 178, 29 },
                    { 359, "2 13.5 ounce cans", 224, 29 },
                    { 358, "", 89, 28 },
                    { 357, "1 teaspoon", 94, 28 },
                    { 356, "1 pinch", 4, 28 },
                    { 355, "1 cup", 129, 28 },
                    { 354, "1 cup", 2, 28 },
                    { 47, "1/2 cup", 45, 5 },
                    { 353, "18 ounces", 223, 28 },
                    { 351, "1 teaspoon", 94, 27 },
                    { 350, "1 1/2 cups", 222, 27 },
                    { 349, "5 tablespoons", 221, 27 },
                    { 348, "1/2 teaspoon ground", 220, 27 },
                    { 347, "2 teaspoons", 56, 27 },
                    { 346, "2 teaspoons", 90, 27 },
                    { 345, "1 teaspoon", 10, 27 },
                    { 344, "3 cups", 160, 27 },
                    { 343, "2 cups pureed roasted", 219, 27 },
                    { 342, "1/2 cup packed", 178, 27 },
                    { 341, "1 1/2 cups", 137, 27 },
                    { 352, "1 cup finely chopped", 204, 28 },
                    { 339, "1 cup", 2, 27 },
                    { 48, "4", 46, 5 },
                    { 50, "1 pinch", 48, 5 },
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
                    { 64, "1/2 cup", 59, 5 },
                    { 49, "14 ounce", 47, 5 },
                    { 63, "1 tablespoon", 58, 5 },
                    { 61, "1/4 teaspoon", 56, 5 },
                    { 60, "1/2 teaspoon", 48, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 59, "1 1/2 cups", 55, 5 },
                    { 58, "1/3 cup", 54, 5 },
                    { 57, "1/4 cup", 30, 5 },
                    { 56, "4", 53, 5 },
                    { 55, "1/2 cup", 52, 5 },
                    { 54, "1/4 cup", 45, 5 },
                    { 53, "2 1/4 cup", 51, 5 },
                    { 52, "1 cup", 50, 5 },
                    { 51, "2 tablespoons", 49, 5 },
                    { 62, "6", 57, 5 },
                    { 3, "2 tablespoons", 3, 1 },
                    { 194, "", 19, 15 },
                    { 1, "2", 1, 1 },
                    { 177, "4 tablespoons", 132, 14 },
                    { 176, "5 tablespoons", 131, 14 },
                    { 175, "1 1/2 cups", 130, 14 },
                    { 174, "3 cups packed light", 129, 14 },
                    { 2, "3 tablespoons", 2, 1 },
                    { 140, "1/2 cup", 108, 11 },
                    { 139, "1 cup", 107, 11 },
                    { 138, "1.28oz", 106, 11 },
                    { 137, "1 tablespoon", 105, 11 },
                    { 136, "1 tablespoon", 104, 11 },
                    { 135, "2 large cloves", 21, 11 },
                    { 134, "2 cups", 103, 11 },
                    { 133, "1 splash", 30, 11 },
                    { 132, "1 1/2 pounds boneless", 102, 11 },
                    { 131, "1 kosher", 89, 11 },
                    { 130, "1 tablespoon", 71, 11 },
                    { 129, "1/2 teaspoon", 70, 11 },
                    { 128, "1 teaspoon", 48, 11 },
                    { 127, "1 tablespoon", 101, 11 },
                    { 126, "4", 100, 11 },
                    { 125, "1", 99, 11 },
                    { 178, "4", 133, 14 },
                    { 179, "4 cloves", 21, 14 },
                    { 180, "1 teaspoon", 19, 14 },
                    { 181, "4 to 5 pounds thinly sliced", 134, 14 },
                    { 219, "", 157, 16 },
                    { 218, "2 teaspoons", 156, 16 },
                    { 217, "1/2 teaspoon", 155, 16 },
                    { 216, "1/4 teaspoon", 154, 16 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 215, "1 can", 153, 16 },
                    { 214, "1", 111, 16 },
                    { 213, "1 small", 63, 16 },
                    { 212, "1 teaspoon", 137, 16 },
                    { 211, "1/2 teaspoon", 10, 16 },
                    { 210, "1/4 cup", 95, 16 },
                    { 124, "1", 98, 11 },
                    { 209, "1/2 cup", 17, 16 },
                    { 207, "2 tablespoons", 146, 16 },
                    { 206, "1 teaspoon", 151, 16 },
                    { 205, "1 teaspoon smoked", 150, 16 },
                    { 204, "1 teaspoon", 149, 16 },
                    { 203, "2 cloves", 21, 16 },
                    { 186, "1/2 to 1 teaspoons", 4, 14 },
                    { 185, "1 teaspoon", 138, 14 },
                    { 184, "2 teaspoons", 137, 14 },
                    { 183, "1 to 2 teaspoons", 136, 14 },
                    { 182, "2 English", 135, 14 },
                    { 208, "1 pound", 152, 16 },
                    { 123, "2 1/2 cups", 95, 11 },
                    { 122, "1/2 pound", 97, 11 },
                    { 76, "1/4 cup", 67, 6 },
                    { 31, "2 tablespoons", 30, 4 },
                    { 30, "", 29, 3 },
                    { 29, "2 tablespoon", 28, 3 },
                    { 28, "1 packet", 27, 3 },
                    { 27, "4", 26, 3 },
                    { 26, "1/2 glass", 25, 3 },
                    { 25, "1 tablespoon", 24, 3 },
                    { 24, "1 pound", 23, 3 },
                    { 23, "12", 22, 3 },
                    { 22, "2 cloves", 21, 3 },
                    { 32, "4 slices", 31, 4 },
                    { 21, "3 tablespoons", 20, 3 },
                    { 19, "1/4 cup", 18, 2 },
                    { 18, "1", 1, 2 },
                    { 17, "1 tablespoon", 17, 2 },
                    { 16, "1 tablespoon", 16, 2 },
                    { 15, "2 teaspoons", 15, 2 },
                    { 14, "1/4 cup", 14, 2 },
                    { 13, "1 cup", 13, 2 },
                    { 12, "3 tablespoons", 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 11, "4 cups", 11, 2 },
                    { 10, "", 10, 2 },
                    { 20, "", 19, 2 },
                    { 220, "sliced", 158, 16 },
                    { 33, "1/4 cup", 32, 4 },
                    { 35, "1/2 teaspoon", 34, 4 },
                    { 75, "", 19, 6 },
                    { 74, "", 48, 6 },
                    { 73, "1 tablespoon", 66, 6 },
                    { 72, "1/3 cup", 65, 6 },
                    { 71, "8 ounces", 64, 6 },
                    { 70, "4 tablespoons", 20, 6 },
                    { 69, "2 cloves", 21, 6 },
                    { 68, "1 large chopped ", 63, 6 },
                    { 67, "2", 62, 6 },
                    { 66, "2", 61, 6 },
                    { 34, "1/2 teaspoon", 33, 4 },
                    { 65, "2", 60, 6 },
                    { 45, "1/4 cup roughly chopped", 43, 4 },
                    { 44, "1/4 cup", 42, 4 },
                    { 43, "1/4 cup", 41, 4 },
                    { 42, "1 cup", 40, 4 },
                    { 41, "1/2 teaspoon", 39, 4 },
                    { 40, "6", 38, 4 },
                    { 39, "1 teaspoon", 4, 4 },
                    { 38, "1", 37, 4 },
                    { 37, "1", 36, 4 },
                    { 36, "1 pinch", 35, 4 },
                    { 46, "2", 44, 4 },
                    { 221, "", 43, 16 },
                    { 141, "1", 109, 11 },
                    { 268, "(for sauce) generous pinch", 10, 19 },
                    { 277, "4 soft", 116, 20 },
                    { 334, "2 tablespoons", 215, 26 },
                    { 335, "2 tablespoons", 216, 26 },
                    { 371, "1 cup", 229, 30 },
                    { 370, "1 tablespoon", 94, 30 },
                    { 369, "1/2 cup", 228, 30 },
                    { 259, "1", 57, 19 },
                    { 260, "3/4 cup", 174, 19 },
                    { 261, "3 pieces", 175, 19 },
                    { 262, "(for sauce) 2 small quartered", 176, 19 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 263, "(for sauce) 2 cloves", 21, 19 },
                    { 264, "(for sauce) 2 cups", 177, 19 },
                    { 368, "4 cups", 92, 30 },
                    { 367, "1/8 teaspoon", 10, 30 },
                    { 278, "1 tablespoon", 184, 20 },
                    { 366, "3/4 cup granulated", 137, 30 },
                    { 336, "2 tablespoons", 217, 26 },
                    { 337, "2 tablespoons", 32, 26 },
                    { 338, "1 teaspoon Raw", 218, 26 },
                    { 265, "(for sauce) 1/2 cup", 178, 19 },
                    { 266, "(for sauce) 1 tablespoon", 179, 19 },
                    { 267, "(for sauce) 1 teaspoon", 180, 19 },
                    { 269, "(for sauce) generous pinch", 19, 19 },
                    { 276, "Sliced", 183, 20 },
                    { 275, "1", 103, 20 },
                    { 274, "", 182, 20 },
                    { 273, "", 151, 20 },
                    { 270, "2 pounds", 110, 20 },
                    { 272, "", 10, 20 },
                    { 271, "4 slices", 181, 20 },
                    { 365, "8 large", 227, 30 },
                    { 332, "1 teaspoon", 94, 26 },
                    { 333, "1/2 teaspoon Ground", 70, 26 },
                    { 255, "1/2 teaspoon", 4, 19 },
                    { 330, "2 tablespoons", 211, 26 },
                    { 372, "1", 220, 30 },
                    { 251, "1/2 pound", 171, 19 },
                    { 252, "1/2 pound", 172, 19 },
                    { 253, "1/2 cup diced", 103, 19 },
                    { 254, "1/2 teaspoon", 173, 19 },
                    { 222, "", 159, 16 },
                    { 331, "1/2 cup", 186, 26 },
                    { 257, "3 cloves", 21, 19 },
                    { 258, "1 tablespoon", 123, 19 },
                    { 250, "1/2 pound", 110, 19 },
                    { 256, "1/2 teaspoon cracked", 19, 19 }
                });

            migrationBuilder.InsertData(
                table: "RecipeRatings",
                columns: new[] { "RecipeId", "UserId", "Comment", "Rating" },
                values: new object[,]
                {
                    { 2, 1, "Awful sweet", 10.0 },
                    { 1, 1, "Verrrrrrrrry sweet", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 159, 0, "After 30 minutes or in the morning, top with berries and cashews.", false, 26 },
                    { 158, 0, "Start by soaking your chia seeds in the sunflower or almond milk. Whisk well with a fork and make sure to break up any clumps. Whisk in the vanilla powder and cinnamon. Let sit for 5 minutes, stir again, and place in the fridge 30 minutes or overnight.", false, 26 },
                    { 70, 0, "bring stock to a boil in a large saucepan. Lower heat to a simmer and add salt, pepper, and orzo. Cook until al dente, about 8 minutes. Remove from heat. Set aside 2 cups of stock", false, 8 },
                    { 69, 0, "When the cookies and filling are cool, spread or pipe the ganache on the flat side of one macaron and create a sandwich with a second one", false, 7 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 34, 0, "Add the onions, chile, salt, turmeric, curry leaves and stir to combine", false, 4 },
                    { 28, 0, "carefully add the sauce to the pasta over a little heat and stir gently for a minute or two", false, 3 },
                    { 35, 0, "raise the heat to medium-high and cook until the onions have softened and turned translucent", false, 4 },
                    { 36, 0, "Add the cauliflower florets and stir, cooking for 3 to 5 minutes longer until they have softened and are completely coated with the spice and onion mixture", false, 4 },
                    { 54, 0, "Serve at cool room temperature", false, 5 },
                    { 27, 0, "cook pasta al dente", false, 3 },
                    { 33, 0, "Add the mustard seeds, urad dal and asafetida and shake the pan vigorously to coat everything in the fat. In 20 to 30 seconds the seeds will burst and the dal will become a deeply golden-brown color", false, 4 },
                    { 32, 0, "Lower the flame to medium and add the second tablespoon of cooking fat to the pan, heating until its shimmering", false, 4 },
                    { 29, 0, "In a wok set over medium-high heat, add 1 tablespoon of oil and heat until shimmering", false, 4 },
                    { 71, 0, "beat egg whites in a medium-size bowl until soft peaks form", false, 8 },
                    { 72, 0, "Beat in the egg yolks and lemon juice. Pour 2 cups of reserved hot stock slowly into the lemon and egg mixture, whisking continuously until all is incorporated. Return soup to medium-low heat and whisk in lemon-egg mixture. Add chicken stock back into the soup and simmer until thickened slightly, about 20 minutes", false, 8 },
                    { 73, 0, "ladle into warm bowls and garnish with white pepper, chopped dill, a dill sprig, and sliced lemon", false, 8 },
                    { 30, 0, "Add the cubed bread and raw cashews to the pan and toast in oil until crunchy and golden brown, shaking the pan frequently and tossing the bread so it doesn't burn. This will take 5 to 6 minutes", false, 4 },
                    { 68, 0, "Make ganache while the cookies cool. Melt chocolate in double boiler. Whisk in heavy cream and butter and stir mixture over gently boiling water until it is smooth and shiny", false, 7 },
                    { 140, 0, "Place your buns down on the pan and lightly toast to warm through (30 seconds-1 minute). Place your burgers on the buns, top with the onions and pickle chips, and enjoy!", false, 20 },
                    { 61, 0, "Measure egg whites and allow to sit at room temperature for 24 hours in a covered bowl. Aging the whites helps them thin and will create a better textured macaron", false, 7 },
                    { 62, 0, "Line two cookie pans with parchment paper and trace 1.5 inch circles on the paper, keeping the circles about one inch apart. Preheat your oven to 300 degrees F", false, 7 },
                    { 63, 0, "Pulse the almond flour, confectioners' sugar, cinnamon, and cocoa in a food processor until it is a finely mixed powder. Sift into a large bowl", false, 7 },
                    { 64, 0, "Put egg whites in stainless steel bowl and beat on low with a hand mixer until frothy. Add salt and cream of tartar, and slowly mix in the granulated sugar. Once the sugar is all incorporated, increase mixer speed to medium and beat until meringue forms stiff peaks.The meringue should look glossy and remain in place when the bowl is tipped on its side", false, 7 },
                    { 26, 0, "when the tomato juice is released and the sauce is just thickening, turn off heat", false, 3 },
                    { 65, 0, "Using a silicone spatula, fold the almond and sugar mixture into the egg whites one-third at a time. You do not have to be gentle, instead use brisk strokes to fold the mixture together completely, this will help reduce the air in the meringue and keep the macaroons from being too puffy", false, 7 },
                    { 66, 0, "Spoon the mixture into a pastry bag or a ziplock. If using a zip-top bag, cut off a 1/4-inch tip from the corner. Pipe the mixture in a spiral to fill each 1.5-inch circle on the parchment paper. Allow the unbaked cookies to sit out for 30 minutes, until the cookies have a matte texture and are no longer sticky", false, 7 },
                    { 67, 0, "Bake for 12 to 15 minutes. Allow to cool and then peel very gently off the parchment paper", false, 7 },
                    { 31, 0, "Remove the toasted bread and cashews and set aside", false, 4 },
                    { 125, 0, "Season beef liberally with salt and freshly ground black pepper.", false, 18 },
                    { 113, 0, "Mix together the garlic, onion powder, paprika, pepper, and 2 tablespoons of oil. Toss the steak in the marinade to coat and let it sit at room temperature 30 minutes or refrigerate it for up to 8 hours. Heat the grill to medium-high. Season the steak with salt and grill until its internal temperature reaches 125 degrees F and it is nicely browned. Let the steak rest for ten minutes before slicing it very thinly against the grain.", false, 16 },
                    { 127, 0, "Add the onion and peppers to the pot and cook over medium heat for 15 to 20 minutes until caramelized. Add the garlic, oregano, cumin, and paprika. Cook for another minute. Add the white wine and bring to a boil, scraping the bottom of the pan with the flat edge of a spatula to deglaze.", false, 18 },
                    { 14, 0, "In a small bowl, whisk together the thyme, mustard and vinegar. Gradually whisk in the oil. Season with salt and pepper", false, 2 },
                    { 13, 0, "In a bowl toss together the onion, chicken, peppadews, artichoke hearts and almonds", false, 2 },
                    { 12, 0, "Squeeze the onions to drain any juices", false, 2 },
                    { 11, 0, "Let sit for 15 minutes", false, 2 },
                    { 10, 0, "Sprinkle the onion with salt and toss to coat", false, 2 },
                    { 6, 0, "As soon as that comes to a boil, add the shrimp and another big pinch of salt. Simmer for 2 to 4 minutes flipping each shrimp halfway through, until pink and firm", false, 1 },
                    { 147, 0, "Moments before burger is done grilling, place provolone cheese slice atop of the grilled hamburger patty and allow to melt.", false, 23 },
                    { 148, 0, "Spread 1 tablespoon of pesto onto the top and bottom pieces of the toasted english muffin", false, 23 },
                    { 149, 0, "Atop the pesto on the bottom half of the english muffin, place the provolone covered hamburger patty, crispy bacon, fried egg, and pickled red onions.", false, 23 },
                    { 146, 0, "Melt the butter in a large skillet over medium heat. Plop in about two tablespoons of batter per hotcake and cook for two minutes, until the undersides are golden, adjusting the heat as necessary. Flip and cook another two minutes or so, until cooked through, and remove to a plate. Continue until you have a pile of hotcakes. Serve with maple butter and blueberries.", false, 22 },
                    { 150, 0, "Top with the other half of the toasted english muffin, and enjoy your meal!", false, 23 },
                    { 4, 0, "Melt 1 and a half tablespoons of butter in a large skillet over medium heat", false, 1 },
                    { 3, 0, "Add enough cold water to reach half a cup of liquid total", false, 1 },
                    { 2, 0, "Now juice both lemons into about 6 tablespoons", false, 1 },
                    { 1, 0, "Finely grate the zest of 1 lemon and set aside", false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 174, 0, "In a large mixing bowl, beat the egg yolks on high speed until thick and creamy. Add sugar and beat on high again until very light, about 3 to 5 minutes. Add salt and beat to combine. Set aside. In another large bowl, beat the egg whites to stiff peaks. Set aside.", false, 30 },
                    { 175, 0, "In a saucepan, heat the milk, cream, and vanilla over medium heat. Do not boil. When small bubbles begin to appear, whisk the hot milk into the yolk mixture. Add the beaten whites and the cognac and stir until everything is incorporated.", false, 30 },
                    { 176, 0, "Fill a punch bowl and let everyone serve themselves, or pour egg nog into serving cups and sprinkle a generous amount of freshly grated nutmeg on top. Drink hot.", false, 30 },
                    { 154, 0, "Place quinoa flakes, almonds and coconut into a non stick frying pan and lightly toast over a medium heat", false, 25 },
                    { 155, 0, "Leave to cool and then place into a food processor with all ingredients except the juice", false, 25 },
                    { 5, 0, "Stir in 1 tablespoon of horseradish, the lemon water, and a big pinch of salt", false, 1 },
                    { 145, 0, "In a separate bowl, whisk the egg whites for as long as your forearms will let you, through the foamy stage until they start to form peaks (you can use a mixer for this, but for me, breakfast and electronics don't mix). Gently fold the egg whites into the ricotta mixture. Add a little milk if the batter looks dry - this will depend largely on the quality and freshness of your ricotta.", false, 22 },
                    { 144, 0, "Onto the hotcakes: Whisk together the ricotta, milk, egg yolks, and sugar. Sprinkle over with the flour, baking powder, and salt, and mix until just combined. Stir in the lemon zest.", false, 22 },
                    { 143, 0, "Make the maple butter first: dump the softened butter into a bowl, add the maple syrup, and mash together thoroughly with a fork. Add the almond extract and continue mixing until everything is combined. Scrape into a small bowl and set aside or refrigerate if not using within the hour.", false, 22 },
                    { 128, 0, "Add the beef broth and crushed tomatoes. Bring to a simmer.", false, 18 },
                    { 129, 0, "Return the beef to the pot. Bring to a simmer and cover for 2 to 3 hours or until the beef is fork-tender.", false, 18 },
                    { 130, 0, "Transfer the beef to a plate and shred. Return shredded beef to sauce.Stir in the olives (optional). Simmer uncovered for 30 minutes to thicken.", false, 18 },
                    { 131, 0, "Stir in the parsley and season with salt and pepper to taste. Serve over white rice.", false, 18 },
                    { 25, 0, "add capers, parsley and olives", false, 3 },
                    { 24, 0, "when wine is nearly evaporated, reduce heat, add tomatoes and cook for 10 minutes", false, 3 },
                    { 23, 0, "meantime heat pot of hot water for pasta, generously salted", false, 3 },
                    { 22, 0, "stir carefully till wine is nearly evaporated", false, 3 },
                    { 21, 0, "once browned, add salt and pepper, then half glass of white wine and turn up heat", false, 3 },
                    { 20, 0, "add fish, stirring carefully until browned", false, 3 },
                    { 53, 0, "Gently brown the meringue with a kitchen torch", false, 5 },
                    { 19, 0, "saute three tablespoons of oil with garlic for two minutes over medium heat", false, 3 },
                    { 18, 0, "deskin fish and cut into bite sized chunks", false, 3 },
                    { 141, 0, "Place the buckwheat groats in a food processor and pulse a few times to break down. add the almond milk, maple syrup, cinnamon, vanilla bean, flax, and sea salt, and process till the mixture has a smooth consistency (but with some texture remaining).", false, 21 },
                    { 142, 0, "Pulse in the coconut and adjust seasonings. Divide porridge into four bowls and serve, topped with fresh berries, chopped nuts, or sliced bananas.", false, 21 },
                    { 17, 0, "dice garlic", false, 3 },
                    { 16, 0, "chop tomatoes roughly", false, 3 },
                    { 9, 0, "serve with crusty bread for mopping up the sauce", false, 1 },
                    { 8, 0, "Top with the lemon zest and dill, plus a sprinkle of salt", false, 1 },
                    { 7, 0, "Stir in the remaining 1 and a half tablespoons of butter and 1 tablespoon of horseradish", false, 1 },
                    { 15, 0, "Pour the dressing over the chicken and fold together. Squeeze in lemon juice", false, 2 },
                    { 126, 0, "Heat olive oil in a pot over high heat. Add the beef and brown on all sides. Then transfer to a plate.", false, 18 },
                    { 52, 0, "Remove the skewer from the chilled cake and dollop the meringue on top, piling it high", false, 5 },
                    { 42, 0, "Add chopped cilantro and a fried egg", false, 4 },
                    { 50, 0, "To make a Swiss meringue, place the egg whites and sugar in the heatproof bowl of an electric mixer. Set the bowl over a pan of gently simmering water and heat, whisking occasionally, until the sugar is dissolved and the mixture reads 160F (71C) on a thermometer", false, 5 },
                    { 123, 0, "Whisk the egg in a bowl. Brush the edges of the pastry overlap with the egg mixture and top with smaller pastry rounds. Press around the edges of the pies using the tines of a fork to create a seal. Cut a small slit into the top of each pie. Use the remaining egg to brush the tops of each pie. Place the tray in the freezer to chill for 15 mins before baking.", false, 17 },
                    { 122, 0, "Remove the chilled beef mixture from the fridge. Stir in the diced cheese. Evenly divide filling between each pie, packing them right to the top.", false, 17 },
                    { 121, 0, "Lightly grease a 12-cup muffin tin. Place larger puff pastry rounds in the base of each muffin tin, pressing along the sides so they are flush with the bottom and sides of the tin. The dough should slightly overlap the rims, stretch dough slightly if needed.", false, 17 },
                    { 120, 0, "Remove puff pastry from fridge. Roll sheets to 1/8-inch thick. Cut puff pastry into twelve 4-inch rounds and twelve 3-inch rounds. Pre-mark where you will cut each round as you will have just enough dough for all the rounds. Place onto a parchment-lined baking sheet and let chill in the fridge for 30 minutes.", false, 17 },
                    { 119, 0, "Scrape beef mixture into a bowl and let cool to room temperature. Cover and refrigerate until completely chilled, this will take at least 1-2 hours. The filling can easily be made the day before.", false, 17 },
                    { 118, 0, "Stir in salt and a few cracks of black pepper. Sprinkle flour over beef and cook, 1 minute. Pour in beef stock and Worcestershire sauce. Bring to a boil, scraping all the brown bits off the bottom of the pan. Reduce heat to medium-low and let simmer until gravy has reduced and thickened, about 6-8 minutes.", false, 17 },
                    { 117, 0, "Heat oil in a large frying pan over medium heat. Add onion, cook, stirring often until tender and starting to brown on the edges, about 2-3 minutes. Add garlic, cook 1 minute. Add ground beef to pan and cook, breaking up with a wooden spoon, until no pink remains, about 5-6 minutes.", false, 17 },
                    { 102, 0, "Preheat the oven to 325 degrees F. Generously season the short ribs with salt and pepper and heat a small (1 1/2 to 3�quart) oven-safe saucepan over medium-high heat. Add 1 tablespoon olive oil and sear the short ribs, 2 to 3 minutes per side, until browned on all over. Remove meat to a plate, leaving rendered fat in the pan.", false, 13 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 103, 0, "Add the shallot, garlic, tomato paste, red pepper flakes, herbes de Provence, and bay leaf", false, 13 },
                    { 104, 0, "Marinate the bulgogi: In a large bowl, whisk together the brown sugar, soy sauce, wine, sesame oil, green onions, garlic, and pepper until well combined. Add the beef and coat it completely in marinade. Cover and refrigerate for 4 to 5 hours.", false, 14 },
                    { 96, 0, "Add the crushed tortilla chips about an hour before serving, stirring them in so they break down and thicken the chili. Taste for salt and add a bit more if necessary, stir in the fresh lime juice off the heat, then serve with garnishes and plenty of cold beer.", false, 11 },
                    { 94, 0, "Add the chopped onion and a pinch of salt and cook until translucent. Add the garlic and marjoram or Mexican oregano and cook until fragrant. Clear a space in the bottom of the pot, add the tomato paste, and cook for a minute until it gets a little caramelized before stirring it through the onion mixture.", false, 11 },
                    { 93, 0, "Cut the short ribs into bite-sized chunks, season well with salt, and set aside. Place a small amount of oil in a deep, heavy-bottomed pot and warm until shimmering. Brown the short rib pieces in batches, removing them to a plate or platter as you finish browning.", false, 11 },
                    { 92, 0, "Toast the coriander and cumin seeds in the same dry skillet until fragrant. Transfer to a mortar and pestle, add the coarse salt, and grind. Place the softened peppers with their soaking liquid in a blender, adding the ground coriander/cumin mixture, the cinnamon, the chipotle powder, the cocoa powder, and the roasted bell pepper. Puree until smooth and set aside.", false, 11 },
                    { 91, 0, "Using kitchen shears, snip off the stems of the dried peppers and shake out most of the seeds. Toast the peppers in a dry skillet until they are fragrant and beginning to soften, then place them in a bowl and cover them with the 2 cups of boiling water. Let soak until they are very soft.", false, 11 },
                    { 90, 0, "Pick over the beans to remove any stones or debris, and place them in a large pot. Add the water, bay leaf and onion, cover the pot, and bring it to a boil. Let boil for 2 minutes, then turn off the heat and let the beans stand, undrained, for an hour. Discard the onion and bay leaf.", false, 11 },
                    { 151, 0, "Blend yoghurt, banana, maple syrup and oil or melted butter with a blender. Whisk in the egg. Also using a blender, blend the oats so you get oat flour. Mix oat flour with spelt flour, salt, cinnamon, baking powder and optionally cardamom and almond flour. Peel carrots and the apple and grate finely.", false, 24 },
                    { 152, 0, "Add the flour-mixture to the yoghurt-egg-mixture and fold in carefully. Add grated carrots and apple as well as the chopped almonds. Place the batter in 12 muffins tins. If you like you can add some chopped walnuts on top.", false, 24 },
                    { 153, 0, "Bake the muffins in the preheated oven at 175 degrees C (347 degrees F) for about 20 minutes.", false, 24 },
                    { 112, 0, "To assemble, lay the bottom bun with a healthy pile of arugula, then the warm brisket patty (which will wilt the lettuce slightly), followed by the top bun, which should be smeared generously with the prepared blue cheese mayo.", false, 15 },
                    { 95, 0, "Return the short ribs to the pot with any juices that have accumulated on the plate or platter, then add the chile puree, the beans with their cooking liquid, and the fire-roasted tomatoes. Add the stout and stir to incorporate. Cover and simmer over low heat for at least 3-4 hours, until the beans and beef are fully tender.", false, 11 },
                    { 105, 0, "To make the cucumber kimchi salad: In a medium bowl, combine the cucumbers, green onions, garlic, gochugaru, sugar, vinegar, sesame oil, and salt to taste and stir gently. Cover and refrigerate until ready to serve.", false, 14 },
                    { 106, 0, "Prepare a hot grill. If the pieces of beef are so small that they may fall through the grates, use a grilling skillet or place a sheet of foil on the grill.", false, 14 },
                    { 107, 0, "Grill the beef on both sides until medium-well, 3 to 5 minutes, flipping halfway through cooking. Don�t crowd the skillet or foil, so do this in batches if necessary. As you finish each batch, transfer it to a serving platter and continue with the remaining beef.", false, 14 },
                    { 114, 0, "Heat the vinegar, water, salt, and sugar in a saucepan. Add the onion and jalape�o and let simmer for a couple of minutes. Set aside to cool.", false, 16 },
                    { 115, 0, "Mash the beans with chipotle, cumin, lime, and salt and pepper. Taste the mixture and add salt and acid as needed. Add a spoon or two of water and heat gently before serving.", false, 16 },
                    { 116, 0, "Toast the insides of the rolls slightly, then top them with the beans, steak, pickled vegetables, avocado slices, cilantro, and a drizzle of crema.", false, 16 },
                    { 77, 0, "bring a large pot of heavily salted water to a boil and cook the pasta until just al dente. Strain it and tip it into the bowl with the sauce. Fold everything together until it is well combined, the Brie has begun to melt, and the pasta is slicked with cheese and tomato goodness. Serve immediately with a big green salad", false, 9 },
                    { 76, 0, "Once the Brie is firm enough, cut it into 1/2-inch cubes and add these to the bowl. Gently fold to combine the cheese with the rest of the ingredients. Cover the bowl and let it sit at room temperature for at least 2 to 8 hours -- the longer the better", false, 9 },
                    { 75, 0, "Roughly chop the tomatoes and put them in a large serving bowl. Finely chop the garlic and add it to the bowl. Chiffonade or roughly chop the basil and add that to the bowl too. Pour in the olive oil and add a generous amount of salt and pepper. Gently stir everything together", false, 9 },
                    { 74, 0, "Put the Brie in the freezer for about 20 minutes to firm up a little. This will make it easier to cut when the time comes", false, 9 },
                    { 78, 0, "Make the pur�e: In a small bowl and rub the granulated sugar and lemon zest together. In a medium pot toss the strawberries and lemon juice to combine. Add the sugar and salt tossing everything to combine. Cook over medium heat stirring frequently until the mixture becomes saucy and the strawberries start to break down in 8 to 10 minutes", false, 10 },
                    { 79, 0, "Use an immersion blender to pur�e the mixture in the pot. Continue to cook the mixture over medium-low heat stirring often until it reduces to 2/3 cup in 10 to 15 minutes more. Cool completely before using. This can be done up to 2 days ahead and refrigerated", false, 10 },
                    { 80, 0, "Make the cake: Heat the oven to 350 degrees F/175 degrees C. Line two 12-cup muffin tins with cupcake liners", false, 10 },
                    { 81, 0, "In the bowl of an electric mixer fitted with the paddle attachment mix the flour, sugar, baking powder, baking soda and salt to combine. Drop half tablespoon-size portions of butter into the bowl and mix on low speed until the butter is distributed and the mixture looks a bit crumbly", false, 10 },
                    { 82, 0, "In a large liquid measuring cup whisk the egg whites, milk, strawberry pur�e, vanilla, and lemon zest to combine. Add this mixture in two equal additions mixing on medium speed until the batter is smooth and combined and scraping well after each addition. If desired tint the batter deeper pink with food coloring", false, 10 },
                    { 83, 0, "Scoop the batter into the prepared pan using an ice cream scoop filling each cavity three-quarters full", false, 10 },
                    { 84, 0, "Bake the cupcakes until a toothpick inserted into the center comes out clean (or with just a few moist crumbs) in 17 to 20 minutes. Cool completely", false, 10 },
                    { 85, 0, "Make the lemon curd buttercream: Place the egg whites and cream of tartar in the bowl of an electric mixer fitted with the whisk attachment. In a medium saucepan combine the sugar and water and bring to a boil over medium heat. Stir until the mixture begins to bubble but as soon as it begins to boil, stop stirring. If necessary dip a brush in cool water to brush away granules of sugar that appear on the side of the pot", false, 10 },
                    { 86, 0, "Cook the sugar mixture until it reads 235 degrees F/115 degrees C. Begin whipping the egg whites on medium speed raising to medium-high speed once the mixture looks frothy. When the sugar mixture reaches 240 degrees F remove the pot from the heat and gradually add the hot sugar syrup to the mixer in a slow steady stream. Continue whipping until the meringue has reached full volume and the bowl is no longer warm to the touch for 5 to 6 minutes", false, 10 },
                    { 87, 0, "With the mixer running on medium speed gradually add the butter a few tablespoons at a time mixing to fully combine before adding more. This will take several minutes and the mixture will look light and fluffy. Remove the bowl from the mixer and mix in the lemon curd with a silicone spatula. I use sort of a folding motion to incorporate it, because it helps to deflate the frosting a bit and make it smoother.", false, 10 },
                    { 88, 0, "Gently fold the strawberry pur�e into the frosting, drizzling it in about a third at a time and folding it a few times but not incorporating it fully. Use an ice cream scoop to transfer swirled frosting on top of each cupcake and use a small offset spatula to swirl it", false, 10 },
                    { 89, 0, "Top with a lemon slice and a strawberry half", false, 10 },
                    { 124, 0, "While the pies are chilling preheat the oven to 425 degrees F. Bake pies for 20-25 minutes, until golden brown. Let cool 10 minutes before serving.", false, 17 },
                    { 108, 0, "Serve the bulgogi on top of steamed rice. Garnish with green onion and toasted sesame seeds and spoon the cucumber kimchi salad alongside.", false, 14 },
                    { 111, 0, "Brush the prepared patty with some oil and plop onto a hot griddle or small frying pan, cooking 3 minutes on the first side and 2 on the second. (Or until the internal temperature reaches 145F for medium-rare and 160F for medium.) Let rest about 5 minutes.", false, 15 },
                    { 51, 0, "Transfer the bowl to the mixer and whip on high speed until firm peaks form, about 5 minutes", false, 5 },
                    { 110, 0, "For the burger, gently mix together the ground beef, onion, Worcestershire, rosemary, cumin, cinnamon, salt, and pepper until just combined. Form into a single patty, about the size of your burger bun, making sure to press a shallow indentation in the center so it stays flat when you sear it.", false, 15 },
                    { 132, 0, "Make the Sauce: Add the above ingredients to a blender, and puree until nice and smooth. Add this to a small pot, and cook on medium to low heat for about 20 minutes. Stir, and remove from the heat. When you make the meatloaf, add the sauce to the top before baking, and spread on the plate before serving.", false, 19 },
                    { 137, 0, "Place the other four patties on top of the patties that have the cheese, pinch to seal the edges, and form into perfect burgers roughly 3/4-inches thick. It's very important to seal it in! Season the patties liberally with salt and a few cracks of freshly ground black pepper and each side.", false, 20 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 101, 0, "To assemble the burgers, place an equal layer of barbecue kettle chips on each bottom bun. Add a cheese-covered patty on top, followed by a layer of pickles and an equal amount of lettuce. Add the bun tops and serve with an ice-cold beer or a big ol' pitcher of tea.", false, 12 },
                    { 100, 0, "Place the patties on the grill rack and cook, turning once, until they're cooked to your preference, 5 to 7 minutes on each side for medium. In the last 3 minutes of grilling, carefully place equal amounts of the barbecue cheese on each patty. During the last 2 minutes of grilling, place the buns cut side-down, on the outer edges of the rack to toast lightly.", false, 12 },
                    { 99, 0, "Prepare the barbecue cheese: Mix the barbecue sauce, cheese, and onions and set it aside. Do not refrigerate (you will be using it shortly and you don�t want it to be really cold).", false, 12 },
                    { 98, 0, "To make the patties, combine the beef, jalape�os, salt, pepper, and chili powder in a large bowl, handling it as little as possible. Shape into 6 patties to fit the bun size. Loosely cover with plastic wrap and set aside.", false, 12 },
                    { 97, 0, "Heat your grill to medium-high. Brush the grill with oil to prevent sticking.", false, 12 },
                    { 138, 0, "Pour a little oil on a cast iron pan and set it over medium-high heat. Once the oil begins to shimmer, gently place in your burgers in the pan. Cook until a hard caramelized crust forms on the bottom of the burger (3-5 minutes), flip, and repeat. Cook for an additional 3-5 minutes, remove from the heat, and set aside to rest.", false, 20 },
                    { 139, 0, "Add your butter and onions to the pan and cook in the residual oil and beef fat until the onions soften and start to brown (approx. 3-5 minutes). Remove onions from the pan and set aside.", false, 20 },
                    { 41, 0, "Once the upma has crisped up to your desired texture, divide among bowls", false, 4 },
                    { 136, 0, "Fold the American cheese slices in half, twice, making a square, and stick into the middle of four of the patties, gently pressing down into the meat", false, 20 },
                    { 40, 0, "Cook for 2 to 3 minutes more, stirring only occasionally, so the upma browns and crisps up some more, helped along with the lactose sugar in the yogurt", false, 4 },
                    { 38, 0, "Add the peas and cook for another minute", false, 4 },
                    { 37, 0, "Add the reserved bread and cashews to the pan with the vegetables and stir everything together, ensuring the onion mixture and cauliflower florets are evenly dispersed with the bread. Cook together for about a minute more", false, 4 },
                    { 43, 0, "Do yourself a favor and make the filling the night before you plan to assemble this cake. Have a fine-mesh sieve and a large bowl on standby near the stove. Squeeze every last drop of juice from the limes and combine in a small saucepan with the yolks, condensed milk, salt and cornstarch. Whisk everything together until it's nice and smooth and then set over medium heat. Dont stop whisking", false, 5 },
                    { 44, 0, "Reduce the temperature a bit as the mixture thickens dramatically and keep whisking as it boils for 2 minutes", false, 5 },
                    { 45, 0, "Strain the mixture through the fine-mesh sieve into the bowl and stir gently with a rubber spatula to let off some of the steam", false, 5 },
                    { 46, 0, "Add the cream cheese, one or two pieces at a time, and stir until all of it has been incorporated", false, 5 },
                    { 47, 0, "Place a piece of plastic film or wax paper directly on the surface of the custard to prevent a skin from forming and refrigerate until firm, at least 4 hours, preferably overnight", false, 5 },
                    { 48, 0, "Make the lime soaker by stirring the sugar into the juice until it's dissolved. Set aside", false, 5 },
                    { 49, 0, "Use a serrated knife to trim the domes from the tops of the cakes and slice each in half horizontally to create four layers. Place one layer on a serving platter and brush the top with about 2 tablespoons of the soaker. Stir the lime filling briefly to loosen it. Then use a small offset spatula to spread about one-third of the filling over the cake, getting it right up to the edge. Scatter a third of the graham cracker crumbs over the filling and top with another layer of cake. Continue assembling in this manner with the remaining filling and cake layers. Slide a long wooden skewer vertically through the center of the cake if it feels wobbly. Chill the assembled cake until you are ready to make the meringue", false, 5 },
                    { 39, 0, "Carefully drizzle the yogurt over the upma and stir to combine so the bread and vegetables are completely coated", false, 4 },
                    { 135, 0, "Separate the burger into 8 pieces and create 1/4-inch thick patties out of each one.", false, 20 },
                    { 173, 0, "Combine coconut milk, brown sugar, and salt in a 12-inch or larger heavy skillet. Heat over medium heat until sugar dissolves, stirring occasionally. Increase heat to medium-high and cook until reduced and thickened, stirring more frequently as the mixture thickens", false, 29 },
                    { 55, 0, "Preheat oven to 450 degrees. Set a pot of boiled water on the stove to boil", false, 6 },
                    { 133, 0, "Heat your oven to 350 degrees F. In a large bowl, combine all of your ingredients, with the exception of the bbq sauce. Get in there, get dirty and greasy from the meat. Once combined, add to your bread/loaf pan which is typically 5�9. Shape into the pan, then add your sauce to the top, roughly a half cup. Place in the oven for nearly one hour and 25 minutes.", false, 19 },
                    { 134, 0, "Once cooked, remove from the oven and let it cool for roughly five minutes. In the meantime, warm up more of the bbq sauce. Remove the loaf to a serving dish, and drizzle the sauce on the top. Serve with your favorite sides. I served mine with mashed potatoes. Trust me, this one is really delicious.", false, 19 },
                    { 160, 0, "Preheat your oven to 350 degrees F, and grease two 9-inch loaf pans. In a large frying pan, heat the butter over medium high heat. It will melt first, and then start to foam. Turn the heat down to medium. Stir the melted butter almost constantly, scraping any browning bits from the bottom of the pan. When the butter has turned a brown color and smells rich and nutty, remove it from the heat. (This should take about 7 minutes). Allow it to cool for about 10 minutes.", false, 27 },
                    { 161, 0, "In the bowl of a standing mixer, beat together the eggs and sugars on high speed for several minutes, until the color has lightened. Scrape in the browned butter and beat for another couple of minutes, until the mixture is smooth.", false, 27 },
                    { 162, 0, "Add the pur�ed squash to the wet ingredients and beat until smooth and uniformly mixed in.", false, 27 },
                    { 163, 0, "In a small bowl, combine the flour, salt, baking powder, baking soda, and nutmeg. Add this to the wet ingredients, and mix on low until fully incorporated.", false, 27 },
                    { 164, 0, "Divide the batter evenly into the 2 prepared loaf pans and bake for about 50 minutes, until a tester comes out clean. Take the bread out of the loaf pans and allow to cool completely before glazing.", false, 27 },
                    { 165, 0, "Brown the butter in a pan, just as described in step 2 for the bread and allow to cool for about 10 minutes. Scrape the butter into a mixing bowl.", false, 27 },
                    { 166, 0, "Sift the confectioner's sugar to remove lumps. Then whisk the vanilla into the butter. Next, whisk in confectioner's sugar until your reach a spreadable consistency.", false, 27 },
                    { 167, 0, "Spread the icing onto the loaves, and allow to set for about 30 minutes before slicing.", false, 27 },
                    { 156, 0, "Place the dough into a lined dish or silicone mold and flatten with down with the back of a fork", false, 25 },
                    { 168, 0, "Put half the nuts and half the chocolate chips onto a cookie sheet.", false, 28 },
                    { 169, 0, "Using a candy thermometer to monitor, cook butter and brown sugar over medium-high heat in medium-sized pot until you reach \"hard crack\" stage -- 300� F. Stir constantly. This will take about 15 minutes.", false, 28 },
                    { 170, 0, "Remove the pot from heat and quickly add salt and vanilla.", false, 28 },
                    { 171, 0, "Carefully pour the caramel mixture over the mix of nuts and chocolate. Sprinkle remaining chocolate over hot mixture. When melted, smooth out with the back of large spoon. Sprinkle remaining nuts and gently press into the toffee. If you like salted caramels, you may want to sprinkle some good-quality sea salt on top of the candy.", false, 28 },
                    { 172, 0, "Freeze one hour before breaking into pieces for storage -- or snacking.", false, 28 },
                    { 60, 0, "Add the roast vegetables, along with remaining 1 tbsp olive oil and a tiny bit of the cooking liquid, to the pasta. Toss in the basil and oregano. Top with toasted pine nuts if desired", false, 6 },
                    { 59, 0, "Cook pasta till tender but slightly al dente. Drain and return to pot, reserving a small amount of the cooking liquid", false, 6 },
                    { 58, 0, "If you're using the pine nuts, now is the time to toast them gently in a large frying pan set over medium heat. Stir them continually and remove them as soon as they�re becoming golden", false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 57, 0, "Divide all vegetables save corn onto baking sheets and start roasting them for 35 to 40 minutes. Fifteen minutes before the end of the roasting process, add the corn which cooks a little faster than the other vegetables", false, 6 },
                    { 56, 0, "Toss vegetables and garlic with olive oil and season well with salt and pepper, but keep the corn separate", false, 6 },
                    { 109, 0, "For the mayo, mix all of the ingredients together and set aside. If not using right away, keep in an airtight container in the fridge.", false, 15 },
                    { 157, 0, "Cover with clingfilm and place into the freezer for two hours before transferring to the fridge", false, 25 }
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
                name: "IX_Steps_RecipeId",
                table: "Steps",
                column: "RecipeId");

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
                name: "Steps");

            migrationBuilder.DropTable(
                name: "UserCompletedRecipes");

            migrationBuilder.DropTable(
                name: "UserFavouriteRecipes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
