using Microsoft.EntityFrameworkCore.Migrations;

namespace NsSqliteServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lichtpunkt",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValueSql: "hex(randomblob(16))"),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Ort = table.Column<string>(nullable: true),
                    Straße = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lichtpunkt", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lichtpunkt");
        }
    }
}
