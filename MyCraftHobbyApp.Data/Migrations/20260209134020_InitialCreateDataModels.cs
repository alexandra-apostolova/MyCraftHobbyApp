using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCraftHobbyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDataModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patterns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patterns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrochetProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StitchPatternId = table.Column<int>(type: "int", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrochetProjects", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "KnitProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnitProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnitProjects_Types_ProjectTypeId",
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
                columns: new[] { "Id", "ImgUrl", "Name", "ProjectTypeId", "StitchPatternId" },
                values: new object[,]
                {
                    { 1, "https://www.anniedesigncrochet.com/wp-content/uploads/2024/02/rainbow-harmony-blanket-6-sq-768x768.jpg", "Granny Square Blanket", 5, 1 },
                    { 2, "https://pukapuka.pl/wp-content/uploads/2023/02/img_20221019_110143476-01.jpeg", "Classic Crochet Beanie", 6, 2 },
                    { 3, "https://www.lionbrand.com/cdn/shop/products/Crochet-Pattern-Cozy-Crochet-Socks-90528AD-a_800x.jpg?v=1745090141", "Cozy Crochet Socks", 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "KnitProjects",
                columns: new[] { "Id", "ImgUrl", "Name", "ProjectTypeId" },
                values: new object[,]
                {
                    { 1, "https://i.etsystatic.com/10585666/r/il/5a53bf/1215929775/il_570xN.1215929775_1lhw.jpg", "Cozy Winter Scarf", 2 },
                    { 2, "https://fridayknits.com/cdn/shop/files/Chunkycableknit2.jpg?v=1717565368&width=1946", "Cable Knit Sweater", 1 },
                    { 3, "https://thrutheloopscreations.com/cdn/shop/files/StrawberrySundae3.heic?v=1719674594&width=1946", "Chunky Knit Throw Blanket", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrochetProjects_ProjectTypeId",
                table: "CrochetProjects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CrochetProjects_StitchPatternId",
                table: "CrochetProjects",
                column: "StitchPatternId");

            migrationBuilder.CreateIndex(
                name: "IX_KnitProjects_ProjectTypeId",
                table: "KnitProjects",
                column: "ProjectTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrochetProjects");

            migrationBuilder.DropTable(
                name: "KnitProjects");

            migrationBuilder.DropTable(
                name: "Patterns");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
