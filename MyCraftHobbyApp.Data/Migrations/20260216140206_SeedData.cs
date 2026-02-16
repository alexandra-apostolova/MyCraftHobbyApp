using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCraftHobbyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patterns",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Granny Square" },
                    { 2, "Shell" },
                    { 3, "Wave Stitch" },
                    { 4, "Alpine" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Difficulty", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Sweater" },
                    { 2, 0, "Scarf" },
                    { 3, 1, "Mittens" },
                    { 4, 1, "Socks" },
                    { 5, 2, "Blanket" },
                    { 6, 0, "Hat" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "ProjectKind", "ProjectTypeId" },
                values: new object[,]
                {
                    { 1, "This lovely scarf is a soft, insulated, and stylish accessory designed for maximum warmth against cold weather", "https://i.etsystatic.com/10585666/r/il/5a53bf/1215929775/il_570xN.1215929775_1lhw.jpg", "Cozy Winter Scarf", "Knit", 2 },
                    { 2, "The Cable Knit Sweater is an elegant sweater worked from the top down in a simple cable pattern. It has wide raglan increases and edges in a double rib stitch that are integrated with the cables. This sweater is a great project for the knitter who would like to learn how to knit cables.", "https://fridayknits.com/cdn/shop/files/Chunkycableknit2.jpg?v=1717565368&width=1946", "Cable Knit Sweater", "Knit", 1 },
                    { 3, "This colorful knit throw blanket features an easy, stunning stitch, along with gorgeous soft yarn to create an heirloom worthy project! And if you like solid color blankets, you can do that too.", "https://thrutheloopscreations.com/cdn/shop/files/StrawberrySundae3.heic?v=1719674594&width=1946", "Chunky Knit Throw Blanket", "Knit", 5 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "ProjectKind", "ProjectTypeId", "StitchPatternId" },
                values: new object[,]
                {
                    { 4, "A classic granny square blanket created by crocheting individual, decorative square motifs in rounds, starting from the center and expanding outward with sets of 3-double crochet clusters (granny clusters). ", "https://www.anniedesigncrochet.com/wp-content/uploads/2024/02/rainbow-harmony-blanket-6-sq-768x768.jpg", "Granny Square Blanket", "Crochet", 5, 1 },
                    { 5, "Crochet a warm and comfortable ribbed beanie, ensuring a snug fit without extra fabric bunching.", "https://pukapuka.pl/wp-content/uploads/2023/02/img_20221019_110143476-01.jpeg", "Classic Crochet Beanie", "Crochet", 6, 2 },
                    { 6, "These Crochet Cotton Slipper Socks are easy to make with any cotton yarn. Make a pair and wear them in any season.", "https://www.lionbrand.com/cdn/shop/products/Crochet-Pattern-Cozy-Crochet-Socks-90528AD-a_800x.jpg?v=1745090141", "Cozy Crochet Socks", "Crochet", 4, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patterns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patterns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patterns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patterns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
