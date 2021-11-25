using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class UpdataPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "69696969");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhoneNumber",
                value: "11111111");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhoneNumber",
                value: "98765432");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhoneNumber",
                value: "44444444");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhoneNumber",
                value: "55555555");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhoneNumber",
                value: "66666666");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhoneNumber",
                value: "77777777");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhoneNumber",
                value: "88888888");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhoneNumber",
                value: "99999999");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 11,
                column: "PhoneNumber",
                value: "12121212");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 12,
                column: "PhoneNumber",
                value: "69696969");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 13,
                column: "PhoneNumber",
                value: "12341234");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "+4512345678");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "+4569696969");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhoneNumber",
                value: "+4511111111");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhoneNumber",
                value: "+4598765432");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhoneNumber",
                value: "+4544444444");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhoneNumber",
                value: "+4555555555");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhoneNumber",
                value: "+4566666666");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhoneNumber",
                value: "+4577777777");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhoneNumber",
                value: "+4588888888");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhoneNumber",
                value: "+4599999999");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 11,
                column: "PhoneNumber",
                value: "+4512121212");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 12,
                column: "PhoneNumber",
                value: "+4569696969");

            migrationBuilder.UpdateData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 13,
                column: "PhoneNumber",
                value: "+4512341234");
        }
    }
}
