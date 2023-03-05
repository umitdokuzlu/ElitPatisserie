using Microsoft.EntityFrameworkCore.Migrations;

namespace ElitPatisserie.Data.Migrations
{
    public partial class mig_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "Phone2");

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Phone2",
                table: "Contacts",
                newName: "Phone");
        }
    }
}
