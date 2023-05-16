﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniBusApi.Data.Data;

#nullable disable

namespace MiniBusApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230516063705_SeedMiniBusTable")]
    partial class SeedMiniBusTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniBusApi.Domain.Models.MiniBus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InsertionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserInsert")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserModifies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Minibuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Toyota",
                            Capacity = "3",
                            IdCompany = 1,
                            Tipo = "Van",
                            Year = 0
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Mazada",
                            Capacity = "6",
                            IdCompany = 1,
                            Tipo = "Car",
                            Year = 0
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Isuzu",
                            Capacity = "7",
                            IdCompany = 1,
                            Tipo = "Bus",
                            Year = 0
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Ford",
                            Capacity = "8",
                            IdCompany = 1,
                            Tipo = "Tri",
                            Year = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
