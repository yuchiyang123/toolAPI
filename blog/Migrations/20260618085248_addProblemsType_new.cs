using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class addProblemsType_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemParameters_ProblemSignatures_SignatureId",
                table: "ProblemParameters");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProblemSignatures_ProblemId",
                table: "ProblemSignatures");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSignatures_ProblemId",
                table: "ProblemSignatures",
                column: "ProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemParameters_ProblemSignatures_SignatureId",
                table: "ProblemParameters",
                column: "SignatureId",
                principalTable: "ProblemSignatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemParameters_ProblemSignatures_SignatureId",
                table: "ProblemParameters");

            migrationBuilder.DropIndex(
                name: "IX_ProblemSignatures_ProblemId",
                table: "ProblemSignatures");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProblemSignatures_ProblemId",
                table: "ProblemSignatures",
                column: "ProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemParameters_ProblemSignatures_SignatureId",
                table: "ProblemParameters",
                column: "SignatureId",
                principalTable: "ProblemSignatures",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
