using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68b2cf89-590d-4c74-8cf2-f42d010db77e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6baaf171-f118-4d49-a702-f9664f098d59");

            migrationBuilder.DeleteData(
                table: "Faces",
                keyColumn: "FaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faces",
                keyColumn: "FaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScanDatas",
                keyColumn: "ScanId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ScanDatas",
                keyColumn: "ScanId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "type",
                table: "ScanDatas",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "timelocal",
                table: "ScanDatas",
                newName: "Timelocal");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "ScanDatas",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "operator",
                table: "ScanDatas",
                newName: "Operator");

            migrationBuilder.RenameColumn(
                name: "event",
                table: "ScanDatas",
                newName: "Event");

            migrationBuilder.RenameColumn(
                name: "devno",
                table: "ScanDatas",
                newName: "Devno");

            migrationBuilder.RenameColumn(
                name: "devname",
                table: "ScanDatas",
                newName: "Devname");

            migrationBuilder.RenameColumn(
                name: "devmac",
                table: "ScanDatas",
                newName: "Devmac");

            migrationBuilder.RenameColumn(
                name: "devid",
                table: "ScanDatas",
                newName: "Devid");

            migrationBuilder.RenameColumn(
                name: "camid",
                table: "ScanDatas",
                newName: "Camid");

            migrationBuilder.RenameColumn(
                name: "PublishedDate",
                table: "ScanDatas",
                newName: "LoggedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Faces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8788d855-aa84-4902-a87c-ba01e634091d", "12bae227-624e-4f4c-95e9-279ea5bc93e0", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b20a1dbd-c2e3-496b-96b9-7582aeb13dd2", "ac06522d-d55b-4e9c-8a47-754fd3dc8b7f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8788d855-aa84-4902-a87c-ba01e634091d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b20a1dbd-c2e3-496b-96b9-7582aeb13dd2");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Faces");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ScanDatas",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Timelocal",
                table: "ScanDatas",
                newName: "timelocal");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "ScanDatas",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "Operator",
                table: "ScanDatas",
                newName: "operator");

            migrationBuilder.RenameColumn(
                name: "Event",
                table: "ScanDatas",
                newName: "event");

            migrationBuilder.RenameColumn(
                name: "Devno",
                table: "ScanDatas",
                newName: "devno");

            migrationBuilder.RenameColumn(
                name: "Devname",
                table: "ScanDatas",
                newName: "devname");

            migrationBuilder.RenameColumn(
                name: "Devmac",
                table: "ScanDatas",
                newName: "devmac");

            migrationBuilder.RenameColumn(
                name: "Devid",
                table: "ScanDatas",
                newName: "devid");

            migrationBuilder.RenameColumn(
                name: "Camid",
                table: "ScanDatas",
                newName: "camid");

            migrationBuilder.RenameColumn(
                name: "LoggedDate",
                table: "ScanDatas",
                newName: "PublishedDate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68b2cf89-590d-4c74-8cf2-f42d010db77e", "fc9cf089-5467-445e-af46-2944a741ee65", "Manager", "MANAGER" },
                    { "6baaf171-f118-4d49-a702-f9664f098d59", "b9f0e879-8def-432a-8561-30685e3f6b3a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "ScanDatas",
                columns: new[] { "ScanId", "camid", "devid", "devmac", "devname", "devno", "event", "operator", "PublishedDate", "time", "timelocal", "type" },
                values: new object[,]
                {
                    { 1, "Camera0", "FF008100", "", "Device IN", "", "common", "faceRegCaptureUpload", new DateTime(2021, 10, 29, 22, 30, 35, 315, DateTimeKind.Local).AddTicks(9303), 1635312120, 1635312105, null },
                    { 2, "Camera1", "101", "", "Device OUT", "", "common", "faceRegCaptureUpload", new DateTime(2021, 10, 29, 22, 30, 35, 316, DateTimeKind.Local).AddTicks(1496), 1635312120, 1635312105, null }
                });

            migrationBuilder.InsertData(
                table: "Faces",
                columns: new[] { "FaceId", "address", "age", "attrAge", "attrBeauty", "authType", "cardNum", "certificateNumber", "certificateType", "commonUuid", "email", "ethic", "FaceTemperature", "gender", "groupId", "image", "irimg", "name", "orgimg", "personId", "personUuid", "phone", "plateId", "QRcode", "ScanId", "similarity", "status", "temperatureAlarm", "timestamp", "trackId", "userId" },
                values: new object[] { 1, null, 0, 0, 0, null, null, null, 0, null, null, null, 36.692287445068359, null, null, null, null, "Mohd Rosdi", null, null, null, null, null, null, 1, 0.0, null, "Normal", 1635312105L, 0, "CCM025" });

            migrationBuilder.InsertData(
                table: "Faces",
                columns: new[] { "FaceId", "address", "age", "attrAge", "attrBeauty", "authType", "cardNum", "certificateNumber", "certificateType", "commonUuid", "email", "ethic", "FaceTemperature", "gender", "groupId", "image", "irimg", "name", "orgimg", "personId", "personUuid", "phone", "plateId", "QRcode", "ScanId", "similarity", "status", "temperatureAlarm", "timestamp", "trackId", "userId" },
                values: new object[] { 2, null, 0, 0, 0, null, null, null, 0, null, null, null, 36.692287445068359, null, null, null, null, "Siti Seha", null, null, null, null, null, null, 2, 0.0, null, "Normal", 1635312205L, 0, "CCM026" });
        }
    }
}
