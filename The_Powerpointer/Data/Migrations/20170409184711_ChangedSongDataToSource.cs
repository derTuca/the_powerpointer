using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Powerpointer.Data.Migrations
{
    public partial class ChangedSongDataToSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Songs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Songs");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Songs",
                nullable: true);
        }
    }
}
