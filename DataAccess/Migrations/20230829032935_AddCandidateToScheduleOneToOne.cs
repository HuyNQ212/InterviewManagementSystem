using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidateToScheduleOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CandidateId",
                table: "Schedules",
                column: "CandidateId",
                unique: true,
                filter: "[CandidateId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Candidates_CandidateId",
                table: "Schedules",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Candidates_CandidateId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CandidateId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Schedules");
        }
    }
}
