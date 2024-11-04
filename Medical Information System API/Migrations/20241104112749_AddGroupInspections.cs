using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupInspections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "inspection",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "inspection");
        }
    }
}
