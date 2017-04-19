using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Powerpointer.Data.Migrations
{
    public partial class MovedToManyMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserNews",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    NewsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNews", x => new { x.ApplicationUserId, x.NewsId });
                    table.ForeignKey(
                        name: "FK_UserNews_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPicture",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    PictureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPicture", x => new { x.ApplicationUserId, x.PictureId });
                    table.ForeignKey(
                        name: "FK_UserPicture_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPicture_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSong",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    SongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSong", x => new { x.ApplicationUserId, x.SongId });
                    table.ForeignKey(
                        name: "FK_UserSong_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSong_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNews_NewsId",
                table: "UserNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPicture_PictureId",
                table: "UserPicture",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSong_SongId",
                table: "UserSong",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNews");

            migrationBuilder.DropTable(
                name: "UserPicture");

            migrationBuilder.DropTable(
                name: "UserSong");

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
    }
}
