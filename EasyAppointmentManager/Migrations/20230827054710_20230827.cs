using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointmentManager.Migrations
{
    public partial class _20230827 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAppointment_CustomerId",
                table: "CustomerAppointment",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAppointment_Customer_CustomerId",
                table: "CustomerAppointment",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAppointment_Customer_CustomerId",
                table: "CustomerAppointment");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAppointment_CustomerId",
                table: "CustomerAppointment");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerAppointment");
        }
    }
}
