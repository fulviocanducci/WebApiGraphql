using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppiGraphql.Migrations
{
    public partial class Phones_Add_To_People : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "phones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    peopleid = table.Column<int>(nullable: false),
                    ddd = table.Column<string>(maxLength: 3, nullable: true),
                    number = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                    table.ForeignKey(
                        name: "FK_phones_peoples_peopleid",
                        column: x => x.peopleid,
                        principalTable: "peoples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phones_peopleid",
                table: "phones",
                column: "peopleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phones");
        }
    }
}
