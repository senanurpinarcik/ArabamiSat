using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabamiSatWeb.Migrations
{
    public partial class Ver_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "MarkaModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKullaniciId",
                table: "MarkaModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "MarkaModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKullaniciId",
                table: "MarkaModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SilenKullaniciId",
                table: "MarkaModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "MarkaModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Marka",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKullaniciId",
                table: "Marka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Marka",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKullaniciId",
                table: "Marka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SilenKullaniciId",
                table: "Marka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Marka",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Kullanici",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKullaniciId",
                table: "Kullanici",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Kullanici",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKullaniciId",
                table: "Kullanici",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SilenKullaniciId",
                table: "Kullanici",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Kullanici",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "ArabaYorum",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKullaniciId",
                table: "ArabaYorum",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "ArabaYorum",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKullaniciId",
                table: "ArabaYorum",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SilenKullaniciId",
                table: "ArabaYorum",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "ArabaYorum",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Araba",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKullaniciId",
                table: "Araba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Araba",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKullaniciId",
                table: "Araba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SilenKullaniciId",
                table: "Araba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Araba",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "MarkaModel");

            migrationBuilder.DropColumn(
                name: "EkleyenKullaniciId",
                table: "MarkaModel");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "MarkaModel");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullaniciId",
                table: "MarkaModel");

            migrationBuilder.DropColumn(
                name: "SilenKullaniciId",
                table: "MarkaModel");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "MarkaModel");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Marka");

            migrationBuilder.DropColumn(
                name: "EkleyenKullaniciId",
                table: "Marka");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Marka");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullaniciId",
                table: "Marka");

            migrationBuilder.DropColumn(
                name: "SilenKullaniciId",
                table: "Marka");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Marka");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "EkleyenKullaniciId",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullaniciId",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "SilenKullaniciId",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "ArabaYorum");

            migrationBuilder.DropColumn(
                name: "EkleyenKullaniciId",
                table: "ArabaYorum");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "ArabaYorum");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullaniciId",
                table: "ArabaYorum");

            migrationBuilder.DropColumn(
                name: "SilenKullaniciId",
                table: "ArabaYorum");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "ArabaYorum");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Araba");

            migrationBuilder.DropColumn(
                name: "EkleyenKullaniciId",
                table: "Araba");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Araba");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullaniciId",
                table: "Araba");

            migrationBuilder.DropColumn(
                name: "SilenKullaniciId",
                table: "Araba");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Araba");
        }
    }
}
