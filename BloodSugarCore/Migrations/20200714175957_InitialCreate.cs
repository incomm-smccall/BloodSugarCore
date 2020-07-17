using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodSugarCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodReadings",
                columns: table => new
                {
                    ReadingID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReadingDate = table.Column<string>(nullable: true),
                    ReadingTime = table.Column<string>(nullable: true),
                    ReadingValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodReadings", x => x.ReadingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodReadings");
        }
    }
}
