using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Powerpointer.Data.Migrations
{
    public partial class AddedDbSetsForJoinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPicture_AspNetUsers_ApplicationUserId",
                table: "UserPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPicture_Pictures_PictureId",
                table: "UserPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSong_AspNetUsers_ApplicationUserId",
                table: "UserSong");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSong_Songs_SongId",
                table: "UserSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSong",
                table: "UserSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPicture",
                table: "UserPicture");

            migrationBuilder.RenameTable(
                name: "UserSong",
                newName: "UserSongs");

            migrationBuilder.RenameTable(
                name: "UserPicture",
                newName: "UserPictures");

            migrationBuilder.RenameIndex(
                name: "IX_UserSong_SongId",
                table: "UserSongs",
                newName: "IX_UserSongs_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPicture_PictureId",
                table: "UserPictures",
                newName: "IX_UserPictures_PictureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSongs",
                table: "UserSongs",
                columns: new[] { "ApplicationUserId", "SongId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPictures",
                table: "UserPictures",
                columns: new[] { "ApplicationUserId", "PictureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPictures_AspNetUsers_ApplicationUserId",
                table: "UserPictures",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPictures_Pictures_PictureId",
                table: "UserPictures",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSongs_AspNetUsers_ApplicationUserId",
                table: "UserSongs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSongs_Songs_SongId",
                table: "UserSongs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPictures_AspNetUsers_ApplicationUserId",
                table: "UserPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPictures_Pictures_PictureId",
                table: "UserPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSongs_AspNetUsers_ApplicationUserId",
                table: "UserSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSongs_Songs_SongId",
                table: "UserSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSongs",
                table: "UserSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPictures",
                table: "UserPictures");

            migrationBuilder.RenameTable(
                name: "UserSongs",
                newName: "UserSong");

            migrationBuilder.RenameTable(
                name: "UserPictures",
                newName: "UserPicture");

            migrationBuilder.RenameIndex(
                name: "IX_UserSongs_SongId",
                table: "UserSong",
                newName: "IX_UserSong_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPictures_PictureId",
                table: "UserPicture",
                newName: "IX_UserPicture_PictureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSong",
                table: "UserSong",
                columns: new[] { "ApplicationUserId", "SongId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPicture",
                table: "UserPicture",
                columns: new[] { "ApplicationUserId", "PictureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPicture_AspNetUsers_ApplicationUserId",
                table: "UserPicture",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPicture_Pictures_PictureId",
                table: "UserPicture",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSong_AspNetUsers_ApplicationUserId",
                table: "UserSong",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSong_Songs_SongId",
                table: "UserSong",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
