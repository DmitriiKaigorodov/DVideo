using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DVideo.Migrations
{
    public partial class RenamedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatars_User_UserId",
                table: "Avatars");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVideo_Category_CategoryId",
                table: "CategoryVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVideo_Video_VideoId",
                table: "CategoryVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Video_VideoId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnails_Video_VideoId",
                table: "Thumbnails");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDislikedVideos_User_UserId",
                table: "UsersDislikedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDislikedVideos_Video_VideoId",
                table: "UsersDislikedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersLikedVideos_User_UserId",
                table: "UsersLikedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersLikedVideos_Video_VideoId",
                table: "UsersLikedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_User_AuthorId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_VideoFile_FileId",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoFile",
                table: "VideoFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersLikedVideos",
                table: "UsersLikedVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDislikedVideos",
                table: "UsersDislikedVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "VideoFile",
                newName: "VideoFiles");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "UsersLikedVideos",
                newName: "WatchedVideos");

            migrationBuilder.RenameTable(
                name: "UsersDislikedVideos",
                newName: "UploadedVideos");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Video_FileId",
                table: "Videos",
                newName: "IX_Videos_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Video_AuthorId",
                table: "Videos",
                newName: "IX_Videos_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersLikedVideos_VideoId",
                table: "WatchedVideos",
                newName: "IX_WatchedVideos_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersDislikedVideos_VideoId",
                table: "UploadedVideos",
                newName: "IX_UploadedVideos_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_VideoId",
                table: "Comments",
                newName: "IX_Comments_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentId",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoFiles",
                table: "VideoFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchedVideos",
                table: "WatchedVideos",
                columns: new[] { "UserId", "VideoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UploadedVideos",
                table: "UploadedVideos",
                columns: new[] { "UserId", "VideoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avatars_Users_UserId",
                table: "Avatars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVideo_Categories_CategoryId",
                table: "CategoryVideo",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVideo_Videos_VideoId",
                table: "CategoryVideo",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbnails_Videos_VideoId",
                table: "Thumbnails",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedVideos_Users_UserId",
                table: "UploadedVideos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedVideos_Videos_VideoId",
                table: "UploadedVideos",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Users_AuthorId",
                table: "Videos",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoFiles_FileId",
                table: "Videos",
                column: "FileId",
                principalTable: "VideoFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedVideos_Users_UserId",
                table: "WatchedVideos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedVideos_Videos_VideoId",
                table: "WatchedVideos",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatars_Users_UserId",
                table: "Avatars");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVideo_Categories_CategoryId",
                table: "CategoryVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVideo_Videos_VideoId",
                table: "CategoryVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Thumbnails_Videos_VideoId",
                table: "Thumbnails");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedVideos_Users_UserId",
                table: "UploadedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedVideos_Videos_VideoId",
                table: "UploadedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Users_AuthorId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoFiles_FileId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedVideos_Users_UserId",
                table: "WatchedVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedVideos_Videos_VideoId",
                table: "WatchedVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchedVideos",
                table: "WatchedVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoFiles",
                table: "VideoFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UploadedVideos",
                table: "UploadedVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "WatchedVideos",
                newName: "UsersLikedVideos");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Video");

            migrationBuilder.RenameTable(
                name: "VideoFiles",
                newName: "VideoFile");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UploadedVideos",
                newName: "UsersDislikedVideos");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_WatchedVideos_VideoId",
                table: "UsersLikedVideos",
                newName: "IX_UsersLikedVideos_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_FileId",
                table: "Video",
                newName: "IX_Video_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_AuthorId",
                table: "Video",
                newName: "IX_Video_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UploadedVideos_VideoId",
                table: "UsersDislikedVideos",
                newName: "IX_UsersDislikedVideos_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_VideoId",
                table: "Comment",
                newName: "IX_Comment_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                table: "Category",
                newName: "IX_Category_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersLikedVideos",
                table: "UsersLikedVideos",
                columns: new[] { "UserId", "VideoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoFile",
                table: "VideoFile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDislikedVideos",
                table: "UsersDislikedVideos",
                columns: new[] { "UserId", "VideoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avatars_User_UserId",
                table: "Avatars",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category",
                column: "ParentId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVideo_Category_CategoryId",
                table: "CategoryVideo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVideo_Video_VideoId",
                table: "CategoryVideo",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Video_VideoId",
                table: "Comment",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbnails_Video_VideoId",
                table: "Thumbnails",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDislikedVideos_User_UserId",
                table: "UsersDislikedVideos",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDislikedVideos_Video_VideoId",
                table: "UsersDislikedVideos",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersLikedVideos_User_UserId",
                table: "UsersLikedVideos",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersLikedVideos_Video_VideoId",
                table: "UsersLikedVideos",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_User_AuthorId",
                table: "Video",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_VideoFile_FileId",
                table: "Video",
                column: "FileId",
                principalTable: "VideoFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
