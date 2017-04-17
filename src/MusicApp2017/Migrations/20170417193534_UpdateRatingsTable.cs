using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp2017.Migrations
{
    public partial class UpdateRatingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Album",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AlbumID",
                table: "Ratings",
                column: "AlbumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Albums_AlbumID",
                table: "Ratings",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Albums_AlbumID",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_AlbumID",
                table: "Ratings");

            migrationBuilder.AddColumn<string>(
                name: "Album",
                table: "Ratings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Ratings",
                nullable: true);
        }
    }
}
