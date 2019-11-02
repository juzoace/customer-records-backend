using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerCRUD.WebService.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsCustomerContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DateOfBirth", "FirstName", "HairColour", "Height", "LastName", "Weight" },
                values: new object[] { 1L, new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uncle", "Black", 1.8288m, "Bob", 50m });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DateOfBirth", "FirstName", "HairColour", "Height", "LastName", "Weight" },
                values: new object[] { 2L, new DateTime(1993, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Brown", 1.8288m, "Kirsten", 50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2L);
        }
    }
}
