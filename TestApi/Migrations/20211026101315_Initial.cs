using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScanDatas",
                columns: table => new
                {
                    ScanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Camid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Devid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Devmac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Devname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Devno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Timelocal = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanDatas", x => x.ScanId);
                });

            migrationBuilder.CreateTable(
                name: "Faces",
                columns: table => new
                {
                    FaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QRcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AttrAge = table.Column<int>(type: "int", nullable: false),
                    AttrBeauty = table.Column<int>(type: "int", nullable: false),
                    AuthType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateType = table.Column<int>(type: "int", nullable: false),
                    CommonUuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ethic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Irimg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orgimg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonUuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Similarity = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceTemperature = table.Column<double>(type: "float", nullable: false),
                    TemperatureAlarm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScanId = table.Column<int>(type: "int", nullable: false),
                    ScanDatasScanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faces", x => x.FaceId);
                    table.ForeignKey(
                        name: "FK_Faces_ScanDatas_ScanDatasScanId",
                        column: x => x.ScanDatasScanId,
                        principalTable: "ScanDatas",
                        principalColumn: "ScanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faces_ScanDatasScanId",
                table: "Faces",
                column: "ScanDatasScanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faces");

            migrationBuilder.DropTable(
                name: "ScanDatas");
        }
    }
}
