using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddUserProgramingTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProgramingTechnolgies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgramingTechnolgies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProgramingTechnolgies_ProgrammingLanguageTechnologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "ProgrammingLanguageTechnologies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProgramingTechnolgies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProgramingTechnolgies_TechnologyId",
                table: "UserProgramingTechnolgies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgramingTechnolgies_UserId",
                table: "UserProgramingTechnolgies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProgramingTechnolgies");
        }
    }
}
