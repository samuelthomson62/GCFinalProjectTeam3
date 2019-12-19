using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class ggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ascent",
                table: "Trails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConditionDetails",
                table: "Trails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionStatus",
                table: "Trails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Descent",
                table: "Trails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "High",
                table: "Trails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Trails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Trails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Trails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Low",
                table: "Trails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ascent",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "ConditionDetails",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "ConditionStatus",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Descent",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "High",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Low",
                table: "Trails");
        }
    }
}
