using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguageTechnology");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguageTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "ProgrammingLanguageTechnologies",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguageTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "ProgrammingLanguageTechnologies");

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguageTechnology",
                columns: table => new
                {
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguageTechnology_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
