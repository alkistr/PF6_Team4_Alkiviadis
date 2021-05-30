using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PF6_Team4_Core.Migrations
{
    public partial class alkis1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PF6_Team4_Core.Interfaces.IApplicationDbContext.ProjectRewardPackages",
                columns: table => new
                {
                    ProjectRewardPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardPackageId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF6_Team4_Core.Interfaces.IApplicationDbContext.ProjectRewardPackages", x => x.ProjectRewardPackageId);
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
                name: "RewardPackage",
                columns: table => new
                {
                    RewardPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxAmountRoGetReward = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    RewardDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RewardPackageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardPackage", x => x.RewardPackageId);
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
                name: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects",
                columns: table => new
                {
                    CreatorUserProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects", x => x.CreatorUserProjectId);
                    table.ForeignKey(
                        name: "FK_PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects_ProjectId",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects_UserId",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects_ProjectId",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects_UserId",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects");

            migrationBuilder.DropTable(
                name: "PF6_Team4_Core.Interfaces.IApplicationDbContext.CreatorUserProjects");

            migrationBuilder.DropTable(
                name: "PF6_Team4_Core.Interfaces.IApplicationDbContext.ProjectRewardPackages");

            migrationBuilder.DropTable(
                name: "RewardPackage");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
