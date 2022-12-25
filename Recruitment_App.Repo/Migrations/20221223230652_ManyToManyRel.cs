using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruitment_App.Repo.Migrations
{
    public partial class ManyToManyRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTitleSkill_JobTitles_JobTitlesId",
                table: "JobTitleSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTitleSkill_Skills_SkillsId",
                table: "JobTitleSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitleSkill",
                table: "JobTitleSkill");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "JobTitleSkill",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "JobTitlesId",
                table: "JobTitleSkill",
                newName: "JobTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTitleSkill_SkillsId",
                table: "JobTitleSkill",
                newName: "IX_JobTitleSkill_SkillId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "JobTitleSkill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitleSkill",
                table: "JobTitleSkill",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitleSkill_JobTitleId",
                table: "JobTitleSkill",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitleSkill_JobTitles_JobTitleId",
                table: "JobTitleSkill",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitleSkill_Skills_SkillId",
                table: "JobTitleSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTitleSkill_JobTitles_JobTitleId",
                table: "JobTitleSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTitleSkill_Skills_SkillId",
                table: "JobTitleSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitleSkill",
                table: "JobTitleSkill");

            migrationBuilder.DropIndex(
                name: "IX_JobTitleSkill_JobTitleId",
                table: "JobTitleSkill");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobTitleSkill");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "JobTitleSkill",
                newName: "SkillsId");

            migrationBuilder.RenameColumn(
                name: "JobTitleId",
                table: "JobTitleSkill",
                newName: "JobTitlesId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTitleSkill_SkillId",
                table: "JobTitleSkill",
                newName: "IX_JobTitleSkill_SkillsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitleSkill",
                table: "JobTitleSkill",
                columns: new[] { "JobTitlesId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitleSkill_JobTitles_JobTitlesId",
                table: "JobTitleSkill",
                column: "JobTitlesId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitleSkill_Skills_SkillsId",
                table: "JobTitleSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
