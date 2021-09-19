using Microsoft.EntityFrameworkCore.Migrations;

namespace ExportImportApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Countries",
                columns: table => new
                {
                    SysId = table.Column<long>(type: "bigint", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryNameBn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageBn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyBn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Countries", x => x.SysId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Countries");
        }
    }
}
