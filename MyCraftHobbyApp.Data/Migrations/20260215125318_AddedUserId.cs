using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCraftHobbyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "KnitProjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CrochetProjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CrochetProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "91dd5e7d-d927-4ca6-8bd5-03ea2671362b");

            migrationBuilder.UpdateData(
                table: "CrochetProjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "91dd5e7d-d927-4ca6-8bd5-03ea2671362b");

            migrationBuilder.UpdateData(
                table: "CrochetProjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "91dd5e7d-d927-4ca6-8bd5-03ea2671362b");

            migrationBuilder.UpdateData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "91dd5e7d-d927-4ca6-8bd5-03ea2671362b");

            migrationBuilder.UpdateData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "91dd5e7d-d927-4ca6-8bd5-03ea2671362b");

            migrationBuilder.UpdateData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "91dd5e7d-d927-4ca6-8bd5-03ea2671362b");

            migrationBuilder.CreateIndex(
                name: "IX_KnitProjects_UserId",
                table: "KnitProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CrochetProjects_UserId",
                table: "CrochetProjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrochetProjects_AspNetUsers_UserId",
                table: "CrochetProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnitProjects_AspNetUsers_UserId",
                table: "KnitProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrochetProjects_AspNetUsers_UserId",
                table: "CrochetProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_KnitProjects_AspNetUsers_UserId",
                table: "KnitProjects");

            migrationBuilder.DropIndex(
                name: "IX_KnitProjects_UserId",
                table: "KnitProjects");

            migrationBuilder.DropIndex(
                name: "IX_CrochetProjects_UserId",
                table: "CrochetProjects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "KnitProjects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CrochetProjects");
        }
    }
}
