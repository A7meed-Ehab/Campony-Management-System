using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.DAL.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentId", "Email", "HireDate", "IsDeleted", "Name", "PhoneNumber", "Salary" },
                values: new object[] { 3, "123 Main Street", 1, "alice.johnson@example.com", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Alice Johnson", "01012345678", 50000.00m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentId", "Email", "HireDate", "IsDeleted", "Name", "PhoneNumber", "Salary" },
                values: new object[] { 2, "456 Elm Street", 2, "bob.smith@example.com", new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bob Smith", "01198765432", 45000.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
