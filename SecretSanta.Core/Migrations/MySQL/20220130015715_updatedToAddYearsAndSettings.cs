using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Core.Migrations.MySQL
{
    public partial class updatedToAddYearsAndSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Peeps",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UniquePassword",
                table: "Peeps",
                newName: "uniquePass");

            migrationBuilder.RenameColumn(
                name: "ToPick",
                table: "Peeps",
                newName: "picking");

            migrationBuilder.RenameColumn(
                name: "PictureLocation",
                table: "Peeps",
                newName: "postcode");

            migrationBuilder.RenameColumn(
                name: "BeenPicked",
                table: "Peeps",
                newName: "picked");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "whopickedwho",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Peeps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address1",
                table: "Peeps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address2",
                table: "Peeps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address3",
                table: "Peeps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "consent",
                table: "Peeps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "creepy",
                table: "Peeps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra",
                table: "Peeps",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pic",
                table: "Peeps",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "whopickedwho");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Peeps");

            migrationBuilder.DropColumn(
                name: "address1",
                table: "Peeps");

            migrationBuilder.DropColumn(
                name: "address2",
                table: "Peeps");

            migrationBuilder.DropColumn(
                name: "address3",
                table: "Peeps");

            migrationBuilder.DropColumn(
                name: "consent",
                table: "Peeps");

            migrationBuilder.DropColumn(
                name: "creepy",
                table: "Peeps");

            migrationBuilder.DropColumn(
                name: "extra",
                table: "Peeps");

            migrationBuilder.DropColumn(
                name: "pic",
                table: "Peeps");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Peeps",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "uniquePass",
                table: "Peeps",
                newName: "UniquePassword");

            migrationBuilder.RenameColumn(
                name: "postcode",
                table: "Peeps",
                newName: "PictureLocation");

            migrationBuilder.RenameColumn(
                name: "picking",
                table: "Peeps",
                newName: "ToPick");

            migrationBuilder.RenameColumn(
                name: "picked",
                table: "Peeps",
                newName: "BeenPicked");
        }
    }
}
