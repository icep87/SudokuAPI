using Microsoft.EntityFrameworkCore.Migrations;

namespace SudokuAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sudokus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Board = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sudokus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sudokus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Super Easy" },
                    { 2, "Easy" },
                    { 3, "Intermediate" },
                    { 4, "Hard" },
                    { 5, "Extreme" }
                });

            migrationBuilder.InsertData(
                table: "Sudokus",
                columns: new[] { "Id", "Board", "CategoryId", "Notes" },
                values: new object[,]
                {
                    { 1, "{BoardNumber:[[9, \"\", 4, 2, 8, 6, 1, 3, 5],[6, 2, 8, 3, 5, 1, 7, 4, 9],[3, 1, 5, 7, 9, 4, 6, 8, 2],[2, 5, 6, 9, 1, 8, 4, 7, 3],[4, 3, 9, 6, 7, 5, 2, 1, 8],[7, 8, 1, 4, 3, 2, 5, 9, 6],[5, 6, 7, 8, 4, 3, 9, 2, 1],[1, 4, 3, 5, 2, 9, 8, 6, 7],[8, 9, 2, 1, 6, 7, 3, 5, \"\"]]}", 1, null },
                    { 2, "{BoardNumber:[[5, 6, \"\", 1, \"\", 9, \"\", 7, 8],[4, \"\", \"\", 5, \"\", \"\", 3, \"\", 2],[2, 9, \"\", 3, \"\", \"\", \"\", 1, \"\"],[\"\", 4, 6, \"\", 8, 5, 9, 2, 3],[9, 5, 7, \"\", 3, \"\", \"\", 4, 1],[\"\", 3, \"\", 4, \"\", \"\", 7, \"\", \"\"],[\"\", 2, \"\", 8, 5, 7, \"\", \"\", \"\"],[\"\", \"\", \"\", \"\", 4, \"\", 6, \"\", \"\"],[3, \"\", 4, \"\", 1, \"\", 2, \"\", \"\"]]}", 2, null },
                    { 3, "{BoardNumber:[[1, 2, 3, \"\", \"\", \"\", \"\", 9, \"\"],[\"\", \"\", 7, 9, \"\", \"\", 4, \"\", 6],[\"\", 6, 4, \"\", 5, \"\", \"\", 7, \"\"],[7, \"\", 1, 8, \"\", \"\", 9, \"\", \"\"],[\"\", \"\", \"\", \"\", \"\", \"\", 6, 3, \"\"],[\"\", 8, \"\", \"\", 2, \"\", \"\", 4, \"\"],[5, \"\", \"\", 4, 6, 9, 3, \"\", \"\"],[4, \"\", \"\", \"\", 8, 7, \"\", 2, \"\"],[3, \"\", \"\", \"\", \"\", \"\", 7, 6, \"\"]]}", 3, null },
                    { 4, "{BoardNumber:[[\"\", 5, \"\", \"\", 1, \"\", \"\", \"\", 3],[\"\", 7, \"\", \"\", 2, \"\", 8, \"\", \"\"],[\"\", \"\", \"\", 9, 7, \"\", \"\", \"\", 4],[\"\", 2, \"\", \"\", \"\", \"\", 1, \"\", \"\"],[8, \"\", \"\", 4, \"\", \"\", 3, \"\", \"\"],[\"\", \"\", \"\", \"\", \"\", \"\", 5, \"\", \"\"],[\"\", \"\", \"\", \"\", 5, \"\", 4, 8, 6],[9, \"\", 3, \"\", \"\", \"\", 7, 1, \"\"],[4, \"\", \"\", 1, \"\", \"\", \"\", 3, \"\"]]}", 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sudokus_CategoryId",
                table: "Sudokus",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sudokus");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
