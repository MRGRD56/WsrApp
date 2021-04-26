using Microsoft.EntityFrameworkCore.Migrations;

namespace WsrApp.Context.Migrations
{
    public partial class AcceptedConsultationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUnaccepted",
                table: "Consultations",
                newName: "IsAccepted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "Consultations",
                newName: "IsUnaccepted");
        }
    }
}
