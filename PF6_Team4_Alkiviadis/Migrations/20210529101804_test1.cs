using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PF6_Team4_Alkiviadis.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectRewardPackages",
                columns: table => new
                {
                    ProjectRewardPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardPackageId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRewardPackages", x => x.ProjectRewardPackageId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "RewardPackages",
                columns: table => new
                {
                    RewardPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxAmountRoGetReward = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RewardDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardPackages", x => x.RewardPackageId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BackerRewardPackages",
                columns: table => new
                {
                    BackerRewardPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RewardPackageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerRewardPackages", x => x.BackerRewardPackageId);
                    table.ForeignKey(
                        name: "FK_BackerRewardPackages_RewardPackages_RewardPackageId",
                        column: x => x.RewardPackageId,
                        principalTable: "RewardPackages",
                        principalColumn: "RewardPackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackerRewardPackages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BackerUserProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    AmountDonated = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerUserProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackerUserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackerUserProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreatorUserProjects",
                columns: table => new
                {
                    CreatorUserProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatorUserProjects", x => x.CreatorUserProjectId);
                    table.ForeignKey(
                        name: "FK_CreatorUserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreatorUserProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackerRewardPackages_RewardPackageId",
                table: "BackerRewardPackages",
                column: "RewardPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_BackerRewardPackages_UserId",
                table: "BackerRewardPackages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BackerUserProjects_ProjectId",
                table: "BackerUserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BackerUserProjects_UserId",
                table: "BackerUserProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorUserProjects_ProjectId",
                table: "CreatorUserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorUserProjects_UserId",
                table: "CreatorUserProjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackerRewardPackages");

            migrationBuilder.DropTable(
                name: "BackerUserProjects");

            migrationBuilder.DropTable(
                name: "CreatorUserProjects");

            migrationBuilder.DropTable(
                name: "ProjectRewardPackages");

            migrationBuilder.DropTable(
                name: "RewardPackages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
