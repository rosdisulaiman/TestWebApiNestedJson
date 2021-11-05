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
                    ScanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    camid = table.Column<string>(type: "TEXT", nullable: true),
                    devid = table.Column<string>(type: "TEXT", nullable: true),
                    devmac = table.Column<string>(type: "TEXT", nullable: true),
                    devname = table.Column<string>(type: "TEXT", nullable: true),
                    devno = table.Column<string>(type: "TEXT", nullable: true),
                    @event = table.Column<string>(name: "event", type: "TEXT", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "TEXT", nullable: true),
                    time = table.Column<int>(type: "INTEGER", nullable: false),
                    timelocal = table.Column<int>(type: "INTEGER", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    LoggedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    address = table.Column<string>(type: "TEXT", nullable: true),
                    age = table.Column<int>(type: "INTEGER", nullable: false),
                    attrAge = table.Column<int>(type: "INTEGER", nullable: false),
                    attrBeauty = table.Column<int>(type: "INTEGER", nullable: false),
                    attrExpression = table.Column<string>(type: "TEXT", nullable: true),
                    attrEye = table.Column<string>(type: "TEXT", nullable: true),
                    attrGender = table.Column<string>(type: "TEXT", nullable: true),
                    attrGlass = table.Column<string>(type: "TEXT", nullable: true),
                    attrMouth = table.Column<string>(type: "TEXT", nullable: true),
                    attrMustache = table.Column<string>(type: "TEXT", nullable: true),
                    attrSkinColor = table.Column<string>(type: "TEXT", nullable: true),
                    attrSmile = table.Column<string>(type: "TEXT", nullable: true),
                    authType = table.Column<string>(type: "TEXT", nullable: true),
                    bgHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    bgWidth = table.Column<int>(type: "INTEGER", nullable: false),
                    blurProb = table.Column<float>(type: "REAL", nullable: false),
                    cap = table.Column<string>(type: "TEXT", nullable: true),
                    cardNum = table.Column<string>(type: "TEXT", nullable: true),
                    certificateNumber = table.Column<string>(type: "TEXT", nullable: true),
                    certificateType = table.Column<int>(type: "INTEGER", nullable: false),
                    commonUuid = table.Column<string>(type: "TEXT", nullable: true),
                    coordX0 = table.Column<int>(type: "INTEGER", nullable: false),
                    coordX1 = table.Column<int>(type: "INTEGER", nullable: false),
                    coordY0 = table.Column<int>(type: "INTEGER", nullable: false),
                    coordY1 = table.Column<int>(type: "INTEGER", nullable: false),
                    debugStage = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    ethic = table.Column<string>(type: "TEXT", nullable: true),
                    frameId = table.Column<int>(type: "INTEGER", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: true),
                    groupId = table.Column<string>(type: "TEXT", nullable: true),
                    headPitch = table.Column<float>(type: "REAL", nullable: false),
                    headRoll = table.Column<float>(type: "REAL", nullable: false),
                    headYaw = table.Column<float>(type: "REAL", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    imageX0 = table.Column<int>(type: "INTEGER", nullable: false),
                    imageX1 = table.Column<int>(type: "INTEGER", nullable: false),
                    imageY0 = table.Column<int>(type: "INTEGER", nullable: false),
                    imageY1 = table.Column<int>(type: "INTEGER", nullable: false),
                    irimg = table.Column<string>(type: "TEXT", nullable: true),
                    irimgX0 = table.Column<int>(type: "INTEGER", nullable: false),
                    irimgX1 = table.Column<int>(type: "INTEGER", nullable: false),
                    irimgY0 = table.Column<int>(type: "INTEGER", nullable: false),
                    irimgY1 = table.Column<int>(type: "INTEGER", nullable: false),
                    liveness = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    orgimg = table.Column<string>(type: "TEXT", nullable: true),
                    personId = table.Column<string>(type: "TEXT", nullable: true),
                    personUuid = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", nullable: true),
                    plateId = table.Column<string>(type: "TEXT", nullable: true),
                    respirator = table.Column<string>(type: "TEXT", nullable: true),
                    respiratorLevel = table.Column<string>(type: "TEXT", nullable: true),
                    score = table.Column<float>(type: "REAL", nullable: false),
                    similarity = table.Column<float>(type: "REAL", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: true),
                    Temperature = table.Column<float>(type: "REAL", nullable: false),
                    temperatureAlarm = table.Column<string>(type: "TEXT", nullable: true),
                    timestamp = table.Column<int>(type: "INTEGER", nullable: false),
                    trackId = table.Column<int>(type: "INTEGER", nullable: false),
                    userId = table.Column<string>(type: "TEXT", nullable: true),
                    ScanId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScanDataScanId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faces", x => x.FaceId);
                    table.ForeignKey(
                        name: "FK_Faces_ScanDatas_ScanDataScanId",
                        column: x => x.ScanDataScanId,
                        principalTable: "ScanDatas",
                        principalColumn: "ScanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faces_ScanDataScanId",
                table: "Faces",
                column: "ScanDataScanId");
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
