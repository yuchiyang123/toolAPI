using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class update_recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    Complexity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDetail_RecipeDetail_RecipeDetailId",
                        column: x => x.RecipeDetailId,
                        principalTable: "RecipeDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientsGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientsDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Step = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDetailMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeDetailId = table.Column<int>(type: "int", nullable: false),
                    RecipeIngredientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetailMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDetailMapping_RecipeDetail_RecipeDetailId",
                        column: x => x.RecipeDetailId,
                        principalTable: "RecipeDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDetailMapping_RecipeIngredients_RecipeIngredientsId",
                        column: x => x.RecipeIngredientsId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeDetailMapping_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientsMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeIngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientsMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientsMapping_RecipeIngredients_RecipeIngredientsId",
                        column: x => x.RecipeIngredientsId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientsMapping_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientsDetailMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeIngredientId = table.Column<int>(type: "int", nullable: false),
                    RecipeIngredientDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientsDetailMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientsDetailMapping_RecipeIngredientsDetail_RecipeIngredientDetailId",
                        column: x => x.RecipeIngredientDetailId,
                        principalTable: "RecipeIngredientsDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientsDetailMapping_RecipeIngredients_RecipeIngredientId",
                        column: x => x.RecipeIngredientId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStepMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeStepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStepMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeStepMapping_RecipeStep_RecipeStepId",
                        column: x => x.RecipeStepId,
                        principalTable: "RecipeStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeStepMapping_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTagMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTagMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeTagMapping_RecipeTag_RecipeTagId",
                        column: x => x.RecipeTagId,
                        principalTable: "RecipeTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTagMapping_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetail_RecipeDetailId",
                table: "RecipeDetail",
                column: "RecipeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetailMapping_RecipeDetailId",
                table: "RecipeDetailMapping",
                column: "RecipeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetailMapping_RecipeId",
                table: "RecipeDetailMapping",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetailMapping_RecipeIngredientsId",
                table: "RecipeDetailMapping",
                column: "RecipeIngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientsDetailMapping_RecipeIngredientDetailId",
                table: "RecipeIngredientsDetailMapping",
                column: "RecipeIngredientDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientsDetailMapping_RecipeIngredientId",
                table: "RecipeIngredientsDetailMapping",
                column: "RecipeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientsMapping_RecipeId",
                table: "RecipeIngredientsMapping",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientsMapping_RecipeIngredientsId",
                table: "RecipeIngredientsMapping",
                column: "RecipeIngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStepMapping_RecipeId",
                table: "RecipeStepMapping",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStepMapping_RecipeStepId",
                table: "RecipeStepMapping",
                column: "RecipeStepId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTagMapping_RecipeId",
                table: "RecipeTagMapping",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTagMapping_RecipeTagId",
                table: "RecipeTagMapping",
                column: "RecipeTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeDetailMapping");

            migrationBuilder.DropTable(
                name: "RecipeIngredientsDetailMapping");

            migrationBuilder.DropTable(
                name: "RecipeIngredientsMapping");

            migrationBuilder.DropTable(
                name: "RecipeStepMapping");

            migrationBuilder.DropTable(
                name: "RecipeTagMapping");

            migrationBuilder.DropTable(
                name: "RecipeDetail");

            migrationBuilder.DropTable(
                name: "RecipeIngredientsDetail");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "RecipeTag");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
