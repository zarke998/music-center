using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicCenter.EfDataAccess.Migrations
{
    public partial class AddDataColToUseCaseLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "UseCaseLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "UseCaseLogs");
        }
    }
}
