using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Hotel.Migrations
{
    public partial class InitalCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetPicture",
                table: "Pet");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.AddColumn<string>(
                name: "PetPicture",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
