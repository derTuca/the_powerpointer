using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Powerpointer.Data.Migrations
{
    public partial class ChangedNewsImageToImageSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "News");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "News",
                nullable: true);
        }
    }
}
