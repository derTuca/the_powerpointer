using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Powerpointer.Data.Migrations
{
    public partial class AddedUserCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Pictures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Authors",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ApplicationUserId",
                table: "Songs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ApplicationUserId",
                table: "Pictures",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_ApplicationUserId",
                table: "News",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_ApplicationUserId",
                table: "News",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_AspNetUsers_ApplicationUserId",
                table: "Pictures",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_AspNetUsers_ApplicationUserId",
                table: "Songs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_ApplicationUserId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_ApplicationUserId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_AspNetUsers_ApplicationUserId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_AspNetUsers_ApplicationUserId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ApplicationUserId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_ApplicationUserId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_News_ApplicationUserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Authors_ApplicationUserId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");
        }
    }
}
