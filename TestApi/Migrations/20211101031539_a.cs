using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScanDatas",
                columns: table => new
                {
                    ScanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Camid = table.Column<string>(type: "TEXT", nullable: true),
                    Devid = table.Column<string>(type: "TEXT", nullable: true),
                    Devmac = table.Column<string>(type: "TEXT", nullable: true),
                    Devname = table.Column<string>(type: "TEXT", nullable: true),
                    Devno = table.Column<string>(type: "TEXT", nullable: true),
                    Event = table.Column<string>(type: "TEXT", nullable: true),
                    Operator = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<int>(type: "INTEGER", nullable: false),
                    Timelocal = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanDatas", x => x.ScanId);
                });

            migrationBuilder.CreateTable(
                name: "Faces",
                columns: table => new
                {
                    FaceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QRcode = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    AttrAge = table.Column<int>(type: "INTEGER", nullable: false),
                    AttrBeauty = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthType = table.Column<string>(type: "TEXT", nullable: true),
                    CardNum = table.Column<string>(type: "TEXT", nullable: true),
                    CertificateNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CertificateType = table.Column<int>(type: "INTEGER", nullable: false),
                    CommonUuid = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Ethic = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    GroupId = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Irimg = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Orgimg = table.Column<string>(type: "TEXT", nullable: true),
                    PersonId = table.Column<string>(type: "TEXT", nullable: true),
                    PersonUuid = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    PlateId = table.Column<string>(type: "TEXT", nullable: true),
                    Similarity = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    FaceTemperature = table.Column<double>(type: "REAL", nullable: false),
                    TemperatureAlarm = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<long>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ScanId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScanDatasScanId = table.Column<int>(type: "INTEGER", nullable: true)
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
