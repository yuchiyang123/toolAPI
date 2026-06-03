using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class ReplacePasswordWithHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeFileMapping_FileId",
                table: "RecipeFileMapping");

            migrationBuilder.DropIndex(
                name: "IX_RecipeFileMapping_RecipeId",
                table: "RecipeFileMapping");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFileMapping_FileId",
                table: "RecipeFileMapping",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFileMapping_RecipeId",
                table: "RecipeFileMapping",
                column: "RecipeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeFileMapping_FileId",
                table: "RecipeFileMapping");

            migrationBuilder.DropIndex(
                name: "IX_RecipeFileMapping_RecipeId",
                table: "RecipeFileMapping");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFileMapping_FileId",
                table: "RecipeFileMapping",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFileMapping_RecipeId",
                table: "RecipeFileMapping",
                column: "RecipeId");
        }
    }
}
