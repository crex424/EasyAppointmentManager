using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointmentManager.Migrations
{
    public partial class TestDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Doctor_DoctorId",
                table: "Service");

            migrationBuilder.DropTable(
                name: "ClinicDoctor");

            migrationBuilder.DropIndex(
                name: "IX_Service_DoctorId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Clinic_ClinicId",
                table: "Doctor",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Clinic_ClinicId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClinicDoctor",
                columns: table => new
                {
                    ClinicsClinicId = table.Column<int>(type: "int", nullable: false),
                    DoctorsDoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicDoctor", x => new { x.ClinicsClinicId, x.DoctorsDoctorId });
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Clinic_ClinicsClinicId",
                        column: x => x.ClinicsClinicId,
                        principalTable: "Clinic",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Doctor_DoctorsDoctorId",
                        column: x => x.DoctorsDoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_DoctorId",
                table: "Service",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctor_DoctorsDoctorId",
                table: "ClinicDoctor",
                column: "DoctorsDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Doctor_DoctorId",
                table: "Service",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId");
        }
    }
}
