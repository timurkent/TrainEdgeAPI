using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainEdgeAPI.Migrations
{
    public partial class thirdMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestColumn",
                table: "studentData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TestColumn",
                table: "studentData",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
