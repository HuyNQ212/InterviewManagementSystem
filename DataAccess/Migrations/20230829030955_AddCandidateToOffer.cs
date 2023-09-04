using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidateToOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CandidateId",
                table: "Offers",
                column: "CandidateId",
                unique: true,
                filter: "[CandidateId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Candidates_CandidateId",
                table: "Offers",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Candidates_CandidateId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CandidateId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Offers");
        }
    }
}
