using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DVideo.Migrations
{
    public partial class AllowThumbnailNullValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Thumbnails_ThumbnailId",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbnailId",
                table: "Videos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Thumbnails_ThumbnailId",
                table: "Videos",
                column: "ThumbnailId",
                principalTable: "Thumbnails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Thumbnails_ThumbnailId",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbnailId",
                table: "Videos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Thumbnails_ThumbnailId",
                table: "Videos",
                column: "ThumbnailId",
                principalTable: "Thumbnails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
