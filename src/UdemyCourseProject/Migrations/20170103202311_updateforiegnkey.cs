using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyCourseProject.Migrations
{
    public partial class updateforiegnkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUsers",
                table: "Organization",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsers",
                table: "Individual",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsers",
                table: "Hobby",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessName",
                table: "Organization",
                maxLength: 50,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_AspNetUsers",
                table: "Organization",
                column: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_AspNetUsers",
                table: "Individual",
                column: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Hobby_AspNetUsers",
                table: "Hobby",
                column: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobby_AspNetUsers_AspNetUsers",
                table: "Hobby",
                column: "AspNetUsers",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_AspNetUsers_AspNetUsers",
                table: "Individual",
                column: "AspNetUsers",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_AspNetUsers_AspNetUsers",
                table: "Organization",
                column: "AspNetUsers",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobby_AspNetUsers_AspNetUsers",
                table: "Hobby");

            migrationBuilder.DropForeignKey(
                name: "FK_Individual_AspNetUsers_AspNetUsers",
                table: "Individual");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_AspNetUsers_AspNetUsers",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Organization_AspNetUsers",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Individual_AspNetUsers",
                table: "Individual");

            migrationBuilder.DropIndex(
                name: "IX_Hobby_AspNetUsers",
                table: "Hobby");

            migrationBuilder.DropColumn(
                name: "AspNetUsers",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "AspNetUsers",
                table: "Individual");

            migrationBuilder.DropColumn(
                name: "AspNetUsers",
                table: "Hobby");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessName",
                table: "Organization",
                nullable: true);
        }
    }
}
