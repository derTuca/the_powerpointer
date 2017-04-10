using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Powerpointer.Data.Migrations
{
    public partial class ChangedPictureImageToImageSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Pictures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Pictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Pictures",
                nullable: true);
        }
    }
}
