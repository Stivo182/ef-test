using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_test.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignScenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignScenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignScenes_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SceneObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CampaignSceneId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceneObjects_CampaignScenes_CampaignSceneId",
                        column: x => x.CampaignSceneId,
                        principalTable: "CampaignScenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignScenes_CampaignId",
                table: "CampaignScenes",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneObjects_CampaignSceneId",
                table: "SceneObjects",
                column: "CampaignSceneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SceneObjects");

            migrationBuilder.DropTable(
                name: "CampaignScenes");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
