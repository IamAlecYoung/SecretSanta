﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretSanta.Core.Domain.Contexts;

#nullable disable

namespace SecretSanta.Core.Migrations.MSSQL
{
    [DbContext(typeof(SantaContext))]
    [Migration("20221202190424_RenamedTablesForClarity")]
    partial class RenamedTablesForClarity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SecretSanta.Core.Domain.Peeps", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("BeenPicked")
                        .HasColumnType("bit");

                    b.Property<bool>("ToPick")
                        .HasColumnType("bit");

                    b.Property<bool>("WhatNo")
                        .HasColumnType("bit");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("consent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creepy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uniquePass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Peeps");
                });

            modelBuilder.Entity("SecretSanta.Core.Domain.settings", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("admin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currentyear")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("SecretSanta.Core.Domain.whopickedwho", b =>
                {
                    b.Property<int>("Person1")
                        .HasColumnType("int");

                    b.Property<int>("Person2")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Person1", "Person2");

                    b.ToTable("whopickedwho");
                });
#pragma warning restore 612, 618
        }
    }
}