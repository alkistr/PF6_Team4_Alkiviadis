using Microsoft.EntityFrameworkCore.Migrations;

namespace PF6_Team4_Core.Migrations
{
    public partial class test30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RewardPackage_ProjectId",
                table: "RewardPackage",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardPackage_Project_ProjectId",
                table: "RewardPackage",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RewardPackage_Project_ProjectId",
                table: "RewardPackage");

            migrationBuilder.DropIndex(
                name: "IX_RewardPackage_ProjectId",
                table: "RewardPackage");
        }
    }
}
