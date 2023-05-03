using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointmentManager.Data.Migrations
{
    public partial class SimplifiedClinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Clinic");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Doctor",
                newName: "DoctorId");

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

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSlotDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeSlotStatus = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.TimeSlotId);
                    table.ForeignKey(
                        name: "FK_TimeSlot_Doctor_DoctorId",
                        column: x => x.DoctorId,
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

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_DoctorId",
                table: "TimeSlot",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Doctor_DoctorId",
                table: "Service",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Doctor_DoctorId",
                table: "Service");

            migrationBuilder.DropTable(
                name: "ClinicDoctor");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_Service_DoctorId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Doctor",
                newName: "DoctorID");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clinic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clinic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Clinic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Clinic_ClinicId",
                table: "Doctor",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId");
        }
    }
}
