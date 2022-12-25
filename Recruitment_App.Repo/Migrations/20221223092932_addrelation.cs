using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruitment_App.Repo.Migrations
{
    public partial class addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "JobTitles");

            migrationBuilder.CreateTable(
                name: "ApplicantJobTitle",
                columns: table => new
                {
                    ApplicantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitlesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJobTitle", x => new { x.ApplicantsId, x.JobTitlesId });
                    table.ForeignKey(
                        name: "FK_ApplicantJobTitle_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantJobTitle_JobTitles_JobTitlesId",
                        column: x => x.JobTitlesId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobTitle_JobTitlesId",
                table: "ApplicantJobTitle",
                column: "JobTitlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJobTitle");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "JobTitles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
