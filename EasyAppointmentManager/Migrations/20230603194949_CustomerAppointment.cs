using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointmentManager.Migrations
{
    public partial class CustomerAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAppointment",
                columns: table => new
                {
                    CustomerAppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    CustomerAppointmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAppointment", x => x.CustomerAppointmentId);
                    table.ForeignKey(
                        name: "FK_CustomerAppointment_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "TimeSlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAppointment_TimeSlotId",
                table: "CustomerAppointment",
                column: "TimeSlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAppointment");
        }
    }
}
