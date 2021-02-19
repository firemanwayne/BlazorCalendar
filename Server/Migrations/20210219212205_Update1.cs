using Microsoft.EntityFrameworkCore.Migrations;

namespace Calendar.Server.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedUserId",
                table: "Attendees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_AssignedUserId",
                table: "Attendees",
                column: "AssignedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_AspNetUsers_AssignedUserId",
                table: "Attendees",
                column: "AssignedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_AspNetUsers_AssignedUserId",
                table: "Attendees");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_AssignedUserId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                table: "Attendees");
        }
    }
}
