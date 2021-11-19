using Microsoft.EntityFrameworkCore.Migrations;

namespace Pelikula.DAO.Migrations
{
    public partial class AddedAnketaOdgovor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnketaOdgovor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnketaId = table.Column<int>(nullable: false),
                    Odgovor = table.Column<string>(nullable: true),
                    RedniBroj = table.Column<int>(nullable: false),
                    UkupnoIzabrano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnketaOdgovor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnketaOdgovor_Anketa_AnketaId",
                        column: x => x.AnketaId,
                        principalTable: "Anketa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnketaOdgovor_AnketaId",
                table: "AnketaOdgovor",
                column: "AnketaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnketaOdgovor");
        }
    }
}
