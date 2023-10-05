using Microsoft.EntityFrameworkCore.Migrations;

namespace NGODonationDataAccessLayer.Migrations
{
    public partial class filedsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UsersTable");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UsersTable");
        }
    }
}
