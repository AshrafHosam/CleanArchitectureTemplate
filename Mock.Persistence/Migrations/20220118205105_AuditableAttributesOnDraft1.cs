using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mock.Persistence.Migrations
{
    public partial class AuditableAttributesOnDraft1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Interests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Interests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Interests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Interests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Interests");
        }
    }
}
