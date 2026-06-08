using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class flow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flows",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flows_Users_CreateUser",
                        column: x => x.CreateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_Flows_Users_UpdateUser",
                        column: x => x.UpdateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "FlowVersions",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowVersions_Flows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FlowVersions_Users_CreateUser",
                        column: x => x.CreateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_FlowVersions_Users_UpdateUser",
                        column: x => x.UpdateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "FlowNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowVersionId = table.Column<int>(type: "int", nullable: false),
                    StageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowNodes_FlowVersions_FlowVersionId",
                        column: x => x.FlowVersionId,
                        principalTable: "FlowVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FlowNodes_Users_CreateUser",
                        column: x => x.CreateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_FlowNodes_Users_UpdateUser",
                        column: x => x.UpdateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "FlowEdges",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowVersionId = table.Column<int>(type: "int", nullable: false),
                    SourceNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    FlowNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowEdges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowEdges_FlowNodes_FlowNodeId",
                        column: x => x.FlowNodeId,
                        principalTable: "FlowNodes",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_FlowEdges_FlowNodes_SourceNodeId",
                        column: x => x.SourceNodeId,
                        principalTable: "FlowNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_FlowEdges_FlowNodes_TargetNodeId",
                        column: x => x.TargetNodeId,
                        principalTable: "FlowNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_FlowEdges_FlowVersions_FlowVersionId",
                        column: x => x.FlowVersionId,
                        principalTable: "FlowVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FlowEdges_Users_CreateUser",
                        column: x => x.CreateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_FlowEdges_Users_UpdateUser",
                        column: x => x.UpdateUser,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "FlowRules",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowRules_FlowNodes_FlowNodeId",
                        column: x => x.FlowNodeId,
                        principalTable: "FlowNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowEdges_CreateUser",
                table: "FlowEdges",
                column: "CreateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowEdges_FlowNodeId",
                table: "FlowEdges",
                column: "FlowNodeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowEdges_FlowVersionId",
                table: "FlowEdges",
                column: "FlowVersionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowEdges_SourceNodeId",
                table: "FlowEdges",
                column: "SourceNodeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowEdges_TargetNodeId",
                table: "FlowEdges",
                column: "TargetNodeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowEdges_UpdateUser",
                table: "FlowEdges",
                column: "UpdateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowNodes_CreateUser",
                table: "FlowNodes",
                column: "CreateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowNodes_FlowVersionId",
                table: "FlowNodes",
                column: "FlowVersionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowNodes_UpdateUser",
                table: "FlowNodes",
                column: "UpdateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowRules_FlowNodeId",
                table: "FlowRules",
                column: "FlowNodeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Flows_CreateUser",
                table: "Flows",
                column: "CreateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Flows_UpdateUser",
                table: "Flows",
                column: "UpdateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowVersions_CreateUser",
                table: "FlowVersions",
                column: "CreateUser"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowVersions_FlowId",
                table: "FlowVersions",
                column: "FlowId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FlowVersions_UpdateUser",
                table: "FlowVersions",
                column: "UpdateUser"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "FlowEdges");

            migrationBuilder.DropTable(name: "FlowRules");

            migrationBuilder.DropTable(name: "FlowNodes");

            migrationBuilder.DropTable(name: "FlowVersions");

            migrationBuilder.DropTable(name: "Flows");
        }
    }
}
