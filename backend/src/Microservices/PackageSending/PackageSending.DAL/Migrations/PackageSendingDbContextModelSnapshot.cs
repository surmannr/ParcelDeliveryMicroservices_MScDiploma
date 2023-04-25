﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PackageSending.DAL;

#nullable disable

namespace PackageSending.DAL.Migrations
{
    [DbContext(typeof(PackageSendingDbContext))]
    partial class PackageSendingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Common.Entity.Billing", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer")
                        .HasColumnName("currency_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double precision")
                        .HasColumnName("total_amount");

                    b.Property<double>("TotalDistance")
                        .HasColumnType("double precision")
                        .HasColumnName("total_distance");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_billings");

                    b.HasIndex("CurrencyId")
                        .HasDatabaseName("ix_billings_currency_id");

                    b.ToTable("billings", (string)null);
                });

            modelBuilder.Entity("Common.Entity.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_currencies");

                    b.ToTable("currencies", (string)null);
                });

            modelBuilder.Entity("Common.Entity.Package", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<bool>("IsFragile")
                        .HasColumnType("boolean")
                        .HasColumnName("is_fragile");

                    b.Property<string>("ShippingRequestId")
                        .HasColumnType("text")
                        .HasColumnName("shipping_request_id");

                    b.Property<double>("SizeX")
                        .HasColumnType("double precision")
                        .HasColumnName("size_x");

                    b.Property<double>("SizeY")
                        .HasColumnType("double precision")
                        .HasColumnName("size_y");

                    b.Property<double>("SizeZ")
                        .HasColumnType("double precision")
                        .HasColumnName("size_z");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_packages");

                    b.HasIndex("ShippingRequestId")
                        .HasDatabaseName("ix_packages_shipping_request_id");

                    b.ToTable("packages", (string)null);
                });

            modelBuilder.Entity("Common.Entity.PaymentOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_payment_options");

                    b.ToTable("payment_options", (string)null);
                });

            modelBuilder.Entity("Common.Entity.ShippingOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_shipping_options");

                    b.ToTable("shipping_options", (string)null);
                });

            modelBuilder.Entity("Common.Entity.ShippingRequest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("BillingId")
                        .HasColumnType("text")
                        .HasColumnName("billing_id");

                    b.Property<string>("CourierId")
                        .HasColumnType("text")
                        .HasColumnName("courier_id");

                    b.Property<bool>("IsExpress")
                        .HasColumnType("boolean")
                        .HasColumnName("is_express");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean")
                        .HasColumnName("is_finished");

                    b.Property<int>("PaymentOptionId")
                        .HasColumnType("integer")
                        .HasColumnName("payment_option_id");

                    b.Property<int>("ShippingOptionId")
                        .HasColumnType("integer")
                        .HasColumnName("shipping_option_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_shipping_requests");

                    b.HasIndex("BillingId")
                        .IsUnique()
                        .HasDatabaseName("ix_shipping_requests_billing_id");

                    b.HasIndex("PaymentOptionId")
                        .HasDatabaseName("ix_shipping_requests_payment_option_id");

                    b.HasIndex("ShippingOptionId")
                        .HasDatabaseName("ix_shipping_requests_shipping_option_id");

                    b.ToTable("shipping_requests", (string)null);
                });

            modelBuilder.Entity("Common.Entity.Billing", b =>
                {
                    b.HasOne("Common.Entity.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_billings_currencies_currency_id");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Common.Entity.Package", b =>
                {
                    b.HasOne("Common.Entity.ShippingRequest", "ShippingRequest")
                        .WithMany("Packages")
                        .HasForeignKey("ShippingRequestId")
                        .HasConstraintName("fk_packages_shipping_requests_shipping_request_id");

                    b.Navigation("ShippingRequest");
                });

            modelBuilder.Entity("Common.Entity.ShippingRequest", b =>
                {
                    b.HasOne("Common.Entity.Billing", "Billing")
                        .WithOne("ShippingRequest")
                        .HasForeignKey("Common.Entity.ShippingRequest", "BillingId")
                        .HasConstraintName("fk_shipping_requests_billings_billing_id");

                    b.HasOne("Common.Entity.PaymentOption", "PaymentOption")
                        .WithMany()
                        .HasForeignKey("PaymentOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipping_requests_payment_options_payment_option_id");

                    b.HasOne("Common.Entity.ShippingOption", "ShippingOption")
                        .WithMany()
                        .HasForeignKey("ShippingOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipping_requests_shipping_options_shipping_option_id");

                    b.OwnsOne("Common.Entity.Address", "AddressFrom", b1 =>
                        {
                            b1.Property<string>("ShippingRequestId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("address_from_city");

                            b1.Property<string>("Country")
                                .HasColumnType("text")
                                .HasColumnName("address_from_country");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("address_from_street");

                            b1.Property<int>("ZipCode")
                                .HasColumnType("integer")
                                .HasColumnName("address_from_zip_code");

                            b1.HasKey("ShippingRequestId");

                            b1.ToTable("shipping_requests");

                            b1.WithOwner()
                                .HasForeignKey("ShippingRequestId")
                                .HasConstraintName("fk_shipping_requests_shipping_requests_id");
                        });

                    b.OwnsOne("Common.Entity.Address", "AddressTo", b1 =>
                        {
                            b1.Property<string>("ShippingRequestId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("address_to_city");

                            b1.Property<string>("Country")
                                .HasColumnType("text")
                                .HasColumnName("address_to_country");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("address_to_street");

                            b1.Property<int>("ZipCode")
                                .HasColumnType("integer")
                                .HasColumnName("address_to_zip_code");

                            b1.HasKey("ShippingRequestId");

                            b1.ToTable("shipping_requests");

                            b1.WithOwner()
                                .HasForeignKey("ShippingRequestId")
                                .HasConstraintName("fk_shipping_requests_shipping_requests_id");
                        });

                    b.Navigation("AddressFrom");

                    b.Navigation("AddressTo");

                    b.Navigation("Billing");

                    b.Navigation("PaymentOption");

                    b.Navigation("ShippingOption");
                });

            modelBuilder.Entity("Common.Entity.Billing", b =>
                {
                    b.Navigation("ShippingRequest");
                });

            modelBuilder.Entity("Common.Entity.ShippingRequest", b =>
                {
                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}
