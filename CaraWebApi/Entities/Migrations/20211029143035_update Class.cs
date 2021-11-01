using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class updateClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "176cbe4f-d053-43a4-ac7b-22c500b06510");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c50ed71b-8a89-483a-a760-c8ea4e10641e");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68b2cf89-590d-4c74-8cf2-f42d010db77e", "fc9cf089-5467-445e-af46-2944a741ee65", "Manager", "MANAGER" },
                    { "6baaf171-f118-4d49-a702-f9664f098d59", "b9f0e879-8def-432a-8561-30685e3f6b3a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Kane", "Miller" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mohd Rosdi ", "Sulaiman" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Jana", "McLeaf" });

            migrationBuilder.UpdateData(
                table: "ScanDatas",
                keyColumn: "ScanId",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2021, 10, 29, 22, 30, 35, 315, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "ScanDatas",
                keyColumn: "ScanId",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2021, 10, 29, 22, 30, 35, 316, DateTimeKind.Local).AddTicks(1496));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68b2cf89-590d-4c74-8cf2-f42d010db77e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6baaf171-f118-4d49-a702-f9664f098d59");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "176cbe4f-d053-43a4-ac7b-22c500b06510", "5a01e4fc-471b-418f-99f6-f36adb89d6aa", "Manager", "MANAGER" },
                    { "c50ed71b-8a89-483a-a760-c8ea4e10641e", "5b5afc91-2f06-4ea3-958a-b9d76d773fe1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "Name",
                value: "Kane Miller");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "Name",
                value: "Mohd Rosdi Bin Sulaiman");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "Name",
                value: "Jana McLeaf");

            migrationBuilder.UpdateData(
                table: "ScanDatas",
                keyColumn: "ScanId",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2021, 10, 29, 17, 48, 37, 815, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "ScanDatas",
                keyColumn: "ScanId",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2021, 10, 29, 17, 48, 37, 815, DateTimeKind.Local).AddTicks(4343));
        }
    }
}
