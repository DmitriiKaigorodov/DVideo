using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DVideo.Migrations
{
    public partial class AddFieldsToFilesTablesFixedTypos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbsolutePath",
                table: "VideoFiles");

            migrationBuilder.DropColumn(
                name: "AbsoluteUri",
                table: "VideoFiles");

            migrationBuilder.DropColumn(
                name: "AbsolutePath",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "AbsoluteUri",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "AbsolutePath",
                table: "Avatars");

            migrationBuilder.DropColumn(
                name: "AbsoluteUri",
                table: "Avatars");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "VideoFiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "VideoFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Thumbnails",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Thumbnails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Avatars",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Avatars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "VideoFiles");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "VideoFiles");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Avatars");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Avatars");

            migrationBuilder.AddColumn<string>(
                name: "AbsolutePath",
                table: "VideoFiles",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsoluteUri",
                table: "VideoFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbsolutePath",
                table: "Thumbnails",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsoluteUri",
                table: "Thumbnails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbsolutePath",
                table: "Avatars",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsoluteUri",
                table: "Avatars",
                nullable: true);
        }
    }
}
