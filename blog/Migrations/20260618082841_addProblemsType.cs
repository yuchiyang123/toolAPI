using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class addProblemsType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProblemSignatures_ProblemId",
                table: "ProblemSignatures"
            );

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProblemSignatures_ProblemId",
                table: "ProblemSignatures",
                column: "ProblemId"
            );

            migrationBuilder.CreateTable(
                name: "ProblemParameters",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignatureId = table.Column<int>(type: "int", nullable: false),
                    ParameterName = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    Type = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemParameters_ProblemSignatures_SignatureId",
                        column: x => x.SignatureId,
                        principalTable: "ProblemSignatures",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ProblemReturnTypes",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignatureId = table.Column<int>(type: "int", nullable: false),
                    ReturnName = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    ReturnType = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemReturnTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemReturnTypes_ProblemSignatures_SignatureId",
                        column: x => x.SignatureId,
                        principalTable: "ProblemSignatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProblemParameters_SignatureId",
                table: "ProblemParameters",
                column: "SignatureId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProblemReturnTypes_SignatureId",
                table: "ProblemReturnTypes",
                column: "SignatureId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ProblemParameters");

            migrationBuilder.DropTable(name: "ProblemReturnTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProblemSignatures_ProblemId",
                table: "ProblemSignatures"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSignatures_ProblemId",
                table: "ProblemSignatures",
                column: "ProblemId"
            );
        }
    }
}
