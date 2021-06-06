using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PF6_Team4_Core.Migrations
{
    public partial class test29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackerUserProject",
                columns: table => new
                {
                    BackerUserProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AmountDonated = table.Column<decimal>(type: "decimal(20,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerUserProject", x => x.BackerUserProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

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
                name: "RewardPackage",
                columns: table => new
                {
                    RewardPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxAmountRoGetReward = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    RewardDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RewardPackageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UsersLoggedIn",
                columns: table => new
                {
                    UserLoggedInId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLoggedIn", x => x.UserLoggedInId);
                });

            migrationBuilder.CreateTable(
                name: "UsersVM",
                columns: table => new
                {
                    UserVMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersVM", x => x.UserVMId);
                });

            migrationBuilder.CreateTable(
                name: "BackerUserProjectOptions",
                columns: table => new
                {
                    BackerUserProjectOptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AmountDonated = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    UserVMId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerUserProjectOptions", x => x.BackerUserProjectOptionsId);
                    table.ForeignKey(
                        name: "FK_BackerUserProjectOptions_UsersVM_UserVMId",
                        column: x => x.UserVMId,
                        principalTable: "UsersVM",
                        principalColumn: "UserVMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectOptions",
                columns: table => new
                {
                    ProjectOptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    category = table.Column<int>(type: "int", nullable: false),
                    UserVMId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectOptions", x => x.ProjectOptionsId);
                    table.ForeignKey(
                        name: "FK_ProjectOptions_UsersVM_UserVMId",
                        column: x => x.UserVMId,
                        principalTable: "UsersVM",
                        principalColumn: "UserVMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackerUserProjectOptions_UserVMId",
                table: "BackerUserProjectOptions",
                column: "UserVMId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectOptions_UserVMId",
                table: "ProjectOptions",
                column: "UserVMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackerUserProject");

            migrationBuilder.DropTable(
                name: "BackerUserProjectOptions");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectOptions");

            migrationBuilder.DropTable(
                name: "ProjectRewardPackages");

            migrationBuilder.DropTable(
                name: "RewardPackage");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersLoggedIn");

            migrationBuilder.DropTable(
                name: "UsersVM");
        }
    }
}
