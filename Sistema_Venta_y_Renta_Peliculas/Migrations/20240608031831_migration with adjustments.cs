using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Venta_y_Renta_Peliculas.Migrations
{
    public partial class migrationwithadjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bills",
                type: "datetime2",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
