using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerSubject",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerSubject", x => new { x.LecturerId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_LecturerSubject_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDataTimeOffsets",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDataTimeOffsets", x => new { x.CourseId, x.CourseDateTime });
                    table.ForeignKey(
                        name: "FK_CourseDataTimeOffsets_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "CVPath", "Email", "FirstName", "ImagePath", "IsExternal", "Knowledge", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, "jan@eamv.dk", "Jan Pan", null, false, null, "Nees", "12345678" },
                    { 13, null, "steven@eamv.dk", "Steven", null, false, null, "Wilson", "12341234" },
                    { 11, null, "ronaldo@eamv.dk", "Cristiano", null, false, null, "Ronaldo", "12121212" },
                    { 10, null, "messi@eamv.dk", "Lionel", null, false, null, "Messi", "99999999" },
                    { 9, null, "max@eamv.dk", "Max", null, false, null, "Verstappen", "88888888" },
                    { 8, null, "joe@eamv.dk", "Joe", null, false, null, "Rogan", "77777777" },
                    { 12, null, "maynard@eamv.dk", "Maynard James", null, false, null, "Keenan", "69696969" },
                    { 6, null, "putin@eamv.dk", "Vladimir", null, false, null, "Putin", "55555555" },
                    { 5, null, "bob@eamv.dk", "Bob", null, false, null, "Ross", "44444444" },
                    { 4, null, "lindemann@eamv.dk", "Till", null, false, null, "Lindemann", "98765432" },
                    { 3, null, "flemming@eamv.dk", "Flemming", null, false, null, "Efternavn", "11111111" },
                    { 2, null, "jameshetfield@metallica.com", "James", null, false, null, "Hetfield", "69696969" },
                    { 7, null, "trump@eamv.dk", "Donald", null, false, null, "Trump", "66666666" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "Education", "Title" },
                values: new object[,]
                {
                    { 12, null, "AU i innovation, produkt og produktion", "Innovation i praksis" },
                    { 20, null, "El-installation", "Vf2: Bekendtgørelser og standarder" },
                    { 19, null, "El-installation", "Ob4: Større industriinstallationer og elforsyningsanlæg" },
                    { 18, null, "El-installation", "Ob3: Mindre industriinstallationer og Teknisk beregning på maskiner" },
                    { 17, null, "El-installation", "Ob2: Bygningsinstallationer og Teknisk dokumentation" },
                    { 16, null, "El-installation", "OB1 Boliginstallationer og Teknisk beregning på kredsløb" },
                    { 15, null, "AU i Energiteknologi", "Varmepumpe (VE)" },
                    { 14, null, "AU i Energiteknologi", "Energikonsulent opfølgning (IDV)" },
                    { 13, null, "AU i Energiteknologi", "Energikonsulent 1" },
                    { 11, null, "AU i innovation, produkt og produktion", "Produktionsiotimering" },
                    { 5, null, "Automation og drift", "Robot teknologi" },
                    { 9, null, "AU i innovation, produkt og produktion", "Værdikæden i praksis" },
                    { 8, null, "AU i innovation, produkt og produktion", "Projektledelse" },
                    { 7, null, "AU i innovation, produkt og produktion", "Styring og regulering" },
                    { 6, null, "Automation og drift", "Afgangsprojekt" },
                    { 21, null, "El-installation", "Vf1: Kvalitet, sikkerhed og miljø" },
                    { 4, null, "Automation og drift", "SCADA, netværk og databaser" },
                    { 3, null, "Automation og drift", "Maskinteknologi industri (industri)" },
                    { 2, null, "Automation og drift", "Styring og regulering" },
                    { 1, null, "Automation og drift", "Udvikling af automatiske styringer" },
                    { 10, null, "AU i innovation, produkt og produktion", "Kvalitetsoptimering med Six Sigma" },
                    { 22, null, "El-installation", "Afgangsprojekt" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "LecturerId", "SubjectId" },
                values: new object[] { 1, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "LecturerSubject",
                columns: new[] { "LecturerId", "SubjectId" },
                values: new object[,]
                {
                    { 10, 12 },
                    { 6, 13 },
                    { 11, 13 },
                    { 6, 14 },
                    { 6, 15 },
                    { 7, 15 },
                    { 6, 16 },
                    { 7, 16 },
                    { 7, 17 },
                    { 10, 17 },
                    { 7, 18 },
                    { 7, 19 },
                    { 12, 19 },
                    { 8, 20 },
                    { 10, 20 },
                    { 11, 20 },
                    { 8, 21 },
                    { 5, 12 },
                    { 8, 22 },
                    { 4, 11 },
                    { 3, 10 },
                    { 1, 1 },
                    { 8, 1 },
                    { 11, 1 },
                    { 1, 2 },
                    { 12, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 9, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 12, 7 },
                    { 3, 8 },
                    { 9, 8 },
                    { 11, 8 },
                    { 3, 9 },
                    { 4, 10 },
                    { 11, 22 }
                });

            migrationBuilder.InsertData(
                table: "CourseDataTimeOffsets",
                columns: new[] { "CourseDateTime", "CourseId" },
                values: new object[,]
                {
                    { new DateTimeOffset(new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 },
                    { new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 },
                    { new DateTimeOffset(new DateTime(2021, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 },
                    { new DateTimeOffset(new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubjectId",
                table: "Courses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerSubject_SubjectId",
                table: "LecturerSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDataTimeOffsets");

            migrationBuilder.DropTable(
                name: "LecturerSubject");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
