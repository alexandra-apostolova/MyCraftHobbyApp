using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCraftHobbyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "KnitProjects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CrochetProjects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CrochetProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A classic granny square blanket created by crocheting individual, decorative square motifs in rounds, starting from the center and expanding outward with sets of 3-double crochet clusters (granny clusters). ");

            migrationBuilder.UpdateData(
                table: "CrochetProjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Crochet a warm and comfortable ribbed beanie, ensuring a snug fit without extra fabric bunching.");

            migrationBuilder.UpdateData(
                table: "CrochetProjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "These Crochet Cotton Slipper Socks are easy to make with any cotton yarn. Make a pair and wear them in any season.");

            migrationBuilder.UpdateData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "This lovely scarf is a soft, insulated, and stylish accessory designed for maximum warmth against cold weather");

            migrationBuilder.UpdateData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "The Cable Knit Sweater is an elegant sweater worked from the top down in a simple cable pattern. It has wide raglan increases and edges in a double rib stitch that are integrated with the cables. This sweater is a great project for the knitter who would like to learn how to knit cables.");

            migrationBuilder.UpdateData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "This colorful knit throw blanket features an easy, stunning stitch, along with gorgeous soft yarn to create an heirloom worthy project! And if you like solid color blankets, you can do that too.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "KnitProjects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CrochetProjects");
        }
    }
}
