using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageSending.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedShippingRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date_of_dispatch",
                table: "shipping_requests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "shipping_requests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "shipping_requests",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_of_dispatch",
                table: "shipping_requests");

            migrationBuilder.DropColumn(
                name: "email",
                table: "shipping_requests");

            migrationBuilder.DropColumn(
                name: "name",
                table: "shipping_requests");
        }
    }
}
