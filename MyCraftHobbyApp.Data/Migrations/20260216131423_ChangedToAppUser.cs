using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCraftHobbyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnitProjects_AspNetUsers_UserId",
                table: "KnitProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_KnitProjects_Types_ProjectTypeId",
                table: "KnitProjects");

            migrationBuilder.DropTable(
                name: "CrochetProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnitProjects",
                table: "KnitProjects");

            migrationBuilder.DropIndex(
                name: "IX_KnitProjects_UserId",
                table: "KnitProjects");

            migrationBuilder.DeleteData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KnitProjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KnitProjects",
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
                table: "Patterns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "KnitProjects");

            migrationBuilder.RenameTable(
                name: "KnitProjects",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_KnitProjects_ProjectTypeId",
                table: "Projects",
                newName: "IX_Projects_ProjectTypeId");

            migrationBuilder.AddColumn<string>(
                name: "ProjectKind",
                table: "Projects",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StitchPatternId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CraftProjectId = table.Column<int>(type: "int", nullable: false),
                    IsCreator = table.Column<bool>(type: "bit", nullable: false),
                    IsStarted = table.Column<bool>(type: "bit", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserId, x.CraftProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_CraftProjectId",
                        column: x => x.CraftProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StitchPatternId",
                table: "Projects",
                column: "StitchPatternId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_CraftProjectId",
                table: "UserProjects",
                column: "CraftProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Patterns_StitchPatternId",
                table: "Projects",
                column: "StitchPatternId",
                principalTable: "Patterns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Types_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Patterns_StitchPatternId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Types_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_StitchPatternId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectKind",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StitchPatternId",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "KnitProjects");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "KnitProjects",
                newName: "IX_KnitProjects_ProjectTypeId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "KnitProjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnitProjects",
                table: "KnitProjects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CrochetProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false),
                    StitchPatternId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrochetProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrochetProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrochetProjects_Patterns_StitchPatternId",
                        column: x => x.StitchPatternId,
                        principalTable: "Patterns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrochetProjects_Types_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "CrochetProjects",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "ProjectTypeId", "StitchPatternId", "UserId" },
                values: new object[,]
                {
                    { 1, "A classic granny square blanket created by crocheting individual, decorative square motifs in rounds, starting from the center and expanding outward with sets of 3-double crochet clusters (granny clusters). ", "https://www.anniedesigncrochet.com/wp-content/uploads/2024/02/rainbow-harmony-blanket-6-sq-768x768.jpg", "Granny Square Blanket", 5, 1, "91dd5e7d-d927-4ca6-8bd5-03ea2671362b" },
                    { 2, "Crochet a warm and comfortable ribbed beanie, ensuring a snug fit without extra fabric bunching.", "https://pukapuka.pl/wp-content/uploads/2023/02/img_20221019_110143476-01.jpeg", "Classic Crochet Beanie", 6, 2, "91dd5e7d-d927-4ca6-8bd5-03ea2671362b" },
                    { 3, "These Crochet Cotton Slipper Socks are easy to make with any cotton yarn. Make a pair and wear them in any season.", "https://www.lionbrand.com/cdn/shop/products/Crochet-Pattern-Cozy-Crochet-Socks-90528AD-a_800x.jpg?v=1745090141", "Cozy Crochet Socks", 4, 3, "91dd5e7d-d927-4ca6-8bd5-03ea2671362b" }
                });

            migrationBuilder.InsertData(
                table: "KnitProjects",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "ProjectTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, "This lovely scarf is a soft, insulated, and stylish accessory designed for maximum warmth against cold weather", "https://i.etsystatic.com/10585666/r/il/5a53bf/1215929775/il_570xN.1215929775_1lhw.jpg", "Cozy Winter Scarf", 2, "91dd5e7d-d927-4ca6-8bd5-03ea2671362b" },
                    { 2, "The Cable Knit Sweater is an elegant sweater worked from the top down in a simple cable pattern. It has wide raglan increases and edges in a double rib stitch that are integrated with the cables. This sweater is a great project for the knitter who would like to learn how to knit cables.", "https://fridayknits.com/cdn/shop/files/Chunkycableknit2.jpg?v=1717565368&width=1946", "Cable Knit Sweater", 1, "91dd5e7d-d927-4ca6-8bd5-03ea2671362b" },
                    { 3, "This colorful knit throw blanket features an easy, stunning stitch, along with gorgeous soft yarn to create an heirloom worthy project! And if you like solid color blankets, you can do that too.", "https://thrutheloopscreations.com/cdn/shop/files/StrawberrySundae3.heic?v=1719674594&width=1946", "Chunky Knit Throw Blanket", 5, "91dd5e7d-d927-4ca6-8bd5-03ea2671362b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnitProjects_UserId",
                table: "KnitProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CrochetProjects_ProjectTypeId",
                table: "CrochetProjects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CrochetProjects_StitchPatternId",
                table: "CrochetProjects",
                column: "StitchPatternId");

            migrationBuilder.CreateIndex(
                name: "IX_CrochetProjects_UserId",
                table: "CrochetProjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnitProjects_AspNetUsers_UserId",
                table: "KnitProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnitProjects_Types_ProjectTypeId",
                table: "KnitProjects",
                column: "ProjectTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
