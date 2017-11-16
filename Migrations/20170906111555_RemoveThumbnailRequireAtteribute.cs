using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DVideo.Migrations
{
    public partial class RemoveThumbnailRequireAtteribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoFiles_FileId",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                table: "Videos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoFiles_FileId",
                table: "Videos",
                column: "FileId",
                principalTable: "VideoFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoFiles_FileId",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                table: "Videos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoFiles_FileId",
                table: "Videos",
                column: "FileId",
                principalTable: "VideoFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
