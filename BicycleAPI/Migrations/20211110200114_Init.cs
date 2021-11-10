using Microsoft.EntityFrameworkCore.Migrations;

namespace BicycleAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BicycleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bicycle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BicycleTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bicycle_BicycleType_BicycleTypeId",
                        column: x => x.BicycleTypeId,
                        principalTable: "BicycleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BicycleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Road" });

            migrationBuilder.InsertData(
                table: "BicycleType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Mountain" });

            migrationBuilder.InsertData(
                table: "Bicycle",
                columns: new[] { "Id", "BicycleTypeId", "IsRented", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, false, "Bicycle1", 200m },
                    { 4, 1, true, "Bicycle4", 300m },
                    { 5, 1, false, "Bicycle5", 220m },
                    { 2, 2, false, "Bicycle2", 250m },
                    { 3, 2, true, "Bicycle3", 230m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_BicycleTypeId",
                table: "Bicycle",
                column: "BicycleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bicycle");

            migrationBuilder.DropTable(
                name: "BicycleType");
        }
    }
}
