using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppiGraphql.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "peoples",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    updated = table.Column<DateTime>(nullable: false),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "peoples");
        }
    }
}
