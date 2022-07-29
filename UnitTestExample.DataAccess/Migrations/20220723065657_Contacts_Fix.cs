using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitTestExample.DataAccess.Migrations
{
    public partial class Contacts_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Disney" },
                    { 2, "HP" },
                    { 3, "Microsoft" },
                    { 4, "Google" },
                    { 5, "Facebook" },
                    { 6, "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Comments", "CompanyId", "Email", "JobTitle", "LastDateContacted", "Name", "Phone" },
                values: new object[] { 1, "112 Main St", "Lorem Ipsum is simply dummy text of the printing.", 1, "walter@disney.com", "Founder & CEO", new DateTime(2022, 7, 23, 1, 56, 57, 97, DateTimeKind.Local).AddTicks(1736), "Walter Disney", "444-444-5599" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Comments", "CompanyId", "Email", "JobTitle", "LastDateContacted", "Name", "Phone" },
                values: new object[] { 2, "7775 Main St", "Contrary to popular belief, Lorem Ipsum is not simply random text.", 2, "mary@smith.com", "VP Finance", new DateTime(2022, 7, 23, 1, 56, 57, 97, DateTimeKind.Local).AddTicks(1770), "Mary Smith", "433-544-5599" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
