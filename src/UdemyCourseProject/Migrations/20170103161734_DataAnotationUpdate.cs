using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyCourseProject.Migrations
{
    public partial class DataAnotationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Individuals",
                table: "Individuals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organizations",
                column: "OrganizationId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Individuals",
                maxLength: 50,
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Individual",
                table: "Individuals",
                column: "IndividualId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hobby",
                maxLength: 50,
                nullable: false);

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "Individuals",
                newName: "Individual");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Individual",
                table: "Individual");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organization",
                column: "OrganizationId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Individual",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Individuals",
                table: "Individual",
                column: "IndividualId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hobby",
                nullable: true);

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "Individual",
                newName: "Individuals");
        }
    }
}
