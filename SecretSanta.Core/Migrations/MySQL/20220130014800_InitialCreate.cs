using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SecretSanta.Core.Migrations.MySQL
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UniquePassword = table.Column<string>(type: "text", nullable: true),
                    PictureLocation = table.Column<string>(type: "text", nullable: true),
                    ToPick = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BeenPicked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WhatNo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peeps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "whopickedwho",
                columns: table => new
                {
                    Person1 = table.Column<int>(type: "int", nullable: false),
                    Person2 = table.Column<int>(type: "int", nullable: false)
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
                name: "whopickedwho");
        }
    }
}
