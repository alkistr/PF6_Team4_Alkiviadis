using Microsoft.EntityFrameworkCore.Migrations;

namespace PF6_Team4_Core.Migrations
{
    public partial class test16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects");

            migrationBuilder.RenameTable(
                name: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                newName: "BackerUserProject");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BackerUserProject",
                newName: "BackerUserProjectId");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountDonated",
                table: "BackerUserProject",
                type: "decimal(20,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackerUserProject",
                table: "BackerUserProject",
                column: "BackerUserProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BackerUserProject",
                table: "BackerUserProject");

            migrationBuilder.RenameTable(
                name: "BackerUserProject",
                newName: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects");

            migrationBuilder.RenameColumn(
                name: "BackerUserProjectId",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountDonated",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                table: "PF6_Team4_Core.Interfaces.IApplicationDbContext.BackerUserProjects",
                column: "Id");
        }
    }
}
