using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    product_code = table.Column<string>(type: "NVARCHAR", maxLength: 45, nullable: false),
                    category = table.Column<string>(type: "NVARCHAR", maxLength: 45, nullable: false),
                    price = table.Column<double>(type: "FLOAT", precision: 2, nullable: false),
                    promocional_price = table.Column<double>(type: "FLOAT", precision: 2, nullable: false),
                    image = table.Column<string>(type: "TEXT", maxLength: 1200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
