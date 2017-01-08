using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyCourseProject.Migrations
{
    public partial class FixedHobbyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby");

            migrationBuilder.DropColumn(
                name: "HobbiesId",
                table: "Hobby");

            migrationBuilder.AddColumn<Guid>(
                name: "HobbyId",
                table: "Hobby",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby",
                column: "HobbyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby");

            migrationBuilder.DropColumn(
                name: "HobbyId",
                table: "Hobby");

            migrationBuilder.AddColumn<Guid>(
                name: "HobbiesId",
                table: "Hobby",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby",
                column: "HobbiesId");
        }
    }
}
