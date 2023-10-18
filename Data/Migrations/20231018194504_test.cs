using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipApp.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "CarModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "CarModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "CarModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentPageIndex",
                table: "CarModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageCount",
                table: "CarModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CarModelId",
                table: "CarModel",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_CarModel_CarModelId",
                table: "CarModel",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_CarModel_CarModelId",
                table: "CarModel");

            migrationBuilder.DropIndex(
                name: "IX_CarModel_CarModelId",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "CurrentPageIndex",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "PageCount",
                table: "CarModel");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "CarModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "CarModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
