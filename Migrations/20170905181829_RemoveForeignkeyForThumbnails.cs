using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DVideo.Migrations
{
    public partial class RemoveForeignkeyForThumbnails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnails_Videos_VideoId",
                table: "Thumbnails");

            migrationBuilder.DropIndex(
                name: "IX_Thumbnails_VideoId",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Thumbnails");

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ThumbnailId",
                table: "Videos",
                column: "ThumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Thumbnails_ThumbnailId",
                table: "Videos",
                column: "ThumbnailId",
                principalTable: "Thumbnails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Thumbnails_ThumbnailId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ThumbnailId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Videos");

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Thumbnails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_VideoId",
                table: "Thumbnails",
                column: "VideoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbnails_Videos_VideoId",
                table: "Thumbnails",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
