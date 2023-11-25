using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_TrutaDiana.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalValues",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Proteins = table.Column<int>(type: "int", nullable: false),
                    Carbohydrates = table.Column<int>(type: "int", nullable: false),
                    Fats = table.Column<int>(type: "int", nullable: false),
                    RecipeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalValues", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionalValuesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Portions = table.Column<int>(type: "int", nullable: false),
                    DifficultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipes_Difficulties_DifficultyID",
                        column: x => x.DifficultyID,
                        principalTable: "Difficulties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_NutritionalValues_NutritionalValuesID",
                        column: x => x.NutritionalValuesID,
                        principalTable: "NutritionalValues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    IsLiquid = table.Column<bool>(type: "bit", nullable: false),
                    RecipeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeID",
                table: "Ingredients",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DifficultyID",
                table: "Recipes",
                column: "DifficultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NutritionalValuesID",
                table: "Recipes",
                column: "NutritionalValuesID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "NutritionalValues");
        }
    }
}
