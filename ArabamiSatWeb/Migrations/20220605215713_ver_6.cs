using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabamiSatWeb.Migrations
{
    public partial class ver_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yas",
                table: "Kullanici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Yas",
                table: "Kullanici",
                type: "Nvarchar(4)",
                nullable: false,
                defaultValue: "");
        }
    }
}
