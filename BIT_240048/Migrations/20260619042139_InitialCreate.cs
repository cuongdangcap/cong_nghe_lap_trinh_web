using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_240048.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishCategories_BIT240048",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories_BIT240048", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes_BIT240048",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreparationTime = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DishCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes_BIT240048", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_BIT240048_DishCategories_BIT240048_DishCategoryId",
                        column: x => x.DishCategoryId,
                        principalTable: "DishCategories_BIT240048",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishImages_BIT240048",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsThumbnail = table.Column<bool>(type: "bit", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishImages_BIT240048", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishImages_BIT240048_Dishes_BIT240048_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes_BIT240048",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_BIT240048_DishCategoryId",
                table: "Dishes_BIT240048",
                column: "DishCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DishImages_BIT240048_DishId",
                table: "DishImages_BIT240048",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishImages_BIT240048");

            migrationBuilder.DropTable(
                name: "Dishes_BIT240048");

            migrationBuilder.DropTable(
                name: "DishCategories_BIT240048");
        }
    }
}
