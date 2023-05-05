using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointmentManager.Migrations
{
    public partial class ChangedRelationshipTo_one_to_one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Doctor_DoctorId",
                table: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Specialty_DoctorId",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Specialty");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecialtyId",
                table: "Doctor",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Specialty_SpecialtyId",
                table: "Doctor",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Specialty_SpecialtyId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_SpecialtyId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Specialty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_DoctorId",
                table: "Specialty",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Doctor_DoctorId",
                table: "Specialty",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId");
        }
    }
}
