using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Powerpointer.Data.Migrations
{
    public partial class ChangedNewsColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "News",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageSource",
                table: "News",
                newName: "Headline");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "News",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Headline",
                table: "News",
                newName: "ImageSource");
        }
    }
}
