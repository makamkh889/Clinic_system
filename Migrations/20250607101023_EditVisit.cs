using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_managment_System.Migrations
{
    /// <inheritdoc />
    public partial class EditVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExamined",
                table: "Visits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExamined",
                table: "Visits");
        }
    }
}
