using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecretSanta.Core.Migrations.MSSQL
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peeps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picking = table.Column<bool>(type: "bit", nullable: false),
                    picked = table.Column<bool>(type: "bit", nullable: false),
                    uniquePass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatNo = table.Column<bool>(type: "bit", nullable: false),
                    address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creepy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peeps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currentyear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "whopickedwho",
                columns: table => new
                {
                    Person1 = table.Column<int>(type: "int", nullable: false),
                    Person2 = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_whopickedwho", x => new { x.Person1, x.Person2 });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peeps");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "whopickedwho");
        }
    }
}
