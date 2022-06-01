using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmerPay.DataAccess.Migrations
{
    public partial class abdalahldl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "requests");
        }
    }
}
