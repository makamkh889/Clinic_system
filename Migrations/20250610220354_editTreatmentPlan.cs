using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_managment_System.Migrations
{
    /// <inheritdoc />
    public partial class editTreatmentPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_FollowUps_FollowUpId",
                table: "TreatmentPlans");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentPlans_FollowUpId",
                table: "TreatmentPlans");

            migrationBuilder.DropColumn(
                name: "FollowUpId",
                table: "TreatmentPlans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FollowUpId",
                table: "TreatmentPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_FollowUpId",
                table: "TreatmentPlans",
                column: "FollowUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_FollowUps_FollowUpId",
                table: "TreatmentPlans",
                column: "FollowUpId",
                principalTable: "FollowUps",
                principalColumn: "Id");
        }
    }
}
