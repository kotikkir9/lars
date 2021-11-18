using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CVPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExternal = table.Column<bool>(type: "bit", nullable: false),
                    Knowledge = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationId = table.Column<int>(type: "int", nullable: true),
                    LecturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "CVPath", "Email", "FirstName", "ImagePath", "IsExternal", "Knowledge", "LastName", "PhoneNumber" },
                values: new object[] { 1, null, "jan@eamv.dk", "Jan Pan", null, false, null, "Nees", "+4512345678" });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "CVPath", "Email", "FirstName", "ImagePath", "IsExternal", "Knowledge", "LastName", "PhoneNumber" },
                values: new object[] { 2, null, "jameshetfield@metallica.com", "James", null, false, null, "Hetfield", "+4569696969" });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "CVPath", "Email", "FirstName", "ImagePath", "IsExternal", "Knowledge", "LastName", "PhoneNumber" },
                values: new object[] { 3, null, "flemming@eamv.dk", "Flemming", null, false, null, "Efternavn", "+4511111111" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_EducationId",
                table: "Subjects",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LecturerId",
                table: "Subjects",
                column: "LecturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Lecturers");
        }
    }
}
