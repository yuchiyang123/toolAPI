using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class _8bit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sequencers",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bpm = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Name = table.Column<string>(
                        type: "nvarchar(20)",
                        maxLength: 20,
                        nullable: false
                    ),
                    UpdateDate = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: false,
                        defaultValueSql: "GETDATE()"
                    ),
                    UpdateUser = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: false,
                        defaultValueSql: "GETDATE()"
                    ),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequencers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sequencers_Users_CreateUser",
                        column: x => x.CreateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Sequencers_Users_UpdateUser",
                        column: x => x.UpdateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SequencerId = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    TrackSeq = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Sequencers_SequencerId",
                        column: x => x.SequencerId,
                        principalTable: "Sequencers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    StepSeq = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    IsOn = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Hz = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Sequencers_CreateUser",
                table: "Sequencers",
                column: "CreateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Sequencers_UpdateUser",
                table: "Sequencers",
                column: "UpdateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TrackId",
                table: "Steps",
                column: "TrackId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_SequencerId",
                table: "Tracks",
                column: "SequencerId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Steps");

            migrationBuilder.DropTable(name: "Tracks");

            migrationBuilder.DropTable(name: "Sequencers");
        }
    }
}
