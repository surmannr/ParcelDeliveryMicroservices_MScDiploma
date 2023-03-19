using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PackageSending.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shipping_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipping_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "billings",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    total_distance = table.Column<double>(type: "double precision", nullable: false),
                    total_amount = table.Column<double>(type: "double precision", nullable: false),
                    currency_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_billings", x => x.id);
                    table.ForeignKey(
                        name: "fk_billings_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipping_requests",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    courier_id = table.Column<string>(type: "text", nullable: true),
                    address_from_street = table.Column<string>(type: "text", nullable: true),
                    address_from_city = table.Column<string>(type: "text", nullable: true),
                    address_from_zip_code = table.Column<int>(type: "integer", nullable: true),
                    address_from_country = table.Column<string>(type: "text", nullable: true),
                    address_to_street = table.Column<string>(type: "text", nullable: true),
                    address_to_city = table.Column<string>(type: "text", nullable: true),
                    address_to_zip_code = table.Column<int>(type: "integer", nullable: true),
                    address_to_country = table.Column<string>(type: "text", nullable: true),
                    is_express = table.Column<bool>(type: "boolean", nullable: false),
                    shipping_option_id = table.Column<int>(type: "integer", nullable: false),
                    payment_option_id = table.Column<int>(type: "integer", nullable: false),
                    billing_id = table.Column<string>(type: "text", nullable: true),
                    is_finished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipping_requests", x => x.id);
                    table.ForeignKey(
                        name: "fk_shipping_requests_billings_billing_id",
                        column: x => x.billing_id,
                        principalTable: "billings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_shipping_requests_payment_options_payment_option_id",
                        column: x => x.payment_option_id,
                        principalTable: "payment_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shipping_requests_shipping_options_shipping_option_id",
                        column: x => x.shipping_option_id,
                        principalTable: "shipping_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    size_x = table.Column<double>(type: "double precision", nullable: false),
                    size_y = table.Column<double>(type: "double precision", nullable: false),
                    size_z = table.Column<double>(type: "double precision", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    is_fragile = table.Column<bool>(type: "boolean", nullable: false),
                    shipping_request_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_packages", x => x.id);
                    table.ForeignKey(
                        name: "fk_packages_shipping_requests_shipping_request_id",
                        column: x => x.shipping_request_id,
                        principalTable: "shipping_requests",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_billings_currency_id",
                table: "billings",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_packages_shipping_request_id",
                table: "packages",
                column: "shipping_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipping_requests_billing_id",
                table: "shipping_requests",
                column: "billing_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_shipping_requests_payment_option_id",
                table: "shipping_requests",
                column: "payment_option_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipping_requests_shipping_option_id",
                table: "shipping_requests",
                column: "shipping_option_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "shipping_requests");

            migrationBuilder.DropTable(
                name: "billings");

            migrationBuilder.DropTable(
                name: "payment_options");

            migrationBuilder.DropTable(
                name: "shipping_options");

            migrationBuilder.DropTable(
                name: "currencies");
        }
    }
}
