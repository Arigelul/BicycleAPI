using Microsoft.EntityFrameworkCore.Migrations;

namespace BicycleAPI.Migrations
{
    public partial class fix_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycle_BicycleType_BicycleTypeId",
                table: "Bicycle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BicycleType",
                table: "BicycleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bicycle",
                table: "Bicycle");

            migrationBuilder.RenameTable(
                name: "BicycleType",
                newName: "BicycleTypes");

            migrationBuilder.RenameTable(
                name: "Bicycle",
                newName: "Bicycles");

            migrationBuilder.RenameIndex(
                name: "IX_Bicycle_BicycleTypeId",
                table: "Bicycles",
                newName: "IX_Bicycles_BicycleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BicycleTypes",
                table: "BicycleTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bicycles",
                table: "Bicycles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycles_BicycleTypes_BicycleTypeId",
                table: "Bicycles",
                column: "BicycleTypeId",
                principalTable: "BicycleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycles_BicycleTypes_BicycleTypeId",
                table: "Bicycles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BicycleTypes",
                table: "BicycleTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bicycles",
                table: "Bicycles");

            migrationBuilder.RenameTable(
                name: "BicycleTypes",
                newName: "BicycleType");

            migrationBuilder.RenameTable(
                name: "Bicycles",
                newName: "Bicycle");

            migrationBuilder.RenameIndex(
                name: "IX_Bicycles_BicycleTypeId",
                table: "Bicycle",
                newName: "IX_Bicycle_BicycleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BicycleType",
                table: "BicycleType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bicycle",
                table: "Bicycle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycle_BicycleType_BicycleTypeId",
                table: "Bicycle",
                column: "BicycleTypeId",
                principalTable: "BicycleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
