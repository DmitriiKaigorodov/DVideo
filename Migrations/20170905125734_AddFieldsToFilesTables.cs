using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DVideo.Migrations
{
    public partial class AddFieldsToFilesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "VideoFiles");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Avatars");

            migrationBuilder.AddColumn<string>(
                name: "AbsolutePath",
                table: "VideoFiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsoluteUri",
                table: "VideoFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbsolutePath",
                table: "Thumbnails",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsoluteUri",
                table: "Thumbnails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbsolutePath",
                table: "Avatars",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsoluteUri",
                table: "Avatars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FileName",
                table: "VideoFiles",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Thumbnails",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Avatars",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
