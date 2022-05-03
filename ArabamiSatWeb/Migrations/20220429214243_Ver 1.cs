using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabamiSatWeb.Migrations
{
    public partial class Ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Araba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurumId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "Nvarchar(500)", nullable: false),
                    Fotograf = table.Column<string>(type: "Nvarchar(MAX)", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    Soyad = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    Eposta = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    Sifre = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    DogrulandiMi = table.Column<bool>(type: "bit", nullable: false),
                    YoneticiMi = table.Column<bool>(type: "bit", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArabaYorum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Yorum = table.Column<string>(type: "Nvarchar(500)", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArabaYorum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArabaYorum_Araba_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Araba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArabaYorum_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarkaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarkaModel_Marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArabaYorum_ArabaId",
                table: "ArabaYorum",
                column: "ArabaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArabaYorum_KullaniciId",
                table: "ArabaYorum",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkaModel_MarkaId",
                table: "MarkaModel",
                column: "MarkaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArabaYorum");

            migrationBuilder.DropTable(
                name: "MarkaModel");

            migrationBuilder.DropTable(
                name: "Araba");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Marka");
        }
    }
}
