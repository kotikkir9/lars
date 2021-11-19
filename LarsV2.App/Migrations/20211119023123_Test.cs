using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturerSubject_Lecturers_SubjectId",
                table: "LecturerSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerSubject_Subjects_LecturerId",
                table: "LecturerSubject");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerSubject_Lecturers_LecturerId",
                table: "LecturerSubject",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerSubject_Subjects_SubjectId",
                table: "LecturerSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturerSubject_Lecturers_LecturerId",
                table: "LecturerSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerSubject_Subjects_SubjectId",
                table: "LecturerSubject");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerSubject_Lecturers_SubjectId",
                table: "LecturerSubject",
                column: "SubjectId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerSubject_Subjects_LecturerId",
                table: "LecturerSubject",
                column: "LecturerId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
