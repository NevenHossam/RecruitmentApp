using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruitment_App.Repo.Migrations
{
    public partial class addisdeletedcoljobtitle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "JobTitles",
            type: "bit",
            nullable: false,
            defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobTitles");

        }
    }
}
