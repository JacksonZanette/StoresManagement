﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoresManagement.Infra;

#nullable disable

namespace StoresManagement.Infra.Migrations
{
    [DbContext(typeof(StoresManagementContext))]
    [Migration("20240503185900_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StoresManagement.Domain.Models.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("StoresManagement.Domain.Models.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Stores", (string)null);
                });

            modelBuilder.Entity("StoresManagement.Domain.Models.Entities.Store", b =>
                {
                    b.HasOne("StoresManagement.Domain.Models.Entities.Company", "Company")
                        .WithMany("Stores")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("StoresManagement.Domain.Models.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("StoreId")
                                .HasColumnType("uuid");

                            b1.Property<string>("CityName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("CityName");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Country");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("RegionName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("RegionName");

                            b1.Property<string>("StreetName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("StreetName");

                            b1.HasKey("StoreId");

                            b1.ToTable("Stores");

                            b1.WithOwner()
                                .HasForeignKey("StoreId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("StoresManagement.Domain.Models.Entities.Company", b =>
                {
                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
