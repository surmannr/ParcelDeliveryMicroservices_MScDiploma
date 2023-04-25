using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageSending.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CommonEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "shipping_requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "billings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "shipping_requests");

            migrationBuilder.DropColumn(
                name: "name",
                table: "billings");
        }
    }
}
