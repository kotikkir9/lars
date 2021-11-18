using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class AddedMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "CVPath", "Email", "FirstName", "ImagePath", "IsExternal", "Knowledge", "LastName", "PhoneNumber" },
                values: new object[,]
                {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
