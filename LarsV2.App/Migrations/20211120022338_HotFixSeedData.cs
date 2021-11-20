using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class HotFixSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LecturerSubject",
                keyColumns: new[] { "LecturerId", "SubjectId" },
                keyValues: new object[] { 8, 23 });

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.InsertData(
                table: "LecturerSubject",
                columns: new[] { "LecturerId", "SubjectId" },
                values: new object[] { 8, 1 });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Education", "Title" },
                values: new object[] { "AU i Energiteknologi", "Energikonsulent 1" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "Energikonsulent opfølgning (IDV)");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "Varmepumpe (VE)");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Education", "Title" },
                values: new object[] { "El-installation", "OB1 Boliginstallationer og Teknisk beregning på kredsløb" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                column: "Title",
                value: "Ob2: Bygningsinstallationer og Teknisk dokumentation");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 18,
                column: "Title",
                value: "Ob3: Mindre industriinstallationer og Teknisk beregning på maskiner");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 19,
                column: "Title",
                value: "Ob4: Større industriinstallationer og elforsyningsanlæg");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 20,
                column: "Title",
                value: "Vf2: Bekendtgørelser og standarder");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 21,
                column: "Title",
                value: "Vf1: Kvalitet, sikkerhed og miljø");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 22,
                column: "Title",
                value: "Afgangsprojekt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LecturerSubject",
                keyColumns: new[] { "LecturerId", "SubjectId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Education", "Title" },
                values: new object[] { "Automation og drift", "Afgangsprojekt" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                column: "Title",
                value: "Energikonsulent 1");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "Energikonsulent opfølgning (IDV)");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Education", "Title" },
                values: new object[] { "AU i Energiteknologi", "Varmepumpe (VE)" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                column: "Title",
                value: "OB1 Boliginstallationer og Teknisk beregning på kredsløb");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 18,
                column: "Title",
                value: "Ob2: Bygningsinstallationer og Teknisk dokumentation");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 19,
                column: "Title",
                value: "Ob3: Mindre industriinstallationer og Teknisk beregning på maskiner");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 20,
                column: "Title",
                value: "Ob4: Større industriinstallationer og elforsyningsanlæg");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 21,
                column: "Title",
                value: "Vf2: Bekendtgørelser og standarder");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 22,
                column: "Title",
                value: "Vf1: Kvalitet, sikkerhed og miljø");

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "Education", "Title" },
                values: new object[] { 23, null, "El-installation", "Afgangsprojekt" });

            migrationBuilder.InsertData(
                table: "LecturerSubject",
                columns: new[] { "LecturerId", "SubjectId" },
                values: new object[] { 8, 23 });
        }
    }
}
