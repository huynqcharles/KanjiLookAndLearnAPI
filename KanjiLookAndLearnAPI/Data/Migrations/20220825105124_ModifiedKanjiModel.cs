using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanjiLookAndLearnAPI.Data.Migrations
{
    public partial class ModifiedKanjiModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Maening",
                table: "Kanjis",
                newName: "Meaning");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Meaning",
                table: "Kanjis",
                newName: "Maening");
        }
    }
}
