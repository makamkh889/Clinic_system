using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_managment_System.Migrations
{
    /// <inheritdoc />
    public partial class editMedicin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "ScientificName",
                table: "Medicines",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Medicines",
                newName: "TradeName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Medicines",
                newName: "RegistrationNumber");

            migrationBuilder.RenameColumn(
                name: "CommercialName",
                table: "Medicines",
                newName: "PharmaceuticalForm");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Composition",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concentration",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicineCode",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicineType",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Composition",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Concentration",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineCode",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineType",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Medicines",
                newName: "ScientificName");

            migrationBuilder.RenameColumn(
                name: "TradeName",
                table: "Medicines",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "RegistrationNumber",
                table: "Medicines",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PharmaceuticalForm",
                table: "Medicines",
                newName: "CommercialName");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Medicines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
