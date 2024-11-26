using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.DAL.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "DateOfCreation", "Name" },
                values: new object[] { 1, "Code1", new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name1" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "DateOfCreation", "Name" },
                values: new object[] { 2, "Code2", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name2" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "DateOfCreation", "Name" },
                values: new object[] { 3, "Code3", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
