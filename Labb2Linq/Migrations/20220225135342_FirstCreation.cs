using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2Linq.Migrations
{
    public partial class FirstCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klasser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlassNamn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lärare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lärare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elever",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    KlasserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elever", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elever_Klasser_KlasserId",
                        column: x => x.KlasserId,
                        principalTable: "Klasser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursNamn = table.Column<string>(nullable: true),
                    LärarnaId = table.Column<int>(nullable: true),
                    KlasserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurser_Klasser_KlasserId",
                        column: x => x.KlasserId,
                        principalTable: "Klasser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kurser_Lärare_LärarnaId",
                        column: x => x.LärarnaId,
                        principalTable: "Lärare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elever_KlasserId",
                table: "Elever",
                column: "KlasserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_KlasserId",
                table: "Kurser",
                column: "KlasserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_LärarnaId",
                table: "Kurser",
                column: "LärarnaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elever");

            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Klasser");

            migrationBuilder.DropTable(
                name: "Lärare");
        }
    }
}
