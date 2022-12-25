using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruitment_App.Repo.Migrations
{
    public partial class ManyToManyRelApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJobTitle");

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitlesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_Applicants_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_JobTitles_JobTitlesId",
                        column: x => x.JobTitlesId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicantsId",
                table: "Application",
                column: "ApplicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobTitlesId",
                table: "Application",
                column: "JobTitlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

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
    }
}
