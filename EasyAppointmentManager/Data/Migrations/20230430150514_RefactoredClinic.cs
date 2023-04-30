using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointmentManager.Data.Migrations
{
    public partial class RefactoredClinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Location_LocationID",
                table: "Clinic");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_LocationID",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Clinic");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Clinic");

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Clinic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_LocationID",
                table: "Clinic",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Location_LocationID",
                table: "Clinic",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationID");
        }
    }
}
