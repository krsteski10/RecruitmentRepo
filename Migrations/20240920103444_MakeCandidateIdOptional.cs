using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentAPI.Migrations
{
    public partial class MakeCandidateIdOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_Candidates_CandidateId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Candidates_CandidateId",
                table: "Skill");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Skill",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "InterviewFeedbacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_Candidates_CandidateId",
                table: "InterviewFeedbacks",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Candidates_CandidateId",
                table: "Skill",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedbacks_Candidates_CandidateId",
                table: "InterviewFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Candidates_CandidateId",
                table: "Skill");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Skill",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "InterviewFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedbacks_Candidates_CandidateId",
                table: "InterviewFeedbacks",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Candidates_CandidateId",
                table: "Skill",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
