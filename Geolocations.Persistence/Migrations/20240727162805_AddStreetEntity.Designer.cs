﻿// <auto-generated />
using System;
using Geolocations.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Geolocations.Persistence.Migrations
{
    [DbContext(typeof(GeolocationsDbContext))]
    [Migration("20240727162805_AddStreetEntity")]
    partial class AddStreetEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Geolocations.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uuid")
                        .HasColumnName("region_id");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_cities");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_cities_name");

                    b.HasIndex("RegionId")
                        .HasDatabaseName("ix_cities_region_id");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("capital");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid")
                        .HasColumnName("currency_id");

                    b.Property<string>("ISO2")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar")
                        .HasColumnName("iso2");

                    b.Property<string>("ISO3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar")
                        .HasColumnName("iso3");

                    b.Property<decimal>("ISONumber")
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("iso_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("PhoneCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("phone_code");

                    b.Property<string>("WebDomain")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("web_domain");

                    b.HasKey("Id")
                        .HasName("pk_countries");

                    b.HasIndex("CurrencyId")
                        .HasDatabaseName("ix_countries_currency_id");

                    b.HasIndex("Name", "ISO2", "ISO3", "ISONumber")
                        .IsUnique()
                        .HasDatabaseName("ix_countries_name_iso2_iso3_iso_number");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("full_name");

                    b.Property<string>("ISOCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar")
                        .HasColumnName("iso_code");

                    b.Property<decimal>("ISONumber")
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("iso_number");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("short_name");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar")
                        .HasColumnName("symbol");

                    b.HasKey("Id")
                        .HasName("pk_currencies");

                    b.HasIndex("ISOCode")
                        .IsUnique()
                        .HasDatabaseName("ix_currencies_iso_code");

                    b.HasIndex("ISONumber")
                        .IsUnique()
                        .HasDatabaseName("ix_currencies_iso_number");

                    b.ToTable("currencies", (string)null);
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_regions");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_regions_country_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_regions_name");

                    b.ToTable("regions", (string)null);
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Street", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid")
                        .HasColumnName("city_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_street");

                    b.HasIndex("CityId")
                        .HasDatabaseName("ix_street_city_id");

                    b.ToTable("street", (string)null);
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.City", b =>
                {
                    b.HasOne("Geolocations.Domain.Entities.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cities_regions_region_id");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Country", b =>
                {
                    b.HasOne("Geolocations.Domain.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_countries_currencies_currency_id");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Region", b =>
                {
                    b.HasOne("Geolocations.Domain.Entities.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_regions_countries_country_id");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Street", b =>
                {
                    b.HasOne("Geolocations.Domain.Entities.City", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_street_cities_city_id");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.City", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Country", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("Geolocations.Domain.Entities.Region", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
