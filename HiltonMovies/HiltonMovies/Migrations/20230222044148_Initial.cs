using Microsoft.EntityFrameworkCore.Migrations;

namespace HiltonMovies.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_responses_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Comedy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Sports" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Comedy/Adventure" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Peter Farrelly", false, null, null, "PG-13", "Dumb and Dumber", 1994 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 2, "Boaz Yakin", false, null, null, "PG", "Remember the Titans", 2000 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 3, "Wes Anderson", false, null, null, "PG", "Fantastic Mr. Fox", 2009 });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryID",
                table: "responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
