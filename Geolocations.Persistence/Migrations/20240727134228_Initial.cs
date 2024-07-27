using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geolocations.Persistence.Migrations
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
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    iso_code = table.Column<string>(type: "varchar", maxLength: 3, nullable: false),
                    iso_number = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    short_name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    full_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    symbol = table.Column<string>(type: "varchar", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    iso_number = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    iso2 = table.Column<string>(type: "varchar", maxLength: 3, nullable: false),
                    iso3 = table.Column<string>(type: "varchar", maxLength: 3, nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    capital = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    currency_id = table.Column<Guid>(type: "uuid", nullable: false),
                    web_domain = table.Column<string>(type: "varchar", maxLength: 10, nullable: false),
                    phone_code = table.Column<string>(type: "varchar", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                    table.ForeignKey(
                        name: "fk_countries_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    zip_code = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regions", x => x.id);
                    table.ForeignKey(
                        name: "fk_regions_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    zip_code = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    region_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                    table.ForeignKey(
                        name: "fk_cities_regions_region_id",
                        column: x => x.region_id,
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cities_name",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_cities_region_id",
                table: "cities",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "ix_countries_currency_id",
                table: "countries",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_countries_name_iso2_iso3_iso_number",
                table: "countries",
                columns: new[] { "name", "iso2", "iso3", "iso_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_currencies_iso_code",
                table: "currencies",
                column: "iso_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_currencies_iso_number",
                table: "currencies",
                column: "iso_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_regions_country_id",
                table: "regions",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_regions_name",
                table: "regions",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "regions");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "currencies");
        }
    }
}
