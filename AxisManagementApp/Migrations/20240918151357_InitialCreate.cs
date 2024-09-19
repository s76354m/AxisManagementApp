using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AxisManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CS_EXP_Competitor_Translation",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrenuusProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EI = table.Column<bool>(type: "bit", nullable: true),
                    CS = table.Column<bool>(type: "bit", nullable: true),
                    MR = table.Column<bool>(type: "bit", nullable: true),
                    DataLoadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditMSID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_Competitor_Translation", x => x.RecordID);
                });

            migrationBuilder.CreateTable(
                name: "CS_EXP_Project_Translation",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    BenchmarkFileID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProjectType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ProjectDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Analyst = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PM = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GoLiveDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MaxMileage = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NewMarket = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ProvRef = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DataLoadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditMSID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NDB_LOB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefreshInd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_Project_Translation", x => x.RecordID);
                });

            migrationBuilder.CreateTable(
                name: "CS_EXP_ProjectNotes",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLoadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrigNoteMSID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastEditMSID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_ProjectNotes", x => x.RecordID);
                });

            migrationBuilder.CreateTable(
                name: "CS_EXP_Sel_PLProducts",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NWNW_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NWPR_PFX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GRGR_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GRGR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastEditMSID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLoadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_Sel_PLProducts", x => x.RecordID);
                });

            migrationBuilder.CreateTable(
                name: "CS_EXP_YLine_Translation",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NDB_Yline_ProdCd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NDB_Yline_IPA = table.Column<int>(type: "int", nullable: true),
                    NDB_Yline_MktNum = table.Column<int>(type: "int", nullable: true),
                    DataLoadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditMSID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreAward = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_YLine_Translation", x => x.RecordID);
                });

            migrationBuilder.CreateTable(
                name: "CS_EXP_zTrxServiceArea",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportInclude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxMileage = table.Column<int>(type: "int", nullable: true),
                    DataLoadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_zTrxServiceArea", x => x.RecordID);
                });

            migrationBuilder.CreateTable(
                name: "CS_EXP_zTrxServiceArea_Stage",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportInclude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxMileage = table.Column<int>(type: "int", nullable: true),
                    DataLoadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CS_EXP_zTrxServiceArea_Stage", x => x.RecordID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CS_EXP_Competitor_Translation");

            migrationBuilder.DropTable(
                name: "CS_EXP_Project_Translation");

            migrationBuilder.DropTable(
                name: "CS_EXP_ProjectNotes");

            migrationBuilder.DropTable(
                name: "CS_EXP_Sel_PLProducts");

            migrationBuilder.DropTable(
                name: "CS_EXP_YLine_Translation");

            migrationBuilder.DropTable(
                name: "CS_EXP_zTrxServiceArea");

            migrationBuilder.DropTable(
                name: "CS_EXP_zTrxServiceArea_Stage");
        }
    }
}
