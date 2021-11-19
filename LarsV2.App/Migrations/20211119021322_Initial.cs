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
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LecturerSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerSubject_Lecturers_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerSubject_Subjects_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "CVPath", "Email", "FirstName", "ImagePath", "IsExternal", "Knowledge", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, "jan@eamv.dk", "Jan Pan", null, false, null, "Nees", "+4512345678" },
                    { 2, null, "jameshetfield@metallica.com", "James", null, false, null, "Hetfield", "+4569696969" },
                    { 3, null, "flemming@eamv.dk", "Flemming", null, false, null, "Efternavn", "+4511111111" },
                    { 4, null, "lindemann@eamv.dk", "Till", null, false, null, "Lindemann", "+4598765432" },
                    { 5, null, "bob@eamv.dk", "Bob", null, false, null, "Ross", "+4544444444" },
                    { 6, null, "putin@eamv.dk", "Vladimir", null, false, null, "Putin", "+4555555555" },
                    { 7, null, "trump@eamv.dk", "Donald", null, false, null, "Trump", "+4566666666" },
                    { 8, null, "joe@eamv.dk", "Joe", null, false, null, "Rogan", "+4577777777" },
                    { 9, null, "max@eamv.dk", "Max", null, false, null, "Verstappen", "+4588888888" },
                    { 10, null, "messi@eamv.dk", "Lionel", null, false, null, "Messi", "+4599999999" },
                    { 11, null, "ronaldo@eamv.dk", "Cristiano", null, false, null, "Ronaldo", "+4512121212" },
                    { 12, null, "maynard@eamv.dk", "Maynard James", null, false, null, "Keenan", "+4569696969" },
                    { 13, null, "steven@eamv.dk", "Steven", null, false, null, "Wilson", "+4512341234" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "Education", "Name" },
                values: new object[,]
                {
                    { 1, null, "Automation og drift", "Udvikling af automatiske styringer" },
                    { 2, null, "Automation og drift", "Styring og regulering" }
                });

            migrationBuilder.InsertData(
                table: "LecturerSubject",
                columns: new[] { "Id", "LecturerId", "SubjectId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "LecturerSubject",
                columns: new[] { "Id", "LecturerId", "SubjectId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_LecturerSubject_LecturerId",
                table: "LecturerSubject",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerSubject_SubjectId",
                table: "LecturerSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerSubject");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
