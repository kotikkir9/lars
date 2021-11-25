using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsV2.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseDataTimeOffsets",
                columns: new[] { "CourseDateTime", "CourseId" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 });

            migrationBuilder.InsertData(
                table: "CourseDataTimeOffsets",
                columns: new[] { "CourseDateTime", "CourseId" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseDataTimeOffsets",
                keyColumns: new[] { "CourseDateTime", "CourseId" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 });

            migrationBuilder.DeleteData(
                table: "CourseDataTimeOffsets",
                keyColumns: new[] { "CourseDateTime", "CourseId" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2021, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), 1 });
        }
    }
}
