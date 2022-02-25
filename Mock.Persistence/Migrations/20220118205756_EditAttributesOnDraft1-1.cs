using Microsoft.EntityFrameworkCore.Migrations;

namespace Mock.Persistence.Migrations
{
    public partial class EditAttributesOnDraft11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventStatus",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventStatus",
                table: "Events");
        }
    }
}
