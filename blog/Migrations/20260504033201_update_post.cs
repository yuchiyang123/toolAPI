using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class update_post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsTags_Posts_FK_PostsId",
                table: "PostsTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsTags",
                table: "PostsTags");

            migrationBuilder.DropIndex(
                name: "IX_PostsTags_FK_PostsId",
                table: "PostsTags");

            migrationBuilder.DropColumn(
                name: "FK_PostsId",
                table: "PostsTags");

            migrationBuilder.RenameTable(
                name: "PostsTags",
                newName: "PostsTag");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "PostsTag",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostsTag",
                table: "PostsTag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PostsTagsMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_PostsId = table.Column<int>(type: "int", nullable: false),
                    FK_TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTagsMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsTagsMapping_PostsTag_FK_TagId",
                        column: x => x.FK_TagId,
                        principalTable: "PostsTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsTagsMapping_Posts_FK_PostsId",
                        column: x => x.FK_PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostsTagsMapping_FK_PostsId",
                table: "PostsTagsMapping",
                column: "FK_PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTagsMapping_FK_TagId",
                table: "PostsTagsMapping",
                column: "FK_TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsTagsMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsTag",
                table: "PostsTag");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "PostsTag");

            migrationBuilder.RenameTable(
                name: "PostsTag",
                newName: "PostsTags");

            migrationBuilder.AddColumn<int>(
                name: "FK_PostsId",
                table: "PostsTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostsTags",
                table: "PostsTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_FK_PostsId",
                table: "PostsTags",
                column: "FK_PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsTags_Posts_FK_PostsId",
                table: "PostsTags",
                column: "FK_PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
