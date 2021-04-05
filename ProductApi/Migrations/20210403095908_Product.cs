using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductApi.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "Black", "Pendrive", 50m, "pnBlack" },
                    { 2, "Blue", "Harddisk", 80m, "hdBlue" },
                    { 3, "Red", "Mouse", 30m, "pnRed" },
                    { 4, "green", "Ram", 40m, "rmGreen" },
                    { 5, "Black", "Keyboard", 10m, "blackKeyboard" },
                    { 6, "yellow", "Lancable", 70m, "lnYellow" },
                    { 7, "Black", "battery", 40m, "batteryBlack" },
                    { 8, "Black", "dockStation", 50m, "dockBlack" },
                    { 9, "Black", "Router", 20m, "RouterBlack" },
                    { 10, "Black", "Laptop Stand", 5m, "standBlack" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
