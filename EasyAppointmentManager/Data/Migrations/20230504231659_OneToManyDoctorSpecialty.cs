using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointmentManager.Data.Migrations
{
    public partial class OneToManyDoctorSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Specialties",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ClinicId",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specialties",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor",
                column: "ClinicId");
        }
    }
}
