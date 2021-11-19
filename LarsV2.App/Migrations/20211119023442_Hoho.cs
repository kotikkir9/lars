using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class Hoho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturerSubject",
                table: "LecturerSubject");

            migrationBuilder.DropIndex(
                name: "IX_LecturerSubject_LecturerId",
                table: "LecturerSubject");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LecturerSubject");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subjects",
                newName: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturerSubject",
                table: "LecturerSubject",
                columns: new[] { "LecturerId", "SubjectId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturerSubject",
                table: "LecturerSubject");

            migrationBuilder.DeleteData(
                table: "LecturerSubject",
                keyColumns: new[] { "LecturerId", "SubjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "LecturerSubject",
                keyColumns: new[] { "LecturerId", "SubjectId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Subjects",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LecturerSubject",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturerSubject",
                table: "LecturerSubject",
                column: "Id");

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
        }
    }
}
