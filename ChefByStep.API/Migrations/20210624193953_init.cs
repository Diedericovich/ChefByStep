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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrepTimeInMin = table.Column<int>(type: "int", nullable: false),
                    CookTimeInMin = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "lemon" },
                    { 196, "orange juice" },
                    { 195, "ginger" },
                    { 194, "dried figs" },
                    { 193, "chia seeds" },
                    { 192, "pumpkin seeds" },
                    { 191, "dried cranberries" },
                    { 197, "goldenberries" },
                    { 190, "dried apple rings" },
                    { 188, "quinoa flakes" },
                    { 187, "walnuts" },
                    { 186, "almonds" },
                    { 185, "spelt flour" },
                    { 184, "rolled oats" },
                    { 183, "apple" },
                    { 189, "coconut flakes" },
                    { 182, "yoghurt" },
                    { 198, "goji berries" },
                    { 200, "cacao nibs" },
                    { 214, "chicken thighs" },
                    { 213, "cognac" },
                    { 212, "whipping cream" },
                    { 211, "whole milk" },
                    { 210, "eggs" },
                    { 209, "dark rum" },
                    { 199, "dried mulberries" },
                    { 208, "chocolate" },
                    { 206, "chocolate chips" },
                    { 205, "confectioners sugar" },
                    { 204, "salted butter" },
                    { 203, "nutmeg" },
                    { 202, "baking soda" },
                    { 201, "butternut squash" },
                    { 207, "coconut milk" },
                    { 215, "hungarian hot paprika" },
                    { 181, "banana" },
                    { 179, "provolone cheese" },
                    { 160, "cayenne pepper" },
                    { 159, "ground ginger" },
                    { 158, "light brown sugar" },
                    { 157, "blackberries" },
                    { 156, "onions" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 155, "white bread" },
                    { 161, "american cheese" },
                    { 154, "milk" },
                    { 152, "ground veal" },
                    { 151, "ground pork" },
                    { 150, "pimiento" },
                    { 149, "crushed tomatoes" },
                    { 148, "beef broth" },
                    { 147, "ground cumin" },
                    { 153, "dried basil" },
                    { 180, "bacon" },
                    { 162, "vegetable oil" },
                    { 164, "butter" },
                    { 178, "pesto" },
                    { 177, "english muffin" },
                    { 176, "hamburger patty" },
                    { 175, "almond extract" },
                    { 174, "blueberries" },
                    { 173, "lemon zest" },
                    { 163, "pickle" },
                    { 172, "baking powder" },
                    { 170, "coconut" },
                    { 169, "ground flax meal" },
                    { 168, "vanilla extract" },
                    { 167, "maple syrup" },
                    { 166, "almond milk" },
                    { 165, "raw buckwheat groats" },
                    { 171, "ricotta" },
                    { 146, "red bell pepper" },
                    { 216, "tomato puree" },
                    { 218, "butter lettuce" },
                    { 268, "thyme" },
                    { 267, "fresh mint" },
                    { 266, "watercress" },
                    { 265, "celery" },
                    { 264, "crisp apple tarts" },
                    { 263, "fennel" },
                    { 269, "fennel fronds" },
                    { 262, "balsamic vinegar" },
                    { 260, "ground pepper" },
                    { 259, "kalamata olives" },
                    { 258, "mozzarella cheese" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 257, "farro" },
                    { 256, "garlic oil" },
                    { 255, "grape tomatoes" },
                    { 261, "virgin olive oil" },
                    { 254, "sesame seeds" },
                    { 270, "mustard greens" },
                    { 272, "sumac" },
                    { 286, "cardamom" },
                    { 285, "almond meal" },
                    { 284, "polenta" },
                    { 283, "ketchup" },
                    { 282, "half-and-half" },
                    { 281, "cotija cheese" },
                    { 271, "mustard" },
                    { 280, "sriracha" },
                    { 278, "feta cheese" },
                    { 277, "scallions" },
                    { 276, "lemons" },
                    { 275, "za'atar" },
                    { 274, "bulgur wheat" },
                    { 273, "aleppo pepper" },
                    { 279, "corn" },
                    { 217, "green herbs" },
                    { 253, "tahini" },
                    { 251, "soba" },
                    { 232, "curry powder" },
                    { 231, "fontina" },
                    { 230, "spinach" },
                    { 229, "golden raisins" },
                    { 228, "large eggs" },
                    { 227, "all-purpose flour" },
                    { 233, "parmigiano" },
                    { 226, "parmesan cheese" },
                    { 224, "basil" },
                    { 223, "anchovy paste" },
                    { 222, "chicken breast" },
                    { 221, "broccoli" },
                    { 220, "cabbage" },
                    { 219, "radishes" },
                    { 225, "bread" },
                    { 252, "soybeans" },
                    { 234, "dark chocolate" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 236, "kahlua" },
                    { 250, "vanilla" },
                    { 249, "olive oil spray" },
                    { 248, "red grapes" },
                    { 247, "lemon juice" },
                    { 246, "sweet cherries" },
                    { 245, "honey" },
                    { 235, "milk chocolate" },
                    { 244, "ground nutmeg" },
                    { 242, "condensed milk" },
                    { 241, "raisins" },
                    { 240, "rum" },
                    { 239, "greek yogurt" },
                    { 238, "sour cherries" },
                    { 237, "chocolate caramel sauce" },
                    { 243, "cardamom seeds" },
                    { 144, "beef chuck roast" },
                    { 145, "green bell pepper" },
                    { 71, "basil leaves" },
                    { 52, "coarse salt" },
                    { 51, "fresh oregano leaves" },
                    { 50, "torn basil leaves" },
                    { 49, "penne pasta" },
                    { 48, "red onion" },
                    { 47, "large sliced summer squash" },
                    { 53, "pine nuts" },
                    { 46, "ear corn" },
                    { 44, "fried egg" },
                    { 43, "cilantro" },
                    { 42, "plain full-fat yogurt" },
                    { 41, "frozen peas" },
                    { 40, "small cauliflower florets" },
                    { 39, "ground turmeric" },
                    { 45, "cherry tomatoe" },
                    { 38, "curry leaves" },
                    { 54, "egg white" },
                    { 56, "almond flour" },
                    { 70, "tomatoe" },
                    { 69, "brie" },
                    { 68, "dill sprig" },
                    { 67, "egg" },
                    { 66, "dash sugar" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 65, "orzo" },
                    { 55, "granulated sugar" },
                    { 64, "white pepper" },
                    { 62, "heavy cream" },
                    { 61, "mexican chocolate" },
                    { 60, "cream of tartar" },
                    { 59, "cocoa powder" },
                    { 58, "cinnamon" },
                    { 57, "confectioners' sugar" },
                    { 63, "chicken stock" },
                    { 143, "cheddar cheese" },
                    { 37, "chopped green chile" },
                    { 35, "asafetida" },
                    { 16, "whole-grain mustard" },
                    { 15, "chopped thyme" },
                    { 14, "chopped smoked almonds" },
                    { 13, "marinated artichoke hearts" },
                    { 12, "peppadews peppers" },
                    { 11, "roasted chicken" },
                    { 17, "sherry vinegar" },
                    { 10, "salt" },
                    { 8, "hot pasta" },
                    { 7, "crusty bread" },
                    { 6, "chopped dill" },
                    { 5, "shrimp" },
                    { 4, "kosher salt" },
                    { 3, "prepared horseradish" },
                    { 9, "sliced red onion" },
                    { 36, "shallot" },
                    { 18, "extra virgin olive oil" },
                    { 20, "olive oil" },
                    { 34, "urad dal" },
                    { 33, "black mustard seeds" },
                    { 32, "raw cashews" },
                    { 31, "sourdough bread" },
                    { 30, "neutral oil" },
                    { 29, "salt and pepper" },
                    { 19, "black pepper" },
                    { 28, "chopped parsley" },
                    { 26, "chopped tomatoe" },
                    { 25, "white wine" },
                    { 24, "salted capers" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 23, "white fish" },
                    { 22, "olive" },
                    { 21, "garlic" },
                    { 27, "spaghetti" },
                    { 2, "unsalted butter" },
                    { 72, "dash sea salt" },
                    { 74, "curly pasta" },
                    { 124, "ground beef brisket" },
                    { 123, "garlic powder" },
                    { 122, "rosemary" },
                    { 121, "blue cheese" },
                    { 120, "red wine vinegar" },
                    { 119, "mayonnaise" },
                    { 125, "cumin" },
                    { 118, "rice vinegar" },
                    { 116, "gochugaru" },
                    { 115, "cucumber" },
                    { 114, "beef tenderloin" },
                    { 113, "green onions" },
                    { 112, "sesame oil" },
                    { 111, "sparkling dessert wine" },
                    { 117, "sugar" },
                    { 110, "soy sauce" },
                    { 126, "oil" },
                    { 128, "arugula" },
                    { 142, "butter puff-pastry" },
                    { 141, "beef stock" },
                    { 140, "flour" },
                    { 139, "sour cream" },
                    { 138, "avocado" },
                    { 137, "soft sandwich rolls" },
                    { 127, "brioche bun" },
                    { 136, "lime juice" },
                    { 134, "chile powder" },
                    { 133, "black beans" },
                    { 132, "sirloin flap steak" },
                    { 131, "pepper" },
                    { 130, "paprika" },
                    { 129, "onion powder" },
                    { 135, "cumin powder" },
                    { 73, "dash pepper" },
                    { 109, "brown sugar" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 107, "panko bread crumbs" },
                    { 88, "tortilla chips" },
                    { 87, "chocolate stout" },
                    { 86, "fire roasted tomato" },
                    { 85, "tomato paste" },
                    { 84, "oregano" },
                    { 83, "yellow onion" },
                    { 89, "lime" },
                    { 82, "beef short ribs" },
                    { 80, "coriander seed" },
                    { 79, "chile" },
                    { 78, "onion" },
                    { 77, "bay leaf" },
                    { 76, "water" },
                    { 75, "red beans" },
                    { 81, "sea salt" },
                    { 108, "parsley" },
                    { 90, "ground beef" },
                    { 92, "chili powder" },
                    { 106, "mashed potatoes" },
                    { 105, "carrots" },
                    { 104, "cremini mushrooms" },
                    { 103, "worcestershire sauce" },
                    { 102, "red wine" },
                    { 101, "herbes de provence" },
                    { 91, "jalapeño" },
                    { 100, "red pepper flakes" },
                    { 98, "dill pickles" },
                    { 97, "potato chips" },
                    { 96, "hamburger buns" },
                    { 95, "sweet onion" },
                    { 94, "cheddar" },
                    { 93, "barbecue sauce" },
                    { 99, "iceberg lettuce" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "Name", "RoleId" },
                values: new object[,]
                {
                    { 2, 0, "Alberto", 0 },
                    { 3, 0, "Octaaf", 0 },
                    { 1, 0, "Frieda", 0 },
                    { 4, 0, "Gert", 0 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookTimeInMin", "CreatedById", "Description", "ImageUrl", "PrepTimeInMin", "Title" },
                values: new object[,]
                {
                    { 11, 3, 130, 1, "My take on boeuf bourguignon skips a couple ingredients—namely the bacon, whose fat traditionally adds luscious flavor to the classic French stew, and the flour, which would otherwise serve as a thickener for the sauce. I find that boneless beef short ribs, which are marbled with fat and collagen, do all the heavy lifting in this recipe and help you arrive at a final stew that’s just as glossy, satisfying, and full of deep, savory flavor as the original.", "https://images.food52.com/T4h0NggW-s84P3TvGLm2e556Xuk=/1008x672/filters:format(webp)/8ed76823-4e2e-45e0-b8be-a459eb1a915c--2020-0303_boeuf-bourguignon-for-one_3x2_ty-mecham.jpg", 5, "Beef Short Rib Bourguignon With Garlicky Panko Gremolata" },
                    { 8, 3, 15, 3, "Alot of people make a summer pasta alla Caprese like this: the pasta–raw garlic or onion, tomatoes, basil, olive oil and fresh mozzarella. This recipe replaces the mozarella with brie. A bold but satisfying choice! A fine Brie is just as delicious at room temperature smeared on crusty bread as it is warm, oozing out of flaky pastry. And it's REALLY good folded into a fresh tomatoey, garlicky sauce for pasta. Put aside any residual anti-Brie sentiments and give this one a shot before tomatoes disappear for the year. You won't regret it", "https://images.food52.com/i8P83CvSSFTTVWinAuWJuXqAHFo=/1008x672/filters:format(webp)/547d4b4b-dfa0-494a-9415-04a97a103f05--20120804_food52_08-20-12-1466.jpg", 480, "Pasta with Tomatoes, Garlic, Basil & Brie" },
                    { 10, 2, 15, 3, "A way to combine some tailgate favorites: burgers, barbecue, and chips. You will need either a cold beer or a Texas tea to wash this bad boy down!", "https://images.food52.com/GbbciGi20Daa9DrE_TDPc63Ty2g=/1008x672/filters:format(webp)/133eb19c-b40f-46cb-a8c5-0251afd60969--2014-0715_jalapeno-cheddar-burger-004.jpg", 15, "Texas Tailgate Burger" },
                    { 15, 4, 45, 3, "These mince and cheese pies feature ground beef encased in a thick, dark, beefy gravy interspersed with pockets of melted white cheddar cheese.", "https://images.food52.com/EYhpqWDzO1OpxcmCUmsQF8FjQDg=/1008x672/filters:format(webp)/936c251b-b56b-4e31-8407-71ea86c72f3e--2018-0308_new-zealand-gas-station-beef-cheese-pies_3x2_james-ransom-0122.jpg", 180, "New Zealand-Style Beef & Cheddar Pies" },
                    { 16, 3, 180, 3, "A traditional beef stew from Cuba made with shredded beef that is often served with black beans and rice.", "https://images.food52.com/w-E3753Js_MvtbsBVHEQU_pOAso=/1008x672/filters:format(webp)/9c0278c5-ed16-4912-b8f5-1a3ccd3e5f09--2019-0618_ropa-vieja_3x2_bobbi-lin_4189.jpg", 10, "Ropa Vieja" },
                    { 18, 2, 15, 3, "For the uninitiated, a Juicy Lucy is a burger where the cheese is set inside the beef instead of on top. The result of hot beef fat dripping onto a highly meltable cheese results in a molten concoction that brings immense amounts of joy.", "https://images.food52.com/KSs_q5YjQ-eGX1oG4bpHldx127I=/1008x672/filters:format(webp)/4b97e80b-0b9a-4522-8876-4a83015b2091--2018-0123_juicy-lucy-2-ways_3x2_james-ransom_0231.jpg", 15, "Minnesota Juicy Lucy" },
                    { 19, 1, 15, 3, "This recipe has all of the satisfaction and comfort of hot cereal, sans heat, which makes it perfect for summer. Feel free to get creative with toppings and mix-ins!", "https://images.food52.com/96QJqyGLA0LoV4PoKQRX8FtD_Mk=/1008x672/filters:format(webp)/7e8c0fab-197f-419e-9687-d0b826c4e2ba--recipe1.jpg", 15, "Raw Buckwheat Breakfast Porridge" },
                    { 27, 4, 30, 3, "This fondue is silken and almost custardy, punctuated with rum and vanilla and generously salted, the way we like caramel to be. Not surprisingly, it is quite rich and sweet, and we found our favorite dipping instrument ended up being salty, extra-dark pretzels.", "https://images.food52.com/jIsJ6SEO8_LtNjMw9Z5y9280PGM=/1008x672/filters:format(webp)/d687384c-0945-4379-925a-2955606b8b3c--022211F_206.JPG", 15, "Coconut Cajeta & Chocolate Fondue" },
                    { 30, 3, 15, 3, "This recipe is a great way to use up old bread. The lemon and olive oil soaks into the dry bread to make it soft and delicious again. And paired with the chicken breast, you have a balanced meal that covers all four food groups.", "https://images.food52.com/yR3Erett-FXFT91HMKv-M8P1i3k=/1008x672/filters:format(webp)/1ed94431-2e36-457c-a2ac-f0f35d904826--2018-1019_anita-lo-pan-roasted-chicken-breast-with-broccoli-panzanella-3x2_ty-mecham_001.jpeg", 10, "Pan-Roasted Chicken Breast With Broccoli Panzanella" },
                    { 32, 4, 30, 3, "Make a caramel, then a ganache, then let the two of them be one.", "https://images.food52.com/gTRFvEB7ybA665Do2_v2yMkAkdg=/1008x672/filters:format(webp)/f2b6f9b2-b4f3-4052-985f-8905eae5a6f1--2013-1104_finalist_whipped-chocolate-caramel-ganache-409.jpg", 30, "Whipped Chocolate Caramel Ganache" },
                    { 36, 4, 30, 3, "An easy olive oil cake enriched with almond meal and topped with grape halves.", "https://images.food52.com/toHR4VyPmlr4VjteDVkdkJVNgSY=/1008x672/filters:format(webp)/55c3aae0-4027-4362-89dd-afda9b6ba9aa--GrapeCake3.jpeg", 5, "Grape, Almond, and Olive Oil Cake" },
                    { 37, 4, 20, 3, "An easy hot chocolate recipe to have up your sleeve all winter long.", "https://images.food52.com/64Y9tg-NfafQY_AW1A29PHBc-B8=/1008x672/filters:format(webp)/2d344647-0180-4afd-a43e-0381b4c535ce--wildcard_cardamom-hot-chocolate_food52_mark_weinberg_13-12-10_0026.jpg", 5, "Cardamom Hot Chocolate" },
                    { 39, 2, 10, 3, "uicy tomatoes, creamy mozzarella and briny kalamatas break up any potential monotony, and diced red onion, basil and parsley keep the dish from feeling heavy.", "https://images.food52.com/E_QTqOWj9th4uD7ZtrNzDwlePN4=/1008x672/filters:format(webp)/fa4a2c19-ec5b-4b2b-a29d-3feb3850325c--2018-0712_summer-farro-salad_3x2_rocky-luten_021.jpg", 15, "Summer Farro Salad" },
                    { 43, 2, 15, 3, "Simple and flavorful, this is a perfect last-minute side for a weeknight dinner or big-batch potluck addition. The recipe below only calls for 3 ears of corn, but the proportions are easy to triple or quadruple when it’s party time.", "https://images.food52.com/h0QdlPCPvkWsqH3HPL-V-avlvIk=/1008x672/filters:format(webp)/6b307a76-dbac-460a-9492-1f72aae43aea--2015-0804_sriricha-lime-thai-corn-salad_bobbi-lin_5833.jpg", 5, "Sriracha-Lime Corn Salad" },
                    { 45, 1, 15, 3, "Blend almond meal with the polenta and cook the two together, later adding vanilla, fresh blueberries and cardamom. A bit of honey lends just the right amount of sweetness.", "https://images.food52.com/rbH2yEx459u_zjH-B-NBVR0vmgQ=/1008x672/filters:format(webp)/a1bcf80d-fe57-487b-a220-0a4cb1a551e7--2014-0805_blueberry-almond-breakfast-polenta-019.jpg", 5, "Blueberry Almond Breakfast Polenta" },
                    { 7, 2, 30, 4, "The name of this classic Greek soup emulsion of lemon and eggs comes from its two main ingredients: egg (avgo) and lemon juice (lemono). The key to this soup is tempering the egg and lemon mixture by slowly adding hot stock and then whisking constantly to prevent the eggs from curdling. You then stir the mixture into the soup, which becomes all velvety lush lemony goodness. A Greek salad and warm pita bread are wonderful accompaniments to this soup", "https://images.food52.com/Y4T3Uk-cKn799bjhWySmQJ9YxIA=/1008x672/filters:format(webp)/2311e33a-47e9-4504-99e4-dd3d61337348--2017-1212_egglands-best-sponsored_greek-soup-holiday_3x2_mark-weinberg_0128.jpg", 15, "Greek Lemon Soup - Avgolemono" },
                    { 13, 2, 5, 4, "This stovetop blue cheese burger recipe makes a single portion. But because it's exactly for one, the math to double or quadruple or octuple the patty is fairly simple. Scale up as many times as you want—no matter what you do, make a lot of the blue cheese mayo. You won't be sorry.", "https://images.food52.com/choh0ovckbNRzRvpo6Y7hXBOjqU=/1008x672/filters:format(webp)/f55f7e17-489f-43ac-9097-a9da39d9701b--2019-0618_blue-cheese-burger-for-one_3x2_bobbi-lin_4166.jpg", 15, "Blue Cheese Burger" },
                    { 20, 1, 10, 4, "Three-bite pancakes topped with blueberries and a creamy maple butter that melts ever so slightly atop the warm pancakes.", "https://images.food52.com/sVihu6JyjCqAfzYCAgi63iumezY=/1008x672/filters:format(webp)/6948eb72-b218-4f07-878d-83a1bd25e1fe--food52_04-17-12-8757.jpeg", 5, "Ricotta Hotcakes with Maple Butter" },
                    { 22, 1, 35, 4, "This muffin recipe is loaded with fruit, veggies and nuts so it gives you everything you need for a little morning or afternoon pick up!", "https://images.food52.com/69T0RTYvZH4VEMs_hhnxNyvOCwE=/1008x672/filters:format(webp)/717fccd2-48db-4812-830f-3eeaa4435e00--IMG_8013.JPG", 10, "Breakfast carrot cake muffins" },
                    { 34, 4, 40, 4, "Fold melted butter into warmed carrots, whole and condensed milk, sugar, and raisins. Combine with flour and baking powder and bake the mixture in a sheet tray, with slivered almonds on top.", "https://images.food52.com/TryQTUPJzvZfd5tBED9Cy7mnvjc=/1008x672/filters:format(webp)/2ab2b843-26f9-415f-9a5c-3e9bafa03220--2015-0824_carrot-halwa-blondie-bars_bobbi-lin_8387.jpg", 10, "Carrot-Halwa Blondie Bars" },
                    { 5, 3, 20, 3, "Think of this recipe as summer in a bowl. The sweet corn, bursting cherry tomatoes, and tender zucchini lighten up a savory, satisfying bowl of pasta. Proof that meatless dishes can be quick, easy, and a joy to eat", "https://images.food52.com/9-Z62AhfnO7vECg7gARyZVGIW9A=/1008x672/filters:format(webp)/fc3db569-3b62-4126-a92c-9598b7fdb120--food52_07-24-12-7723.jpg", 10, "Penne with Sweet Summer Vegetables, Pine Nuts and Herbs" },
                    { 38, 3, 60, 4, "Vegan noodles with broth made from soybeans with nice and crispy sesame seeds on top.", "https://images.food52.com/OYHTJ9_nSsGJoUooGZ79cNYufqY=/1008x672/filters:format(webp)/3d16bed3-ccc7-4440-9764-9c923e8ad842--2018-0612_mokbar-soybean-ramen_3x2_bobbi-lin_12622.jpg", 20, "Chilled Soybean Noodles" },
                    { 42, 2, 15, 2, "Run-of-the-mill tabouli has a way of getting water-logged too easily. By replacing the normal tomato and cucumber with sturdy nuts and crunchy celery, drbabs has effectively solved that problem. Pack the smart garnishes (yogurt, feta, and extra spice), and take this on your longest trip -- we dare you.", "https://images.food52.com/y8Gl0Gvz2dCtiPsXtbWF7aJP0L0=/1008x672/filters:format(webp)/29950cdc-6aa6-42d2-9b5d-1210624f1e15--2013-0813_finalist_tabouli-007.jpg", 60, "Celery and Za’atar Tabouli" },
                    { 33, 4, 120, 2, "The Greek yogurt you know and love, mixed with sour cherries, and churned into a frozen treat.", "https://images.food52.com/YP0xDUisNoYFP53fL5yOK58s2rc=/1008x672/filters:format(webp)/f59d217a-eb2d-4b02-b448-380dbafa7969--2014-0624_WC_sour-cherry-almond-frozen-yogurt-010.jpg", 15, "Sour Cherry Almond Frozen Yogurt" },
                    { 14, 2, 30, 1, " A go-to, weeknight torta with steak, beans, jalapeños, and avocado. That comes together in under an hour.", "https://images.food52.com/qgtCvxOACjNWH-Q8rPfNOzMQZYE=/1008x672/filters:format(webp)/f0e586ed-75e1-4d0b-a902-b2523e570638--2014-0923_steak-and-bean-torta-018.jpg", 30, "Steak and Bean Torta" },
                    { 21, 1, 15, 1, "Who said burgers were for dinner? When piled high with bacon and a delicate fried egg and then smashed between a toasted english muffin, they are just begging to be eaten for breakfast.", "https://images.food52.com/vi8yjvxGPI4PY1tXj1YPwpZ9k-Q=/1008x672/filters:format(webp)/cca18c11-98fa-4c59-8214-bf08030b3be5--Jun_17_2014_2674_edited-1.jpg", 10, "Pesto Bacon Breakfast Burger" },
                    { 24, 1, 15, 1, "Whisk up your chia, toss on some superfood berries, like goji berries, goldenberries, and mulberries, a few cashews, and bam. Rockin' raw vegan power breakfast.", "https://images.food52.com/9R1JMNstuZlJ6-7HTlJEsnD2dLs=/1008x672/filters:format(webp)/0cb64378-a8e1-4ce2-a61a-15160e607ef2--Superfood_Berry_Chia_Breakfast.jpg", 5, "Superfood Berry Chia Breakfast" },
                    { 25, 4, 50, 1, "Somewhere pleasantly between pumpkin and butterscotch, a very original take on a seasonal loaf cake. Your whole house will smell like rich, nutty brown butter since it's in both the cake and the icing.", "https://images.food52.com/73wSsJKEia05pf9F0ZZqTQLBk5c=/1008x672/filters:format(webp)/31eb95c5-4299-4321-a66d-877ae5625628--2016-0204_brown-butter-and-butternut-loaf_james-ransom-012.jpg", 30, "Brown Butter and Butternut Loaf" },
                    { 26, 4, 35, 1, "Sandwich buttery caramel between layers of melted semisweet chocolate and finely chopped almonds.", "https://images.food52.com/1cN4KGunMq_qzcugQa6d3RXPZPA=/1008x672/filters:format(webp)/3a109bf4-c892-44c9-ab26-ec940081fa9a--2014-1124_chocolate-almond-toffee-010.jpg", 10, "Scottish Toffee" },
                    { 40, 2, 30, 1, "This is an Indian summer soup, a soup for the liminal season. Tart, crisp apples like Honeycrisp, Gravenstein, or Granny Smith are paramount. Equally good hot or cold, it's a smooth mélange of tart, crisp apples, celery stalks, leaves and all.", "https://images.food52.com/xjCz2BTVzieHggwHPv1js4ghTr0=/1008x672/filters:format(webp)/9938f2c9-9992-4447-b6f2-4e136bd2a917--Y75A0076.jpg", 20, "Apple and Fennel Soup" },
                    { 44, 1, 5, 1, "Savory, crispy French toast. Salty, with a heavy kick of black pepper.", "https://images.food52.com/Y9cnQzj0xxn8hMYwJWKXcwO2u0I=/1008x672/filters:format(webp)/9343c2d7-2f68-45db-b008-c34097861d23--2017-0118_crispy-salt-and-pepper-french-toast_mark-weinberg_227.jpg", 5, "Crispy Salt and Pepper French Toast" },
                    { 1, 3, 5, 2, "A simple scampi-inspired dinner that needs neither a lot of time nor a lot of ingredients. The key is to swiftly simmer the shrimp and to rely on extrovert ingredients for seasoning. Lemon juice and lemon zest deliver loads of sunny acidity. So much so that we are also using water, not stock, to stretch the brightness, and to ensure that there is enough sauce for bread-sopping", "https://images.food52.com/_51_B8XLkaL7wou2THrl1WXuadA=/1008x672/filters:format(webp)/3871c07e-9765-4a8d-9fdd-2f996094b105--2021-0518_speedy-shrimp_3x2_james-ransom-031.jpg", 5, "Speedy Shrimp With Horseradish Butter" },
                    { 2, 2, 5, 2, "If you like a good mayonnaise-based chicken salad, but one with more candid flavors, you should try this recipe! With a glass of white wine it feels like the perfect weekend lunch", "https://images.food52.com/OOqBZEjQhcOLodgRlnXoOfVI5RY=/1008x672/filters:format(webp)/d8634211-6145-4329-81ca-711c45e4750a--2017-0427_chicken-salad_james-ransom-297.jpg", 20, "Chicken Salad" },
                    { 3, 3, 25, 2, "Fish Pasta can be made with any flakey white fish. Snapper good but its best with fresh striped bass. Be very careful stirring the sauce: the fish should remain intact. The tomatoes should be fresh and cooked al crudo, till the juices are released but they are still a little raw. By adding the fish early on, its flavor infuses the whole sauce, so the tomatoes and fish are no longer separate entities, but fully integrated into the sauce. And the capers and olives reinforce the flavor of the fish with brine", "https://images.food52.com/GvZ5Q60UMuuk_k7qcMztS1vWziw=/1008x672/filters:format(webp)/1e35cfe9-2665-4d8a-8aae-340d3ecb46e3--pasta-social-club-brothy-tomato-pasta.jpeg", 10, "Fish Pasta" },
                    { 4, 1, 20, 2, "People know upma as a South Indian breakfast staple, but its more. Upma is a state of mind. The refrain is simple: Carb of choice, toasted in ghee-bloomed spices, then cooked with assorted vegetables and curry leaves and topped with tomato ketchup. In South India the carb of choice is typically toasted semolina, thickened into a creamy, savory porridge. But it can also be made with bread. Bread upma can be made in two contrasting ways. This version captures the best of both", "https://images.food52.com/38ws8x4bhNB0a9zHq6ZSduhKXCY=/1008x672/filters:format(webp)/eb712a59-16c6-4f57-a6cf-8e523aa97e4e--2021-0312_bread-upma_3x2_mark-weinberg-193.jpg", 10, "My Favorite Bread Upma" },
                    { 6, 4, 15, 2, "In the Mexican city of Oaxaca, almonds are ground into a rough paste with cacao, cinnamon, and sugar and hardened into thin fingers of chocolate. The distinctive mixture is used in the city's famous mole sauces and melted into rich hot chocolate which the Oaxacans drink more regularly than coffee. The warm, spicy smell of toasted cacao, cinnamon and almonds fills the city, as crowded storefront grinders are endlessly turning and the mercado stalls are crowded with vendors selling secret family recipes. Ideal for inspiration and make macarons with the same flavors", "https://images.food52.com/fLevsOXvNogpjdYZFItNUwPVf-4=/1008x672/filters:format(webp)/3e4baffa-29dc-4e2e-aa6a-2f42f1f4414a--033010F_869.JPG", 1560, "Oaxacan Cinnamon Chocolate Macarons" },
                    { 9, 3, 265, 2, "We love a good pot of chili, and our kitchen has turned out dozens of variations over the years. Boneless grass-fed beef short ribs, trimmed and cut into chunks, with a puree of chiles and spices, added fire-roasted tomatoes and some rich dark beer.", "https://images.food52.com/VZkTIa68tHfebPSUso6QEyFV5X0=/1008x672/filters:format(webp)/2535541d-3f88-433e-b52e-43d8ea83350e--food52_02-07-12-8044.jpeg", 130, "Short Rib Chili" },
                    { 12, 3, 10, 2, "An American-Korean hybrid, much sweeter than traditional bulgogi, served on a bed of white rice.", "https://images.food52.com/8uquQ9jEsWl-YGubwhZZbfEXSBo=/1008x672/filters:format(webp)/59d62ed1-e083-404e-ad5a-34876e435dac--2018-0503_moms-bulgogi-cucumber-kimchi-salad_3x2_rocky-luten_049.jpg", 160, "Bulgogi with Cucumber Kimchi Salad" },
                    { 17, 2, 105, 2, "For the best traditional meatloaf recipe relying on the classic triumvirate of ground veal, beef and pork. A little bread and milk. Garlic, onion and Worcestershire sauce. All are thoughtfully balanced, producing a savory, light-textured loaf.", "https://images.food52.com/SEoIY3KjCVcA_NwGD52FNaXydYM=/1008x672/filters:format(webp)/29e35312-3021-4491-9662-2d6d6f41b35e--2019-0423_meatloaf-with-blackberry-bbq-sauce_3x2_julia-gartland_0929.jpg", 15, "Meatloaf with Blackberry Barbecue Sauce" },
                    { 23, 1, 25, 2, "These bars are gluten free, refined sugar free and oil free. The only fat is the natural fat in the quinoa. They are packed with slow release energy and lean proteins as well as essential amino acids.", "https://images.food52.com/8Kp-okomWEUp51v5gcP5Dgzs19g=/1008x672/filters:format(webp)/7be5de7c-5360-44ca-83a4-ce794b42da42--NobakequinoabarsF52_copy.jpg", 5, "No bake quinoa breakfast bar" },
                    { 28, 4, 10, 2, "Lighter, frothier, and more refined than your classic one-cup-and-you're-out eggnog, this playful variation will keep the party going strong. The cognac shines through in every sip, so be sure to crack open the good stuff.", "https://images.food52.com/V1FO_XjnoNVhshY7CHZ9bnDMUBI=/1008x672/filters:format(webp)/7b1c12c1-1c2e-40ba-a391-ffa89d9ce499--2015-1207_warm-egg-nog_james-ransom-022_1-.jpg", 10, "Warm Eggnog" },
                    { 29, 3, 35, 2, "It's saucy, flavorful, fresh, and it comes together in about half an hour. I developed these chicken and lettuce wraps while on Whole 30, so they fit that bill if you need 'em to.", "https://images.food52.com/98RdFLSan-TMm1PBpHR3Q8KdjpU=/1008x672/filters:format(webp)/75d05b4e-f802-4dca-9ec5-bfe3fb8addbd--more_crop_2018-1026_whole-30-spicy-braised-chicken-lettuce-cups_3x2_mark-weinberg_258.png", 20, "Spicy Braised Chicken Lettuce Wrap" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookTimeInMin", "CreatedById", "Description", "ImageUrl", "PrepTimeInMin", "Title" },
                values: new object[] { 31, 3, 60, 2, "Like many baked dishes, this lasagna is even tastier the day after it is prepared, as the flavors meld together as it sits. The combination of the pine nuts and the golden raisins makes for some unique tastes", "https://images.food52.com/WazrFsvHZ_SxVgSAKeisVz23vZk=/1008x672/filters:format(webp)/71e3bb10-e3d8-4f9d-bb42-12c1d3f71075--2018-0228_vegetable-lasagna_3x2_jenny-huang_02.jpg", 15, "Lasagna Verde" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookTimeInMin", "CreatedById", "Description", "ImageUrl", "PrepTimeInMin", "Title" },
                values: new object[] { 35, 4, 30, 2, "An ethereal cloud of cream shot through with cherry and almond. We allow the sweet, juicy cherries to shine by doing very little to them, a touch of sugar, lemon juice and almond extract makes it perfect", "https://images.food52.com/7nPicB4QPiDUjhRciiw-XrAu56w=/1008x672/filters:format(webp)/afa0e9b1-6ef5-4bb3-ac13-a73b626b7dae--062910F_434.JPG", 15, "Cherry Brown Sugar Fool with Honey Almonds" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookTimeInMin", "CreatedById", "Description", "ImageUrl", "PrepTimeInMin", "Title" },
                values: new object[] { 41, 2, 15, 4, "I saw a grilled cheese with mustard on a menu years ago, and since then, on the rare occasion that I’ll throw caution to the wind and make or order a big grilled cheese sandwich, I have to have some mustard on the side. Mustard makes almost everything better, I’d argue.", "https://images.food52.com/wUmWU2DSByNHfClMsi5Bo2HzqX4=/1008x672/filters:format(webp)/4c8c03d7-c87d-43c7-82c4-c3542fb66a02--2014-0923_mustardy-grilled-cheese-012.jpg", 10, "Mustardy Grilled Cheese" });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 119, "1/2 pound boneless", 82, 11 },
                    { 76, "3", 1, 7 },
                    { 77, "1/4 cup", 6, 7 },
                    { 78, "1", 68, 7 },
                    { 414, "1 teaspoon", 168, 35 },
                    { 413, "2 tablespoons", 158, 35 },
                    { 412, "3/4 cup", 62, 35 },
                    { 411, "2 tablespoons", 76, 35 },
                    { 410, "1 tablespoon", 117, 35 },
                    { 409, "1/2 teaspoon", 175, 35 },
                    { 408, "1 teaspoon", 247, 35 },
                    { 407, "1 cup", 246, 35 },
                    { 406, "1 tablespoon", 245, 35 },
                    { 405, "1/3 cup sliced", 186, 35 },
                    { 152, "1/4 cup", 119, 13 },
                    { 75, "4", 67, 7 },
                    { 153, "1 teaspoon", 120, 13 },
                    { 392, "1 tablespoon", 240, 33 },
                    { 391, "1 1/4 cups plain", 239, 33 },
                    { 390, "1/4 cup", 76, 33 },
                    { 389, "1 teaspoon", 4, 33 },
                    { 388, "3/4 cup", 117, 33 },
                    { 387, "3 cups", 238, 33 },
                    { 154, "1 1/2 ounces strong", 121, 13 },
                    { 155, "1/2 teaspoon fresh", 122, 13 },
                    { 156, "1/4 teaspoon", 123, 13 },
                    { 157, "1 pinch", 117, 13 },
                    { 378, "Grated", 233, 31 },
                    { 377, "1 tablespoon", 232, 31 },
                    { 376, "4 cups", 211, 31 },
                    { 375, "7 ounces", 231, 31 },
                    { 393, "1 tablespoon", 175, 33 },
                    { 479, "3 tablespoons dried", 268, 42 },
                    { 480, "3 tablespoons", 254, 42 },
                    { 481, "2 tablespoons", 272, 42 },
                    { 58, "1/4 cup", 53, 5 },
                    { 57, "", 19, 5 },
                    { 56, "", 52, 5 },
                    { 55, "1 tablespoon", 51, 5 },
                    { 54, "1/3 cup", 50, 5 },
                    { 53, "8 ounces", 49, 5 },
                    { 52, "4 tablespoons", 20, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 51, "2 cloves", 21, 5 },
                    { 50, "1 large chopped ", 48, 5 },
                    { 49, "2", 47, 5 },
                    { 48, "2", 46, 5 },
                    { 47, "2", 45, 5 },
                    { 71, "1 1/2 teaspoons", 4, 7 },
                    { 72, "1/2 teaspoon", 64, 7 },
                    { 73, "1 1/2 cup", 65, 7 },
                    { 74, "1", 66, 7 },
                    { 496, "1/2 cup crumbled", 278, 42 },
                    { 482, "1/2 teaspoon", 4, 42 },
                    { 483, "1 teaspoon", 273, 42 },
                    { 484, "1 cup", 274, 42 },
                    { 485, "1/4 cup", 275, 42 },
                    { 486, "1 3/4 cups boiling", 76, 42 },
                    { 487, "2", 276, 42 },
                    { 374, "1 tablespoon", 53, 31 },
                    { 488, "2 tablespoons", 20, 42 },
                    { 490, "6 inner stalks of", 265, 42 },
                    { 491, "2", 277, 42 },
                    { 492, "1 pinch", 10, 42 },
                    { 493, "1 pinch", 19, 42 },
                    { 494, "1/2 cup", 239, 42 },
                    { 495, "1/4 cup chopped toasted", 187, 42 },
                    { 489, "1/2 cup finely chopped", 108, 42 },
                    { 70, "8 cups", 63, 7 },
                    { 373, "8 tablespoons", 2, 31 },
                    { 371, "1 tablespoon", 229, 31 },
                    { 165, "Grape-seed or other high-heat", 126, 13 },
                    { 166, "1", 127, 13 },
                    { 167, "1 small handful", 128, 13 },
                    { 294, "100ml Fresh ", 196, 23 },
                    { 293, "Small piece fresh", 195, 23 },
                    { 292, "3", 194, 23 },
                    { 291, "1 tablespoon", 193, 23 },
                    { 290, "2 tablespoons", 192, 23 },
                    { 289, "25g", 191, 23 },
                    { 288, "6 ", 190, 23 },
                    { 287, "25g", 189, 23 },
                    { 286, "50g flaked", 186, 23 },
                    { 285, "150g ", 188, 23 },
                    { 234, "(for sauce) generous pinch", 19, 17 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 330, "8 large", 210, 28 },
                    { 233, "(for sauce) generous pinch", 10, 17 },
                    { 231, "(for sauce) 1 tablespoon", 159, 17 },
                    { 230, "(for sauce) 1/2 cup", 158, 17 },
                    { 229, "(for sauce) 2 cups", 157, 17 },
                    { 228, "(for sauce) 2 cloves", 21, 17 },
                    { 227, "(for sauce) 2 small quartered", 156, 17 },
                    { 225, "3/4 cup", 154, 17 },
                    { 224, "1", 67, 17 },
                    { 223, "1 tablespoon", 103, 17 },
                    { 222, "3 cloves", 21, 17 },
                    { 221, "1/2 teaspoon cracked", 19, 17 },
                    { 220, "1/2 teaspoon", 4, 17 },
                    { 219, "1/2 teaspoon", 153, 17 },
                    { 218, "1/2 cup diced", 83, 17 },
                    { 217, "1/2 pound", 152, 17 },
                    { 232, "(for sauce) 1 teaspoon", 160, 17 },
                    { 331, "3/4 cup granulated", 117, 28 },
                    { 332, "1/8 teaspoon", 10, 28 },
                    { 333, "4 cups", 211, 28 },
                    { 370, "", 10, 31 },
                    { 369, "4", 228, 31 },
                    { 368, "6 cups unbleached", 227, 31 },
                    { 158, "1 pinch", 4, 13 },
                    { 159, "", 19, 13 },
                    { 160, "1/4 pound", 124, 13 },
                    { 161, "1 tablespoon raw grated", 78, 13 },
                    { 354, "1/2 cup shredded", 220, 29 },
                    { 353, "2", 219, 29 },
                    { 352, "1", 89, 29 },
                    { 351, "1 head", 218, 29 },
                    { 350, "2 tablespoons roughly chopped", 217, 29 },
                    { 349, "1/4 cup warm", 76, 29 },
                    { 348, "1 tablespoon", 136, 29 },
                    { 347, "2", 138, 29 },
                    { 346, "1 tablespoon plus 2 teaspoons", 120, 29 },
                    { 345, "1 cup", 216, 29 },
                    { 334, "1/2 cup", 212, 28 },
                    { 335, "1 tablespoon", 168, 28 },
                    { 336, "1 cup", 213, 28 },
                    { 337, "1", 203, 28 },
                    { 164, "1/2 teaspoon ground", 58, 13 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 163, "1/2 teaspoon ground", 125, 13 },
                    { 372, "1 1/2 pounds", 230, 31 },
                    { 162, "1 teaspoon", 103, 13 },
                    { 339, "2 1/2 teaspoons", 4, 29 },
                    { 340, "1/4 cup", 20, 29 },
                    { 341, "1/2 teaspoon", 215, 29 },
                    { 342, "1/2 teaspoon", 160, 29 },
                    { 343, "1", 83, 29 },
                    { 344, "2 cloves", 21, 29 },
                    { 338, "1 pound boneless skinless", 214, 29 },
                    { 216, "1/2 pound", 151, 17 },
                    { 523, "", 139, 45 },
                    { 80, "4", 70, 8 },
                    { 357, "1 pinch", 10, 30 },
                    { 356, "7 tablespoons", 20, 30 },
                    { 355, "1 small head", 221, 30 },
                    { 442, "1 medium", 48, 39 },
                    { 443, "1 clove", 21, 39 },
                    { 444, "1 handful", 108, 39 },
                    { 329, "3 tablespoons", 209, 27 },
                    { 328, "2 teaspoons", 168, 27 },
                    { 327, "3 ounces bittersweet", 208, 27 },
                    { 326, "3/4 teaspoon", 4, 27 },
                    { 325, "1 cup", 158, 27 },
                    { 324, "2 13.5 ounce cans", 207, 27 },
                    { 445, "1/2 teaspoon", 10, 39 },
                    { 446, "1 cup finely diced", 258, 39 },
                    { 358, "1 pinch", 19, 30 },
                    { 251, "1/3 cup shredded unsweetened", 170, 19 },
                    { 249, "1 tablespoon", 169, 19 },
                    { 248, "1 teaspoon", 168, 19 },
                    { 247, "1 teaspoon", 58, 19 },
                    { 246, "1/4 cup", 167, 19 },
                    { 245, "1 cup", 166, 19 },
                    { 244, "2 cups", 165, 19 },
                    { 447, "2 teaspoons minced pitted", 259, 39 },
                    { 448, "1 pint", 255, 39 },
                    { 449, "1 tablespoon finely chopped", 224, 39 },
                    { 450, "1 pinch", 260, 39 },
                    { 451, "1/4 cups", 261, 39 },
                    { 452, "1 teaspoon", 262, 39 },
                    { 243, "1 tablespoon", 164, 18 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 242, "4 soft", 96, 18 },
                    { 250, "1 pinch", 81, 19 },
                    { 359, "1", 222, 30 },
                    { 360, "1/2", 1, 30 },
                    { 361, "1/2 teaspoon", 223, 30 },
                    { 425, "", 249, 36 },
                    { 424, "2 cups seedless", 248, 36 },
                    { 423, "1/4 teaspoon", 10, 36 },
                    { 422, "2 teaspoons", 172, 36 },
                    { 421, "3/4 cup ground", 186, 36 },
                    { 420, "1 1/4 cups", 227, 36 },
                    { 419, "1/2 cup", 117, 36 },
                    { 418, "1", 1, 36 },
                    { 417, "3", 210, 36 },
                    { 416, "1/2 cup", 20, 36 },
                    { 415, "1 cup", 239, 36 },
                    { 426, "1 cup", 154, 37 },
                    { 427, "3 green pods", 243, 37 },
                    { 428, "1 teaspoon", 2, 37 },
                    { 429, "2 tablespoons", 234, 37 },
                    { 430, "1/2 teaspoon", 250, 37 },
                    { 386, "1/2 cup", 237, 32 },
                    { 362, "1 small clove", 21, 30 },
                    { 363, "1 pinch", 100, 30 },
                    { 364, "3 large leaves", 224, 30 },
                    { 365, "2 tablespoons diced", 48, 30 },
                    { 366, "1 1/2 cups loose cubed stale French", 225, 30 },
                    { 367, "Freshly grated", 226, 30 },
                    { 241, "Sliced", 163, 18 },
                    { 441, "2 cups uncooked", 257, 39 },
                    { 380, "6 tablespoons", 204, 32 },
                    { 381, "4 cups", 62, 32 },
                    { 382, "6 ounces", 234, 32 },
                    { 383, "1 teaspoon", 168, 32 },
                    { 384, "4 ounces", 235, 32 },
                    { 385, "1 tablespoon", 236, 32 },
                    { 379, "1 cup", 117, 32 },
                    { 79, "3/4 pound", 69, 8 },
                    { 240, "1", 83, 18 },
                    { 238, "", 131, 18 },
                    { 191, "1 pound lean", 90, 15 },
                    { 190, "1 clove", 21, 15 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 189, "1 small finely diced", 78, 15 },
                    { 188, "1 tablespoon", 20, 15 },
                    { 515, "4 cups", 154, 45 },
                    { 516, "3/4 cup quick-cook", 284, 45 },
                    { 517, "1/2 cup", 285, 45 },
                    { 518, "4 tablespoons", 164, 45 },
                    { 118, "1 handful chopped", 99, 10 },
                    { 117, "1 piece", 98, 10 },
                    { 116, "1 handful barbecue-flavored", 97, 10 },
                    { 115, "6", 96, 10 },
                    { 114, "1/2 cup diced", 95, 10 },
                    { 113, "2 cups shredded", 94, 10 },
                    { 192, "1/2 teaspoon", 10, 15 },
                    { 112, "1 1/2 cups", 93, 10 },
                    { 110, "1 teaspoon", 19, 10 },
                    { 109, "1 teaspoon", 10, 10 },
                    { 108, "1 cup", 91, 10 },
                    { 107, "2 pounds", 90, 10 },
                    { 519, "1/3 cup", 245, 45 },
                    { 520, "1 cup", 174, 45 },
                    { 521, "1/2 teaspoon", 168, 45 },
                    { 522, "1 pinch", 286, 45 },
                    { 86, "1 pound", 74, 8 },
                    { 85, "1", 73, 8 },
                    { 84, "1", 72, 8 },
                    { 83, "3/4 cup", 20, 8 },
                    { 82, "1/2 cup", 71, 8 },
                    { 81, "2 cloves", 21, 8 },
                    { 111, "1 teaspoon", 92, 10 },
                    { 193, "3 tablespoons", 140, 15 },
                    { 194, "1 1/2 cups", 141, 15 },
                    { 195, "1 teaspoon", 103, 15 },
                    { 237, "", 10, 18 },
                    { 236, "4 slices", 161, 18 },
                    { 235, "2 pounds", 90, 18 },
                    { 453, "1 tablespoon", 120, 39 },
                    { 454, "2 teaspoons", 245, 39 },
                    { 497, "3 ears of", 279, 43 },
                    { 214, "1/4 cup chopped fresh", 108, 16 },
                    { 213, "1 cup", 150, 16 },
                    { 212, "16 ounces", 149, 16 },
                    { 211, "1 cup", 148, 16 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 210, "1/2 cup dry", 25, 16 },
                    { 209, "2 teaspoons sweet", 130, 16 },
                    { 208, "2 teaspoons", 147, 16 },
                    { 207, "1 teaspoon dried", 84, 16 },
                    { 206, "6 cloves", 21, 16 },
                    { 205, "1 large", 146, 16 },
                    { 204, "1 large", 145, 16 },
                    { 196, "2 450-gram packages pre-rolled", 142, 15 },
                    { 197, "3/4 cup (100g) aged white", 143, 15 },
                    { 198, "1", 67, 15 },
                    { 503, "1/2", 89, 43 },
                    { 502, "1/4 cup crumbled", 281, 43 },
                    { 501, "1/4 cup chopped", 43, 43 },
                    { 239, "", 162, 18 },
                    { 500, "2 tablespoons", 280, 43 },
                    { 498, "1", 146, 43 },
                    { 199, "2 pounds", 144, 16 },
                    { 200, "", 10, 16 },
                    { 201, "", 131, 16 },
                    { 202, "1/4 cup", 20, 16 },
                    { 203, "1 large", 83, 16 },
                    { 499, "2 tablespoons", 20, 43 },
                    { 215, "1/2 pound", 90, 17 },
                    { 226, "3 pieces", 155, 17 },
                    { 253, "1/2 cup", 154, 20 },
                    { 459, "2 large or 3 small", 264, 40 },
                    { 458, "1 large bulb", 263, 40 },
                    { 457, "1 clove", 21, 40 },
                    { 456, "1 large", 36, 40 },
                    { 455, "2 tablespoons", 2, 40 },
                    { 431, "4 portions", 251, 38 },
                    { 432, "1 pint cooked", 252, 38 },
                    { 323, "", 81, 26 },
                    { 322, "1 teaspoon", 168, 26 },
                    { 321, "1 pinch", 4, 26 },
                    { 320, "1 cup", 109, 26 },
                    { 319, "1 cup", 2, 26 },
                    { 318, "18 ounces", 206, 26 },
                    { 317, "1 cup finely chopped", 186, 26 },
                    { 460, "2 stalks", 265, 40 },
                    { 433, "1 quart filtered", 76, 38 },
                    { 435, "3 tablespoons", 4, 38 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 436, "2 tablespoons", 253, 38 },
                    { 437, "4 tablespoons toasted and wild", 254, 38 },
                    { 438, "1 pint", 255, 38 },
                    { 439, "2 tablespoons", 256, 38 },
                    { 440, "1", 115, 38 },
                    { 316, "1 teaspoon", 168, 25 },
                    { 315, "1 1/2 cups", 205, 25 },
                    { 314, "5 tablespoons", 204, 25 },
                    { 313, "1/2 teaspoon ground", 203, 25 },
                    { 312, "2 teaspoons", 202, 25 },
                    { 311, "2 teaspoons", 172, 25 },
                    { 310, "1 teaspoon", 10, 25 },
                    { 309, "3 cups", 140, 25 },
                    { 434, "4 tablespoons", 117, 38 },
                    { 308, "2 cups pureed roasted", 201, 25 },
                    { 461, "1 tablespoon", 247, 40 },
                    { 463, "1/2 teaspoon", 4, 40 },
                    { 5, "1 pound", 5, 1 },
                    { 4, "", 4, 1 },
                    { 3, "2 tablespoons", 3, 1 },
                    { 2, "3 tablespoons", 2, 1 },
                    { 1, "2", 1, 1 },
                    { 397, "1/2 cup", 211, 34 },
                    { 398, "5 tablespoons", 117, 34 },
                    { 252, "2 cups", 171, 20 },
                    { 400, "one 14-ounce can", 242, 34 },
                    { 401, "8 tablespoons", 2, 34 },
                    { 514, "", 280, 44 },
                    { 513, "", 283, 44 },
                    { 512, "8 slices day-old", 225, 44 },
                    { 511, "", 164, 44 },
                    { 462, "1 tablespoon", 245, 40 },
                    { 510, "", 162, 44 },
                    { 508, "1 1/2 tablespoons", 113, 44 },
                    { 507, "2 teaspoons", 19, 44 },
                    { 506, "1 teaspoon", 10, 44 },
                    { 505, "3 tablespoons", 282, 44 },
                    { 504, "5", 210, 44 },
                    { 402, "5 to 7 pods", 243, 34 },
                    { 403, "1/8 teaspoon", 244, 34 },
                    { 404, "1/2 cup slivered", 186, 34 },
                    { 469, "1/2 cup", 62, 40 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 468, "2 tablespoons chopped", 269, 40 },
                    { 467, "1 teaspoon chopped fresh", 268, 40 },
                    { 466, "3 tablespoons chopped", 267, 40 },
                    { 465, "1 cup", 266, 40 },
                    { 464, "3 cups", 63, 40 },
                    { 509, "1 1/2 tablespoons", 43, 44 },
                    { 307, "1/2 cup packed", 158, 25 },
                    { 306, "1 1/2 cups", 117, 25 },
                    { 305, "3 large", 67, 25 },
                    { 175, "1/4 cup", 76, 14 },
                    { 174, "1/2 cup", 17, 14 },
                    { 173, "1 pound", 132, 14 },
                    { 172, "2 tablespoons", 126, 14 },
                    { 171, "1 teaspoon", 131, 14 },
                    { 170, "1 teaspoon smoked", 130, 14 },
                    { 169, "1 teaspoon", 129, 14 },
                    { 168, "2 cloves", 21, 14 },
                    { 476, "6 tablespoons stoneground", 271, 41 },
                    { 477, "24 to 28 slices", 143, 41 },
                    { 478, "1/4", 48, 41 },
                    { 138, "1 teaspoon", 20, 11 },
                    { 137, "1/4 cup chopped fresh", 108, 11 },
                    { 136, "1/2 zested", 1, 11 },
                    { 176, "1/2 teaspoon", 10, 14 },
                    { 135, "2 tablespoons", 107, 11 },
                    { 133, "2 small", 105, 11 },
                    { 132, "4 ounces", 104, 11 },
                    { 131, "2 teaspoons", 103, 11 },
                    { 130, "1 cup", 76, 11 },
                    { 129, "1 cup", 102, 11 },
                    { 128, "1", 77, 11 },
                    { 127, "1 teaspoon", 101, 11 },
                    { 126, "1/2 teaspoon crushed", 100, 11 },
                    { 125, "1 tablespoon", 85, 11 },
                    { 124, "4 cloves", 21, 11 },
                    { 123, "1 large", 36, 11 },
                    { 122, "2 tablespoons", 20, 11 },
                    { 121, "1 pinch", 19, 11 },
                    { 120, "1 pinch", 10, 11 },
                    { 134, "", 106, 11 },
                    { 177, "1 teaspoon", 117, 14 },
                    { 178, "1 small", 48, 14 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 179, "1", 91, 14 },
                    { 304, "1 cup", 2, 25 },
                    { 303, "1 teaspoon Raw", 200, 24 },
                    { 302, "2 tablespoons", 32, 24 },
                    { 301, "2 tablespoons", 199, 24 },
                    { 300, "2 tablespoons", 198, 24 },
                    { 299, "2 tablespoons", 197, 24 },
                    { 298, "1/2 teaspoon Ground", 58, 24 },
                    { 297, "1 teaspoon", 168, 24 },
                    { 296, "1/2 cup", 166, 24 },
                    { 295, "2 tablespoons", 193, 24 },
                    { 470, "1 bunch", 270, 41 },
                    { 471, "3 tablespoons", 20, 41 },
                    { 271, "2 tablespoons Pickled", 48, 21 },
                    { 270, "1 Fried", 67, 21 },
                    { 269, "2 pieces Thick Sliced", 180, 21 },
                    { 268, "1 piece", 179, 21 },
                    { 267, "2 tablespoons", 178, 21 },
                    { 180, "1 can", 133, 14 },
                    { 181, "1/4 teaspoon", 134, 14 },
                    { 182, "1/2 teaspoon", 135, 14 },
                    { 183, "2 teaspoons", 136, 14 },
                    { 184, "", 137, 14 },
                    { 185, "sliced", 138, 14 },
                    { 6, "1 handful", 6, 1 },
                    { 186, "", 43, 14 },
                    { 475, "8 slices thick-cut", 225, 41 },
                    { 474, "8 tablespoons", 2, 41 },
                    { 473, "1 pinch", 131, 41 },
                    { 472, "1 pinch ", 10, 41 },
                    { 265, "1 Grilled", 176, 21 },
                    { 266, "1 toasted", 177, 21 },
                    { 187, "", 139, 14 },
                    { 7, "", 7, 1 },
                    { 399, "1/2 cup", 241, 34 },
                    { 40, "6", 38, 4 },
                    { 67, "1 1/4 cup", 61, 6 },
                    { 66, "1 pinch", 60, 6 },
                    { 65, "1 pinch", 10, 6 },
                    { 64, "3 teaspoons", 59, 6 },
                    { 63, "2 teaspoons", 58, 6 },
                    { 62, "1 1/2 cup", 57, 6 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 61, "1 cup", 56, 6 },
                    { 60, "3/4 cup", 55, 6 },
                    { 59, "4", 54, 6 },
                    { 8, "", 8, 1 },
                    { 274, "1", 181, 22 },
                    { 275, "150 grams plain", 182, 22 },
                    { 276, "1", 67, 22 },
                    { 277, "1", 183, 22 },
                    { 278, "2-3", 105, 22 },
                    { 46, "2", 44, 4 },
                    { 45, "1/4 cup roughly chopped", 43, 4 },
                    { 44, "1/4 cup", 42, 4 },
                    { 43, "1/4 cup", 41, 4 },
                    { 42, "1 cup", 40, 4 },
                    { 41, "1/2 teaspoon", 39, 4 },
                    { 263, "1/4 cup", 167, 20 },
                    { 39, "1 teaspoon", 4, 4 },
                    { 38, "1", 37, 4 },
                    { 37, "1", 36, 4 },
                    { 68, "1 tablespoon", 2, 6 },
                    { 36, "1 pinch", 35, 4 },
                    { 69, "2 tablespoons", 62, 6 },
                    { 273, "70 milliliters", 167, 22 },
                    { 106, "1", 89, 9 },
                    { 105, "1/2 cup", 88, 9 },
                    { 104, "1 cup", 87, 9 },
                    { 103, "1.28oz", 86, 9 },
                    { 261, "2 cups", 174, 20 },
                    { 102, "1 tablespoon", 85, 9 },
                    { 101, "1 tablespoon", 84, 9 },
                    { 100, "2 large cloves", 21, 9 },
                    { 99, "2 cups", 83, 9 },
                    { 98, "1 splash", 30, 9 },
                    { 97, "1 1/2 pounds boneless", 82, 9 },
                    { 96, "1 kosher", 81, 9 },
                    { 95, "1 tablespoon", 59, 9 },
                    { 94, "1/2 teaspoon", 58, 9 },
                    { 93, "1 teaspoon", 52, 9 },
                    { 92, "1 tablespoon", 80, 9 },
                    { 91, "4", 79, 9 },
                    { 90, "1", 78, 9 },
                    { 89, "1", 77, 9 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 88, "2 1/2 cups", 76, 9 },
                    { 87, "1/2 pound", 75, 9 },
                    { 264, "1/2 teaspoon", 175, 20 },
                    { 260, "1 tablespoon", 164, 20 },
                    { 259, "1/2 teaspoon", 173, 20 },
                    { 272, "60 milliliters", 20, 22 },
                    { 258, "1/4 teaspoon", 10, 20 },
                    { 35, "1/2 teaspoon", 34, 4 },
                    { 262, "1/2 cup softened", 164, 20 },
                    { 33, "1/4 cup", 32, 4 },
                    { 22, "2 cloves", 21, 3 },
                    { 34, "1/2 teaspoon", 33, 4 },
                    { 148, "1 to 2 teaspoons", 116, 12 },
                    { 21, "3 tablespoons", 20, 3 },
                    { 283, "100 grams chopped", 186, 22 },
                    { 284, "", 187, 22 },
                    { 149, "2 teaspoons", 117, 12 },
                    { 20, "", 19, 2 },
                    { 19, "1/4 cup", 18, 2 },
                    { 18, "1", 1, 2 },
                    { 17, "1 tablespoon", 17, 2 },
                    { 16, "1 tablespoon", 16, 2 },
                    { 15, "2 teaspoons", 15, 2 },
                    { 14, "1/4 cup", 14, 2 },
                    { 13, "1 cup", 13, 2 },
                    { 12, "3 tablespoons", 12, 2 },
                    { 11, "4 cups", 11, 2 },
                    { 10, "", 10, 2 },
                    { 9, "1/4 cup", 9, 2 },
                    { 150, "1 teaspoon", 118, 12 },
                    { 151, "1/2 to 1 teaspoons", 4, 12 },
                    { 256, "1 cup", 140, 20 },
                    { 255, "1 tablespoon", 117, 20 },
                    { 254, "4", 67, 20 },
                    { 394, "2 cups", 227, 34 },
                    { 395, "3 teaspoons double acting", 172, 34 },
                    { 396, "2 cups shredded", 105, 34 },
                    { 23, "12", 22, 3 },
                    { 24, "1 pound", 23, 3 },
                    { 147, "2 English", 115, 12 },
                    { 146, "4 to 5 pounds thinly sliced", 114, 12 },
                    { 32, "4 slices", 31, 4 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 31, "2 tablespoons", 30, 4 },
                    { 257, "1 teaspoon", 172, 20 },
                    { 139, "3 cups packed light", 109, 12 },
                    { 140, "1 1/2 cups", 110, 12 },
                    { 141, "5 tablespoons", 111, 12 },
                    { 142, "4 tablespoons", 112, 12 },
                    { 143, "4", 113, 12 },
                    { 144, "4 cloves", 21, 12 },
                    { 145, "1 teaspoon", 19, 12 },
                    { 279, "1 teaspoon", 172, 22 },
                    { 280, "1 teaspoon", 58, 22 },
                    { 281, "100 grams", 184, 22 },
                    { 25, "1 tablespoon", 24, 3 },
                    { 282, "150 grams", 185, 22 },
                    { 30, "", 29, 3 },
                    { 29, "2 tablespoon", 28, 3 },
                    { 26, "1/2 glass", 25, 3 },
                    { 28, "1 packet", 27, 3 },
                    { 27, "4", 26, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeRatings",
                columns: new[] { "RecipeId", "UserId", "Comment", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Loved it! The lemon juice really added a nice kick to the recipe.", 5.0 },
                    { 1, 2, "Great taste and easy to make.", 4.0 },
                    { 3, 4, "Tastes like the one my mother used to make.", 5.0 },
                    { 2, 1, "I've been making this to eat at work during lunchtime. Tasty and takes almost no effort to make.", 4.0 },
                    { 1, 3, "I liked it, but next time I'm gonig to try it without the horseradish!", 3.0 },
                    { 4, 3, "Good Bread.", 3.0 },
                    { 4, 2, "Tastes like the one my mother used to make.", 5.0 },
                    { 6, 4, "Good Bread.", 3.0 },
                    { 6, 3, "Very tasty and quick to make.", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 61, 0, "For the burger, gently mix together the ground beef, onion, Worcestershire, rosemary, cumin, cinnamon, salt, and pepper until just combined. Form into a single patty, about the size of your burger bun, making sure to press a shallow indentation in the center so it stays flat when you sear it.", false, 13 },
                    { 62, 0, "Brush the prepared patty with some oil and plop onto a hot griddle or small frying pan, cooking 3 minutes on the first side and 2 on the second. (Or until the internal temperature reaches 145F for medium-rare and 160F for medium.) Let rest about 5 minutes.", false, 13 },
                    { 167, 0, "In a small saucepan, heat milk and cardamom pods over medium-low heat. Let simmer for 10 minutes.", false, 37 },
                    { 183, 0, "First, cook your mustard greens. Clean and trim the leaves, then heat 3 tablespoons of olive oil in a large pan over medium-high heat. Add in the greens and stir until wilted, about 5 minutes or so. Season with salt and pepper to taste, then remove from the pan and set aside. Wipe out the inside of the pan with a paper towel.", false, 41 },
                    { 168, 0, "Heat butter and chocolate in another saucepan over medium-low heat. Stir until smooth.", false, 37 },
                    { 169, 0, "Whisking constantly, add hot milk in a steady stream. Remove from heat and remove cardamom pods. Stir in vanilla and serve immediately.", false, 37 },
                    { 166, 0, "Bake for 15 mns or until a tester comes out clean. Let cool before eating or not. Could be served with some Greek yogurt with honey on the side.", false, 36 },
                    { 184, 0, "Butter both sides of each slice of bread, then reduce the pan’s heat to medium and add in 4 slices of bread at a time and toast one side. Flip two of the slices of bread and add 1 1/2 tablespoons of mustard, followed by 3 to 4 slices of cheese, 1/4 of the mustard greens, a few slices of red onion, and an additional 3 to 4 slices of cheese.", false, 41 },
                    { 63, 0, "To assemble, lay the bottom bun with a healthy pile of arugula, then the warm brisket patty (which will wilt the lettuce slightly), followed by the top bun, which should be smeared generously with the prepared blue cheese mayo.", false, 13 },
                    { 175, 0, "Discard the onion, garlic and large pieces of parsley. Spread out on a rimmed sheet pan and let cool completely (do not skip this step or the mozzarella will melt into the finished dish).", false, 39 },
                    { 94, 0, "Make the maple butter first: dump the softened butter into a bowl, add the maple syrup, and mash together thoroughly with a fork. Add the almond extract and continue mixing until everything is combined. Scrape into a small bowl and set aside or refrigerate if not using within the hour.", false, 20 },
                    { 104, 0, "Bake the muffins in the preheated oven at 175 degrees C (347 degrees F) for about 20 minutes.", false, 22 },
                    { 103, 0, "Add the flour-mixture to the yoghurt-egg-mixture and fold in carefully. Add grated carrots and apple as well as the chopped almonds. Place the batter in 12 muffins tins. If you like you can add some chopped walnuts on top.", false, 22 },
                    { 201, 0, "Turn heat off and whisk in honey, blueberries, vanilla and cardamom. Serve with a dollop of creme fraiche or sour cream and an extra sprinkle of blueberries.", false, 45 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 200, 0, "Reduce heat to low and add polenta, whisking constantly until smooth. Add almond meal and continue whisking until the polenta thickens to a creamy consistency. Add butter and whisk until it melts completely.", false, 45 },
                    { 199, 0, "Bring milk to a boil in a medium saucepan over high heat.", false, 45 },
                    { 102, 0, "Blend yoghurt, banana, maple syrup and oil or melted butter with a blender. Whisk in the egg. Also using a blender, blend the oats so you get oat flour. Mix oat flour with spelt flour, salt, cinnamon, baking powder and optionally cardamom and almond flour. Peel carrots and the apple and grate finely.", false, 22 },
                    { 152, 0, "Preheat oven to 350 degrees F. In a large bowl, sieve together the flour and baking powder. Set aside. Combine the shredded carrots, whole milk, sugar, and raisins in an oven proof bowl. Pour the condensed milk over top. Mix well and microwave for 5 to 8 minutes, until the carrots are soft and have lost their raw taste.", false, 34 },
                    { 153, 0, "Add the melted butter, cardamom, and nutmeg. Combine well. (I prefer to add the spices after the carrots are cooked to ensure that the essential oils in the spices do not dissipate)", false, 34 },
                    { 30, 0, "bring stock to a boil in a large saucepan. Lower heat to a simmer and add salt, pepper, and orzo. Cook until al dente, about 8 minutes. Remove from heat. Set aside 2 cups of stock", false, 7 },
                    { 193, 0, "Add the cilantro and Cotija and squeeze the lime half over everything, stir to combine. Season with salt and pepper to taste before serving.", false, 43 },
                    { 154, 0, "Pour the carrot mixture into the center of the mixing bowl containing the flour. Fold it in gently from the sides towards the center. Take care not to over-mix, as this can cause the gluten to bind together, resulting in a tough and leathery texture.", false, 34 },
                    { 155, 0, "Spread evenly onto a sheet tray and sprinkle with slivered almonds. Bake for 20 to 25 minutes, or until the top is golden-brown.", false, 34 },
                    { 156, 0, "Allow to cool, cut into squares, and serve. These bars freeze well and will keep for up to a month in the freezer.", false, 34 },
                    { 60, 0, "For the mayo, mix all of the ingredients together and set aside. If not using right away, keep in an airtight container in the fridge.", false, 13 },
                    { 31, 0, "beat egg whites in a medium-size bowl until soft peaks form", false, 7 },
                    { 33, 0, "ladle into warm bowls and garnish with white pepper, chopped dill, a dill sprig, and sliced lemon", false, 7 },
                    { 192, 0, "Add the pepper and continue to cook until slightly softened but the peppers haven't completely lost their crunch, about 2 minutes. Pour in the sriracha and toss to coat. Remove the pan from heat.", false, 43 },
                    { 191, 0, "In a large pan, heat the olive oil over medium-high heat. Add the corn kernels in an even layer. Leave them alone about 2 to 3 minutes until starting to brown, then season with salt and pepper. Continue to cook, tossing occasionally, until the corn is well browned in spots and popping in the pan, 6 to 8 minutes.", false, 43 },
                    { 177, 0, "Pour the dressing over the ingredients and stir well to combine, using a long wooden spoon or rubber spatula. Season with salt and pepper. The salad is ready to serve, but can also be made and stored in the fridge, covered, one day ahead.", false, 39 },
                    { 176, 0, "Whisk together the olive oil, vinegars and honey to prepare the dressing. Chop the remaining onion half finely. Add onion, cooled farro, mozzarella, kalamata olives, tomatoes, remaining tablespoon of parsley and basil to a deep bowl.", false, 39 },
                    { 174, 0, "Add the farro, one onion half, garlic, handful of parsley and salt along with 2 3/4 cups water to a 2 quart pot. Bring to a boil, then cover, reduce to a simmer, and cook for 10 minutes. Turn off burner and let sit, covered, for 5 more minutes.", false, 39 },
                    { 170, 0, "Prepare the noodles according to package instructions and set aside to cool, then chill.", false, 38 },
                    { 171, 0, "Place all the ingredients for the broth in a blender at full blast until very smooth and broth-like.", false, 38 },
                    { 172, 0, "In boiling water, blanch the tomatoes for 30 seconds and place in an ice bath. Peel each tomato and discard their skins. Mix them with the garlic oil and salt, and place evenly on a sheet tray. Roast at 250° F for 1 hour and chill thoroughly.", false, 38 },
                    { 173, 0, "To assemble, place the chilled noodles into bowls, add a pint of broth to each portion, and top with the cucumbers, roasted tomatoes (plus some oil), and the wild sesame seeds. Taste and add more salt if you feel it needs it.", false, 38 },
                    { 97, 0, "Melt the butter in a large skillet over medium heat. Plop in about two tablespoons of batter per hotcake and cook for two minutes, until the undersides are golden, adjusting the heat as necessary. Flip and cook another two minutes or so, until cooked through, and remove to a plate. Continue until you have a pile of hotcakes. Serve with maple butter and blueberries.", false, 20 },
                    { 96, 0, "In a separate bowl, whisk the egg whites for as long as your forearms will let you, through the foamy stage until they start to form peaks (you can use a mixer for this, but for me, breakfast and electronics don't mix). Gently fold the egg whites into the ricotta mixture. Add a little milk if the batter looks dry - this will depend largely on the quality and freshness of your ricotta.", false, 20 },
                    { 95, 0, "Onto the hotcakes: Whisk together the ricotta, milk, egg yolks, and sugar. Sprinkle over with the flour, baking powder, and salt, and mix until just combined. Stir in the lemon zest.", false, 20 },
                    { 32, 0, "Beat in the egg yolks and lemon juice. Pour 2 cups of reserved hot stock slowly into the lemon and egg mixture, whisking continuously until all is incorporated. Return soup to medium-low heat and whisk in lemon-egg mixture. Add chicken stock back into the soup and simmer until thickened slightly, about 20 minutes", false, 7 },
                    { 165, 0, "Spray individual tart molds with olive oil. Divide the batter equally between the tart molds. Press the grape halves decoratively into the batter, cut-side down.", false, 36 },
                    { 147, 0, "Combine the pitted cherries, sugar, salt, and water in a small saucepan. If desired, wrap the reserved pits in a length of cheesecloth and add them to the mixture (this will impart a little extra natural flavor). Heat the cherries over medium heat until the sugar dissolves and the cherries release their juices. Stir occasionally.", false, 33 },
                    { 163, 0, "In a large bowl, whisk by hand the yogurt, olive oil, eggs, lemon zest and lemon juice until well blended (this could also be done in a blender or stand in mixer).", false, 36 },
                    { 23, 0, "Measure egg whites and allow to sit at room temperature for 24 hours in a covered bowl. Aging the whites helps them thin and will create a better textured macaron", false, 6 },
                    { 17, 0, "Once the upma has crisped up to your desired texture, divide among bowls and serve with chopped cilantro and a fried egg, if you like (I like).", false, 4 },
                    { 16, 0, "Add the reserved bread and cashews to the pan with the vegetables and stir everything together, ensuring the onion mixture and cauliflower florets are evenly dispersed with the bread. Cook together for about a minute more. Add the peas and cook for another minute. Carefully drizzle the yogurt over the upma and stir to combine so the bread and vegetables are completely coated. Cook for 2 to 3 minutes more, stirring only occasionally, so the upma browns and crisps up some more, helped along with the lactose sugar in the yogurt.", false, 4 },
                    { 15, 0, "Add the onions, chile, salt, turmeric, curry leaves and stir to combine, raise the heat to medium-high and cook until the onions have softened and turned translucent. Add the cauliflower florets and stir, cooking for 3 to 5 minutes longer until they have softened and are completely coated with the spice and onion mixture.", false, 4 },
                    { 14, 0, "Lower the flame to medium and add the second tablespoon of cooking fat to the pan, heating until its shimmering. Add the mustard seeds, urad dal and asafetida and shake the pan vigorously to coat everything in the fat. In 20 to 30 seconds the seeds will burst and the dal will become a deeply golden-brown color", false, 4 },
                    { 13, 0, "In a wok set over medium-high heat, add 1 tablespoon of oil and heat until shimmering. Add the cubed bread and raw cashews to the pan and toast in oil until crunchy and golden brown, shaking the pan frequently and tossing the bread so it doesn't burn. This will take 5 to 6 minutes. Remove the toasted bread and cashews and set aside.", false, 4 },
                    { 12, 0, "Add capers, parsley and olives.When the tomato juice is released and the sauce is just thickening, turn off heat. Cook pasta al dente, carefully add the sauce to the pasta over a little heat and stir gently for a minute or two.", false, 3 },
                    { 24, 0, "Line two cookie pans with parchment paper and trace 1.5 inch circles on the paper, keeping the circles about one inch apart. Preheat your oven to 300 degrees F. Pulse the almond flour, confectioners' sugar, cinnamon, and cocoa in a food processor until it is a finely mixed powder. Sift into a large bowl.", false, 6 },
                    { 11, 0, "In the meantime heat pot of hot water for pasta, generously salted. When wine is nearly evaporated, reduce heat, add tomatoes and cook for 10 minutes.", false, 3 },
                    { 9, 0, "Chop tomatoes roughly and dice the garlic. Deskin the fish and cut into bite sized chunks.", false, 3 },
                    { 8, 0, "Pour the dressing over the chicken and fold together. Squeeze in lemon juice to taste -- it will take a fair amount, probably 1/2 to 1 lemon. Let sit for 15 minutes. Taste and adjust the seasonings. Serve.", false, 2 },
                    { 7, 0, "In a bowl, toss together the onion, chicken, peppadews, artichoke hearts and almonds. In a small bowl, whisk together the thyme, mustard and vinegar. Gradually whisk in the oil. Season with salt and pepper.", false, 2 },
                    { 6, 0, "Sprinkle the onion with salt and toss to coat. Let sit for 15 minutes. Squeeze the onions to drain any juices.", false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 5, 0, "Top with the lemon zest and dill, plus a sprinkle of salt (flaky is nice if you’ve got it), and serve with crusty bread for mopping up the sauce.", false, 1 },
                    { 4, 0, "Stir in the remaining 1½ tablespoons of butter and 1 tablespoon of horseradish. Taste and increase the horseradish, if you’d like.", false, 1 },
                    { 3, 0, "As soon as that comes to a boil, add the shrimp and another big pinch of salt. Simmer for 2 to 4 minutes, flipping each shrimp halfway through, until pink and firm.", false, 1 },
                    { 10, 0, "Saute three tablespoons of oil with garlic for two minutes over medium heat. Add fish, stirring carefully until browned. Once browned, add salt and pepper, then a half glass of white wine and turn up heat. Stir carefully till wine is nearly evaporated.", false, 3 },
                    { 2, 0, "Melt 1 1/2 tablespoons of butter in a large skillet over medium heat. Stir in 1 tablespoon of horseradish, the lemon water, and a big pinch of salt.", false, 1 },
                    { 25, 0, "Put egg whites in stainless steel bowl and beat on low with a hand mixer until frothy. Add salt and cream of tartar, and slowly mix in the granulated sugar. Once the sugar is all incorporated, increase mixer speed to medium and beat until meringue forms stiff peaks.The meringue should look glossy and remain in place when the bowl is tipped on its side", false, 6 },
                    { 27, 0, "Spoon the mixture into a pastry bag or a ziplock. If using a zip-top bag, cut off a 1/4-inch tip from the corner. Pipe the mixture in a spiral to fill each 1.5-inch circle on the parchment paper. Allow the unbaked cookies to sit out for 30 minutes, until the cookies have a matte texture and are no longer sticky", false, 6 },
                    { 84, 0, "Heat your oven to 350 degrees F. In a large bowl, combine all of your ingredients, with the exception of the bbq sauce. Get in there, get dirty and greasy from the meat. Once combined, add to your bread/loaf pan which is typically 5×9. Shape into the pan, then add your sauce to the top, roughly a half cup. Place in the oven for nearly one hour and 25 minutes.", false, 17 },
                    { 83, 0, "Make the Sauce: Add the above ingredients to a blender, and puree until nice and smooth. Add this to a small pot, and cook on medium to low heat for about 20 minutes. Stir, and remove from the heat. When you make the meatloaf, add the sauce to the top before baking, and spread on the plate before serving.", false, 17 },
                    { 59, 0, "Serve the bulgogi on top of steamed rice. Garnish with green onion and toasted sesame seeds and spoon the cucumber kimchi salad alongside.", false, 12 },
                    { 58, 0, "Grill the beef on both sides until medium-well, 3 to 5 minutes, flipping halfway through cooking. Don’t crowd the skillet or foil, so do this in batches if necessary. As you finish each batch, transfer it to a serving platter and continue with the remaining beef.", false, 12 },
                    { 57, 0, "Prepare a hot grill. If the pieces of beef are so small that they may fall through the grates, use a grilling skillet or place a sheet of foil on the grill.", false, 12 },
                    { 56, 0, "To make the cucumber kimchi salad: In a medium bowl, combine the cucumbers, green onions, garlic, gochugaru, sugar, vinegar, sesame oil, and salt to taste and stir gently. Cover and refrigerate until ready to serve.", false, 12 },
                    { 55, 0, "Marinate the bulgogi: In a large bowl, whisk together the brown sugar, soy sauce, wine, sesame oil, green onions, garlic, and pepper until well combined. Add the beef and coat it completely in marinade. Cover and refrigerate for 4 to 5 hours.", false, 12 },
                    { 26, 0, "Using a silicone spatula, fold the almond and sugar mixture into the egg whites one-third at a time. You do not have to be gentle, instead use brisk strokes to fold the mixture together completely, this will help reduce the air in the meringue and keep the macaroons from being too puffy", false, 6 },
                    { 44, 0, "Add the crushed tortilla chips about an hour before serving, stirring them in so they break down and thicken the chili. Taste for salt and add a bit more if necessary, stir in the fresh lime juice off the heat, then serve with garnishes and plenty of cold beer.", false, 9 },
                    { 42, 0, "Add the chopped onion and a pinch of salt and cook until translucent. Add the garlic and marjoram or Mexican oregano and cook until fragrant. Clear a space in the bottom of the pot, add the tomato paste, and cook for a minute until it gets a little caramelized before stirring it through the onion mixture.", false, 9 },
                    { 41, 0, "Cut the short ribs into bite-sized chunks, season well with salt, and set aside. Place a small amount of oil in a deep, heavy-bottomed pot and warm until shimmering. Brown the short rib pieces in batches, removing them to a plate or platter as you finish browning.", false, 9 },
                    { 40, 0, "Toast the coriander and cumin seeds in the same dry skillet until fragrant. Transfer to a mortar and pestle, add the coarse salt, and grind. Place the softened peppers with their soaking liquid in a blender, adding the ground coriander/cumin mixture, the cinnamon, the chipotle powder, the cocoa powder, and the roasted bell pepper. Puree until smooth and set aside.", false, 9 },
                    { 39, 0, "Using kitchen shears, snip off the stems of the dried peppers and shake out most of the seeds. Toast the peppers in a dry skillet until they are fragrant and beginning to soften, then place them in a bowl and cover them with the 2 cups of boiling water. Let soak until they are very soft.", false, 9 },
                    { 38, 0, "Pick over the beans to remove any stones or debris, and place them in a large pot. Add the water, bay leaf and onion, cover the pot, and bring it to a boil. Let boil for 2 minutes, then turn off the heat and let the beans stand, undrained, for an hour. Discard the onion and bay leaf.", false, 9 },
                    { 29, 0, "When the cookies and filling are cool, spread or pipe the ganache on the flat side of one macaron and create a sandwich with a second one. EAT!", false, 6 },
                    { 28, 0, "Bake for 12 to 15 minutes. Allow to cool and then peel very gently off the parchment paper. Make ganache while the cookies cool. Melt chocolate in double boiler. Whisk in heavy cream and butter and stir mixture over gently boiling water until it is smooth and shiny.", false, 6 },
                    { 43, 0, "Return the short ribs to the pot with any juices that have accumulated on the plate or platter, then add the chile puree, the beans with their cooking liquid, and the fire-roasted tomatoes. Add the stout and stir to incorporate. Cover and simmer over low heat for at least 3-4 hours, until the beans and beef are fully tender.", false, 9 },
                    { 85, 0, "Once cooked, remove from the oven and let it cool for roughly five minutes. In the meantime, warm up more of the bbq sauce. Remove the loaf to a serving dish, and drizzle the sauce on the top. Serve with your favorite sides. I served mine with mashed potatoes. Trust me, this one is really delicious.", false, 17 },
                    { 1, 0, "Finely grate the zest of 1 lemon and set aside. Now juice both lemons into a liquid measuring cup—you should get about 6 tablespoons. Add enough cold water to reach 1/2 cup of liquid total.", false, 1 },
                    { 197, 0, "In a small bowl, mix together ketchup and hot sauce to your desired heat tolerance.", false, 44 },
                    { 111, 0, "Preheat your oven to 350 degrees F, and grease two 9-inch loaf pans. In a large frying pan, heat the butter over medium high heat. It will melt first, and then start to foam. Turn the heat down to medium. Stir the melted butter almost constantly, scraping any browning bits from the bottom of the pan. When the butter has turned a brown color and smells rich and nutty, remove it from the heat. (This should take about 7 minutes). Allow it to cool for about 10 minutes.", false, 25 },
                    { 110, 0, "After 30 minutes or in the morning, top with berries and cashews.", false, 24 },
                    { 109, 0, "Start by soaking your chia seeds in the sunflower or almond milk. Whisk well with a fork and make sure to break up any clumps. Whisk in the vanilla powder and cinnamon. Let sit for 5 minutes, stir again, and place in the fridge 30 minutes or overnight.", false, 24 },
                    { 101, 0, "Top with the other half of the toasted english muffin, and enjoy your meal!", false, 21 },
                    { 100, 0, "Atop the pesto on the bottom half of the english muffin, place the provolone covered hamburger patty, crispy bacon, fried egg, and pickled red onions.", false, 21 },
                    { 99, 0, "Spread 1 tablespoon of pesto onto the top and bottom pieces of the toasted english muffin", false, 21 },
                    { 98, 0, "Moments before burger is done grilling, place provolone cheese slice atop of the grilled hamburger patty and allow to melt.", false, 21 },
                    { 112, 0, "In the bowl of a standing mixer, beat together the eggs and sugars on high speed for several minutes, until the color has lightened. Scrape in the browned butter and beat for another couple of minutes, until the mixture is smooth.", false, 25 },
                    { 67, 0, "Toast the insides of the rolls slightly, then top them with the beans, steak, pickled vegetables, avocado slices, cilantro, and a drizzle of crema.", false, 14 },
                    { 65, 0, "Heat the vinegar, water, salt, and sugar in a saucepan. Add the onion and jalapeño and let simmer for a couple of minutes. Set aside to cool.", false, 14 },
                    { 64, 0, "Mix together the garlic, onion powder, paprika, pepper, and 2 tablespoons of oil. Toss the steak in the marinade to coat and let it sit at room temperature 30 minutes or refrigerate it for up to 8 hours. Heat the grill to medium-high. Season the steak with salt and grill until its internal temperature reaches 125 degrees F and it is nicely browned. Let the steak rest for ten minutes before slicing it very thinly against the grain.", false, 14 },
                    { 54, 0, "Serve the finished stew with the prepared mashed potatoes, pasta, or rice, and sprinkle over the gremolata for crunch.", false, 11 },
                    { 53, 0, "In the same pan, add the remaining tablespoon olive oil and cook the mushrooms and carrots without touching them too much, so they fry and almost caramelize at their edges, about 1 to 2 minutes. Add to the pot with the beef, stir, cover, and return to the oven for 30 more minutes. Check for final seasoning: salt and pepper.", false, 11 },
                    { 52, 0, "Meanwhile, make the gremolata: In a large dry skillet over medium-high heat, fry the bread crumbs until toasted just slightly browned. Add to a bowl, followed by the garlic, lemon zest, parsley, olive oil, salt, and pepper. Stir until well combined. Set aside for later.", false, 11 },
                    { 51, 0, "Add the shallot, garlic, tomato paste, red pepper flakes, herbes de Provence, and bay leaf, season with salt and pepper, and sauté for 1 minute. Add the wine and reduce a little, about 3 to 5 minutes. Add the water and Worcestershire sauce, bring to a simmer, and nestle the meat back into the pot. Cover with lid and bake for 1 1/2 hours, or until ribs are fully cooked and tender.", false, 11 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 50, 0, "Preheat the oven to 325 degrees F. Generously season the short ribs with salt and pepper and heat a small (1 1/2 to 3–quart) oven-safe saucepan over medium-high heat. Add 1 tablespoon olive oil and sear the short ribs, 2 to 3 minutes per side, until browned on all over. Remove meat to a plate, leaving rendered fat in the pan.", false, 11 },
                    { 66, 0, "Mash the beans with chipotle, cumin, lime, and salt and pepper. Taste the mixture and add salt and acid as needed. Add a spoon or two of water and heat gently before serving.", false, 14 },
                    { 198, 0, "Serve toasts warm with a side of the spicy ketchup.", false, 44 },
                    { 113, 0, "Add the puréed squash to the wet ingredients and beat until smooth and uniformly mixed in.", false, 25 },
                    { 115, 0, "Divide the batter evenly into the 2 prepared loaf pans and bake for about 50 minutes, until a tester comes out clean. Take the bread out of the loaf pans and allow to cool completely before glazing.", false, 25 },
                    { 196, 0, "Dip the bread triangles into the egg batter, drain off any excess, and place straight into the hot pan. Fry for 2 to 3 minutes on each side – you want to develop a golden-brown color and the texture should be crispier than traditional French toast. Place cooked toasts on a paper towel-lined plate or rack to drain.", false, 44 },
                    { 195, 0, "Heat a medium or large skillet over medium-high heat. Cover the bottom of the skillet with vegetable oil and add a tablespoon or two of butter for taste.", false, 44 },
                    { 194, 0, "In a bowl or baking dish, beat together eggs with half-and-half, salt, pepper, green onions, and cilantro.", false, 44 },
                    { 182, 0, "Stir in the cream and adjust the seasoning to taste. Serve garnished with chopped mint, fennel, and thyme.", false, 40 },
                    { 181, 0, "Remove from heat and toss in the greens and herbs. Purée the soup in two batches. At this point you can either simply return it to the pot or pass it through a mesh sieve for a more refined texture. I prefer the sieve, but it's up to you.", false, 40 },
                    { 180, 0, "Simmer for 10 to 15 minutes until everything is very tender and cooked through.", false, 40 },
                    { 179, 0, "Add fennel, apple, celery, lemon, honey (or sugar), salt, and chicken stock and bring to a simmer.", false, 40 },
                    { 114, 0, "In a small bowl, combine the flour, salt, baking powder, baking soda, and nutmeg. Add this to the wet ingredients, and mix on low until fully incorporated.", false, 25 },
                    { 178, 0, "Melt butter over medium heat in an 8-quart saucepan. Add shallot and garlic and sweat for 2 to 3 minutes until fragrant and translucent.", false, 40 },
                    { 122, 0, "Carefully pour the caramel mixture over the mix of nuts and chocolate. Sprinkle remaining chocolate over hot mixture. When melted, smooth out with the back of large spoon. Sprinkle remaining nuts and gently press into the toffee. If you like salted caramels, you may want to sprinkle some good-quality sea salt on top of the candy.", false, 26 },
                    { 121, 0, "Remove the pot from heat and quickly add salt and vanilla.", false, 26 },
                    { 120, 0, "Using a candy thermometer to monitor, cook butter and brown sugar over medium-high heat in medium-sized pot until you reach \"hard crack\" stage -- 300° F. Stir constantly. This will take about 15 minutes.", false, 26 },
                    { 119, 0, "Put half the nuts and half the chocolate chips onto a cookie sheet.", false, 26 },
                    { 118, 0, "Spread the icing onto the loaves, and allow to set for about 30 minutes before slicing.", false, 25 },
                    { 117, 0, "Sift the confectioner's sugar to remove lumps. Then whisk the vanilla into the butter. Next, whisk in confectioner's sugar until your reach a spreadable consistency.", false, 25 },
                    { 116, 0, "Brown the butter in a pan, just as described in step 2 for the bread and allow to cool for about 10 minutes. Scrape the butter into a mixing bowl.", false, 25 },
                    { 123, 0, "Freeze one hour before breaking into pieces for storage -- or snacking.", false, 26 },
                    { 164, 0, "Add the sugar, flour, ground almonds, baking powder and salt. Mix well.", false, 36 },
                    { 105, 0, "Place quinoa flakes, almonds and coconut into a non stick frying pan and lightly toast over a medium heat", false, 23 },
                    { 107, 0, "Place the dough into a lined dish or silicone mold and flatten with down with the back of a fork", false, 23 },
                    { 86, 0, "Separate the burger into 8 pieces and create 1/4-inch thick patties out of each one.", false, 18 },
                    { 82, 0, "Stir in the parsley and season with salt and pepper to taste. Serve over white rice.", false, 16 },
                    { 81, 0, "Transfer the beef to a plate and shred. Return shredded beef to sauce.Stir in the olives (optional). Simmer uncovered for 30 minutes to thicken.", false, 16 },
                    { 80, 0, "Return the beef to the pot. Bring to a simmer and cover for 2 to 3 hours or until the beef is fork-tender.", false, 16 },
                    { 79, 0, "Add the beef broth and crushed tomatoes. Bring to a simmer.", false, 16 },
                    { 78, 0, "Add the onion and peppers to the pot and cook over medium heat for 15 to 20 minutes until caramelized. Add the garlic, oregano, cumin, and paprika. Cook for another minute. Add the white wine and bring to a boil, scraping the bottom of the pan with the flat edge of a spatula to deglaze.", false, 16 },
                    { 77, 0, "Heat olive oil in a pot over high heat. Add the beef and brown on all sides. Then transfer to a plate.", false, 16 },
                    { 87, 0, "Fold the American cheese slices in half, twice, making a square, and stick into the middle of four of the patties, gently pressing down into the meat", false, 18 },
                    { 76, 0, "Season beef liberally with salt and freshly ground black pepper.", false, 16 },
                    { 74, 0, "Whisk the egg in a bowl. Brush the edges of the pastry overlap with the egg mixture and top with smaller pastry rounds. Press around the edges of the pies using the tines of a fork to create a seal. Cut a small slit into the top of each pie. Use the remaining egg to brush the tops of each pie. Place the tray in the freezer to chill for 15 mins before baking.", false, 15 },
                    { 73, 0, "Remove the chilled beef mixture from the fridge. Stir in the diced cheese. Evenly divide filling between each pie, packing them right to the top.", false, 15 },
                    { 72, 0, "Lightly grease a 12-cup muffin tin. Place larger puff pastry rounds in the base of each muffin tin, pressing along the sides so they are flush with the bottom and sides of the tin. The dough should slightly overlap the rims, stretch dough slightly if needed.", false, 15 },
                    { 71, 0, "Remove puff pastry from fridge. Roll sheets to 1/8-inch thick. Cut puff pastry into twelve 4-inch rounds and twelve 3-inch rounds. Pre-mark where you will cut each round as you will have just enough dough for all the rounds. Place onto a parchment-lined baking sheet and let chill in the fridge for 30 minutes.", false, 15 },
                    { 70, 0, "Scrape beef mixture into a bowl and let cool to room temperature. Cover and refrigerate until completely chilled, this will take at least 1-2 hours. The filling can easily be made the day before.", false, 15 },
                    { 69, 0, "Stir in salt and a few cracks of black pepper. Sprinkle flour over beef and cook, 1 minute. Pour in beef stock and Worcestershire sauce. Bring to a boil, scraping all the brown bits off the bottom of the pan. Reduce heat to medium-low and let simmer until gravy has reduced and thickened, about 6-8 minutes.", false, 15 },
                    { 68, 0, "Heat oil in a large frying pan over medium heat. Add onion, cook, stirring often until tender and starting to brown on the edges, about 2-3 minutes. Add garlic, cook 1 minute. Add ground beef to pan and cook, breaking up with a wooden spoon, until no pink remains, about 5-6 minutes.", false, 15 },
                    { 75, 0, "While the pies are chilling preheat the oven to 425 degrees F. Bake pies for 20-25 minutes, until golden brown. Let cool 10 minutes before serving.", false, 15 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 49, 0, "To assemble the burgers, place an equal layer of barbecue kettle chips on each bottom bun. Add a cheese-covered patty on top, followed by a layer of pickles and an equal amount of lettuce. Add the bun tops and serve with an ice-cold beer or a big ol' pitcher of tea.", false, 10 },
                    { 88, 0, "Place the other four patties on top of the patties that have the cheese, pinch to seal the edges, and form into perfect burgers roughly 3/4-inches thick. It's very important to seal it in! Season the patties liberally with salt and a few cracks of freshly ground black pepper and each side.", false, 18 },
                    { 90, 0, "Add your butter and onions to the pan and cook in the residual oil and beef fat until the onions soften and start to brown (approx. 3-5 minutes). Remove onions from the pan and set aside.", false, 18 },
                    { 162, 0, "Preheat the oven to 350F.", false, 36 },
                    { 146, 0, "Place bowl in an ice bath and stir or whisk until it's cool but not cold -- it will stiffen fairly quickly if it gets too cold. Remove from the ice bath and beat with a mixer or whisk until the ganache is fluffy and spreadable. Frost the cake immediately. Best served at room temperature.", false, 32 },
                    { 145, 0, "For the ganache: Heat cream to scalding (not boiling). Pour over the pieces of chocolate that are in a mixing bowl. Let sit 5 minutes then stir until there are no pieces of chocolate and it's smooth and shiny, then add the chocolate caramel sauce and stir to combine.", false, 32 },
                    { 144, 0, "Remove from heat and add the chocolate cream. Stir until its incorporated. Store in a container at room temperature until ready to use. Note: If you make this ahead of time, simply place the bottle or jar in hot water to warm the caramel so it’s pourable.", false, 32 },
                    { 143, 0, "In large saucepan add the sugar, turn heat to med/high and let sit until it starts to liquefy. Start stirring with a heat proof spatula. The sugar will crystalize but that's alright -- keep stirring until its all liquid. Stop stirring and let it cook until it turns amber in color, then add the butter and stir to combine.", false, 32 },
                    { 142, 0, "Put the heavy cream in a glass measuring cup and microwave on high for 45 seconds, add chocolate and microwave another 30 seconds Stir until its smooth, add the vanilla extract and stir to combine, set aside so that it will cool before adding to the caramel.", false, 32 },
                    { 137, 0, "In a large bowl, mix the lemon juice and anchovy paste with the garlic and whisk in the remaining 3 tablespoons of olive oil. Add the red pepper flakes, basil, and red onions, then the bread cubes and broccoli, and toss. Taste and adjust seasoning as needed. Serve with grated Parmesan over the top alongside the chicken.", false, 30 },
                    { 89, 0, "Pour a little oil on a cast iron pan and set it over medium-high heat. Once the oil begins to shimmer, gently place in your burgers in the pan. Cook until a hard caramelized crust forms on the bottom of the burger (3-5 minutes), flip, and repeat. Cook for an additional 3-5 minutes, remove from the heat, and set aside to rest.", false, 18 },
                    { 136, 0, "Bake 5-6 minutes or until skin is browned, bubbly, and crisp, then turn. Turn the broccoli at this point as well. Bake another 6 minutes, until just cooked through. Remove both the broccoli and the chicken and set aside on a warm plate. The broccoli should be browned in places. Cut into bite-size pieces.", false, 30 },
                    { 134, 0, "Preheat oven to 425°F.Mix broccoli with 2 tablespoons of the olive oil, then season with salt and pepper. Place on a baking sheet and put in the oven.", false, 30 },
                    { 126, 0, "Transfer to fondue pot or ceramic bowl. If using a fondue pot, make sure the heat is low to prevent scorching. Serve with fresh fruit (bananas, pineapple, strawberries, etc...) and/or angel food or pound cake cubes.", false, 27 },
                    { 125, 0, "Add the chocolate, wait about 1 minute, then stir to incorporate. Once chocolate is fully melted, stir in the vanilla and optional liquor.", false, 27 },
                    { 124, 0, "Combine coconut milk, brown sugar, and salt in a 12-inch or larger heavy skillet. Heat over medium heat until sugar dissolves, stirring occasionally. Increase heat to medium-high and cook until reduced and thickened, stirring more frequently as the mixture thickens, this should take 15 to 20 minutes. The mixture will become darker, and the bubbles will go from being somewhat frothy to looking more like bubbling lava. A wooden spoon or heat-proof spatula scraped along the bottom from one end to another should leave a trail that \"heals\" within a few seconds. When this happens, remove from heat.", false, 27 },
                    { 93, 0, "Pulse in the coconut and adjust seasonings. Divide porridge into four bowls and serve, topped with fresh berries, chopped nuts, or sliced bananas.", false, 19 },
                    { 92, 0, "Place the buckwheat groats in a food processor and pulse a few times to break down. add the almond milk, maple syrup, cinnamon, vanilla bean, flax, and sea salt, and process till the mixture has a smooth consistency (but with some texture remaining).", false, 19 },
                    { 91, 0, "Place your buns down on the pan and lightly toast to warm through (30 seconds-1 minute). Place your burgers on the buns, top with the onions and pickle chips, and enjoy!", false, 18 },
                    { 135, 0, "In the meantime, heat a sauté pan (preferably ovenproof) on high. Pat the chicken dry using a clean paper towel, then season with salt and pepper on both sides. Add 2 tablespoons of olive oil to the pan and, when smoking, add the chicken, skin side down. Leave on the heat for 30 seconds, then place the saute pan with the chicken in the oven with the broccoli. (If you don’t have an ovenproof pan, just place the chicken in a separate roasting dish.)", false, 30 },
                    { 106, 0, "Leave to cool and then place into a food processor with all ingredients except the juice", false, 23 },
                    { 48, 0, "Place the patties on the grill rack and cook, turning once, until they're cooked to your preference, 5 to 7 minutes on each side for medium. In the last 3 minutes of grilling, carefully place equal amounts of the barbecue cheese on each patty. During the last 2 minutes of grilling, place the buns cut side-down, on the outer edges of the rack to toast lightly.", false, 10 },
                    { 46, 0, "To make the patties, combine the beef, jalapeños, salt, pepper, and chili powder in a large bowl, handling it as little as possible. Shape into 6 patties to fit the bun size. Loosely cover with plastic wrap and set aside.", false, 10 },
                    { 150, 0, "Pour the mixture into a bowl and cover with plastic. Place in the fridge and let cool for at least one hour. When you are ready to make your ice cream, pour the mixture into the base of your ice cream maker and churn according to the manufacturer's directions.", false, 33 },
                    { 149, 0, "Add the Greek yogurt, rum, and almond extract, then process for another minute until everything is completely smooth and combined. There will still be little pieces of cherry skin in the mix, but that's okay.", false, 33 },
                    { 148, 0, "Remove the cherry mixture from the heat and discard the pits. Let the cherries cool to room temperature before pouring them into a food processor and processing until smooth.", false, 33 },
                    { 185, 0, "Top these two pieces with the other two slices of bread, placing them toasted side-down onto the cheese. Use a spatula to press down on the sandwiches, then cover the pan lightly and cook for 3 to 4 minutes.", false, 41 },
                    { 141, 0, "Preheat oven to 400˚ F. Spread about ¼ cup of the béchamel on the bottom of a baking pan. Cover with a layer of noodles. Spread some of the spinach mixture on top. Spread on a little more of the béchamel and arrange a few slices of fontina cheese on top. Continue making layers in this order until you have used all of the ingredients, ending with a layer of béchamel (you'll likely have some leftover noodles). Sprinkle the grated Parmigiano on top. Bake in the preheated oven until browned and crisp on top, about 20 minutes. Let the lasagna settle for a few minutes before serving.", false, 31 },
                    { 140, 0, "Prepare the béchamel: combine the remaining 3/4 cup flour with 1 1/2 cups of the milk and whisk until there are no lumps. (You can use the mini-chop attachment of an immersion blender to do this quickly and easily.) In a small pot, melt the remaining 7 tablespoons butter. Add the curry powder and a pinch of salt. Whisk in the milk and flour mixture, then add the remaining 2 1/2 cups milk in a thin stream, whisking constantly. Whisk over medium heat until thickened.", false, 31 },
                    { 139, 0, "Soak the raisins in warm water to soften, then drain. Blanch the spinach in lightly salted water, then drain and squeeze dry. Melt 1 tablespoon butter in a small pot and sauté the spinach, raisins, and pine nuts. Mince the spinach mixture and set aside. Thinly slice the fontina cheese.", false, 31 },
                    { 151, 0, "When the churning is complete, place the frozen yogurt into an air-tight container and let freeze for at least two hours before serving. Store in the same container for up to one week.", false, 33 },
                    { 138, 0, "Shape 5 1/4 cups flour into a well on your work surface. Add the eggs and a pinch of salt to the center of the well. With a fork, gently beat to break up the eggs. Begin pulling in flour from the sides of the well until you have a crumbly dough. Knead the dough until it is smooth and compact. Roll out into a very thin sheet and cut into large rectangular noodles. Bring a large pot of salted water to a boil and cook the pasta until it rises to the surface. Remove with a slotted spoon or skimmer and drain, then blot dry.", false, 31 },
                    { 132, 0, "Make the creamy avocado vinaigrette: In a food processor, blend together 1 avocado, 2 tablespoons olive oil, 2 teaspoons red wine vinegar, 1/2 teaspoon salt, 1 tablespoon lime juice, 1/4 cup warm water, and 2 tablespoons herbs until fully smooth. Taste and adjust seasoning with additional salt, pepper, and lime juice. Adjust consistency with additional warm water to thin, as needed—you should be able to drizzle (or squeeze bottle) the vinaigrette over the lettuce wraps, and have it hold its shape.", false, 29 },
                    { 131, 0, "Add the tomato puree and 1 tablespoon of vinegar, and stir, scraping up any browned bits from the bottom of the pan. Turn the heat down to medium-low and cover. Let simmer for about 25 minutes, or until you can easily shred the chicken with two forks. Adjust the seasoning to taste. Shred and let cool slightly. Meanwhile, as the chicken cooks, prepare the other components.", false, 29 },
                    { 130, 0, "Rub the chicken thighs all over with 2 teaspoons of salt. In a non-reactive Dutch oven over a medium flame, heat the olive oil. Add the chicken thighs and sear thoroughly on both sides to brown. Make a well in the center of the pan by pushing the chicken to the edges, and add the paprika and cayenne. Let the spices toast for 30 seconds, then add the onion and garlic pieces. Stir to distribute and sauté for a few minutes, until the onions begin to turn translucent.", false, 29 },
                    { 129, 0, "Fill a punch bowl and let everyone serve themselves, or pour egg nog into serving cups and sprinkle a generous amount of freshly grated nutmeg on top. Drink hot.", false, 28 },
                    { 128, 0, "In a saucepan, heat the milk, cream, and vanilla over medium heat. Do not boil. When small bubbles begin to appear, whisk the hot milk into the yolk mixture. Add the beaten whites and the cognac and stir until everything is incorporated.", false, 28 },
                    { 127, 0, "In a large mixing bowl, beat the egg yolks on high speed until thick and creamy. Add sugar and beat on high again until very light, about 3 to 5 minutes. Add salt and beat to combine. Set aside. In another large bowl, beat the egg whites to stiff peaks. Set aside.", false, 28 },
                    { 108, 0, "Cover with clingfilm and place into the freezer for two hours before transferring to the fridge", false, 23 },
                    { 133, 0, "To serve, assemble individual cups with the saucy, shredded chicken, avocado vinaigrette, and toppings, using the lettuce as shells.", false, 29 },
                    { 47, 0, "Prepare the barbecue cheese: Mix the barbecue sauce, cheese, and onions and set it aside. Do not refrigerate (you will be using it shortly and you don’t want it to be really cold).", false, 10 },
                    { 157, 0, "Preheat oven to 400 degrees and line a baking sheet with a baking mat.", false, 35 }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "DurationMin", "Instruction", "IsDone", "RecipeId" },
                values: new object[,]
                {
                    { 159, 0, "In a small saucepan, combine cherries, lemon juice, almond extract, sugar and water. Cook over medium heat, stirring frequently, until cherriess begin to break down and juices boil and thicken, about 5 minutes. Remove from heat, and transfer to a small bowl. Place bowl in a larger bowl of ice water, and stir mixture occasionally until cold.", false, 35 },
                    { 45, 0, "Heat your grill to medium-high. Brush the grill with oil to prevent sticking.", false, 10 },
                    { 37, 0, "bring a large pot of heavily salted water to a boil and cook the pasta until just al dente. Strain it and tip it into the bowl with the sauce. Fold everything together until it is well combined, the Brie has begun to melt, and the pasta is slicked with cheese and tomato goodness. Serve immediately with a big green salad", false, 8 },
                    { 36, 0, "Once the Brie is firm enough, cut it into 1/2-inch cubes and add these to the bowl. Gently fold to combine the cheese with the rest of the ingredients. Cover the bowl and let it sit at room temperature for at least 2 to 8 hours -- the longer the better", false, 8 },
                    { 35, 0, "Roughly chop the tomatoes and put them in a large serving bowl. Finely chop the garlic and add it to the bowl. Chiffonade or roughly chop the basil and add that to the bowl too. Pour in the olive oil and add a generous amount of salt and pepper. Gently stir everything together", false, 8 },
                    { 34, 0, "Put the Brie in the freezer for about 20 minutes to firm up a little. This will make it easier to cut when the time comes", false, 8 },
                    { 22, 0, "Add the roast vegetables, along with remaining 1 tbsp olive oil and a tiny bit of the cooking liquid, to the pasta. Toss in the basil and oregano, and serve, topped with toasted pine nuts if desired.", false, 5 },
                    { 21, 0, "Cook pasta till tender but slightly al dente. Drain and return to pot, reserving a small amount of the cooking liquid.", false, 5 },
                    { 158, 0, "In a small bowl, coat nuts with honey. Spread nuts on the baking mat. Bake 7 to 10 minutes, until golden. Transfer nuts to a bowl to cool. Coarsely chop, and set aside.", false, 35 },
                    { 20, 0, "If you’re using the pine nuts, now is the time to toast them gently in a large frying pan set over medium heat. Stir them continually, and remove them as soon as they’re becoming golden.", false, 5 },
                    { 18, 0, "Preheat oven to 450 degrees. Set a pot of boiled water on the stove to boil.", false, 5 },
                    { 190, 0, "To serve, scoop the tabouli onto a plate and add a tablespoon or so of plain yogurt. Sprinkle the yogurt with a tablespoon of the chopped walnuts and a pinch or two of za’atar. (I've also eaten it with a sprinkling of feta cheese, and it's really good!)", false, 42 },
                    { 189, 0, "Add salt and pepper to taste, and adjust the rest of the seasoning to your taste. You may need more oil and/or lemon juice, and you may want to stir in more za’atar.", false, 42 },
                    { 188, 0, "When the wheat has absorbed all the water and cooled to room temperature, stir in zest and juice of one lemon (you might add more later) and 2 tablespoons of walnut or olive oil. Add in chopped parsley, onions, and celery and stir well.", false, 42 },
                    { 187, 0, "In a large bowl, stir za’atar into bulgur wheat and pour boiling water over the mixture. Let sit until the water is completely absorbed, about 45 minutes. Meanwhile, zest and juice your lemon, chop your parsley, onions and celery, toast your walnuts.", false, 42 },
                    { 161, 0, "Divide among four dessert dishes, and spoon remaining cherries over tops. Garnish with the honey almonds.", false, 35 },
                    { 160, 0, "In a separate bowl, combine cream, brown sugar, and vanilla and beat until stiff peaks form, fold in 1/3 cup of the cherry sauce. Combine, but not fully -- there should be beautiful cherry streaks running through the fresh cream.", false, 35 },
                    { 19, 0, "Toss vegetables and garlic with olive oil and season well with salt and pepper. Keep the corn separate, however. Divide all vegetables save corn onto baking sheets and start roasting them for 35-40 minutes, or until they’re vegetables are becoming sweet, golden, and slightly caramelized (to get this effect, you’ll want to avoid tossing them around too much as they cook). Fifteen minutes before the end of the roasting process, add the corn, which cooks a little faster than the other vegetables!", false, 5 },
                    { 186, 0, "Remove the cover, flip the sandwiches, and cook for another 3 to 4 minutes, pressing down again with a spatula. Remove the sandwiches from the pan when the cheese is gooey and melted, then finish with the remaining sandwich ingredients (you can keep the sandwiches warm in a 250° F oven). Serve warm.", false, 41 }
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
