﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretSanta.Core.Domain.Contexts;

namespace SecretSanta.Core.Migrations.MySQL
{
    [DbContext(typeof(SantaContext))]
    [Migration("20220130015715_updatedToAddYearsAndSettings")]
    partial class updatedToAddYearsAndSettings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("SecretSanta.Core.Domain.Peeps", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("WhatNo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.Property<string>("address1")
                        .HasColumnType("text");

                    b.Property<string>("address2")
                        .HasColumnType("text");

                    b.Property<string>("address3")
                        .HasColumnType("text");

                    b.Property<string>("consent")
                        .HasColumnType("text");

                    b.Property<string>("creepy")
                        .HasColumnType("text");

                    b.Property<string>("extra")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("pic")
                        .HasColumnType("text");

                    b.Property<bool>("picked")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("picking")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("postcode")
                        .HasColumnType("text");

                    b.Property<string>("uniquePass")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Peeps");
                });

            modelBuilder.Entity("SecretSanta.Core.Domain.whopickedwho", b =>
                {
                    b.Property<int>("Person1")
                        .HasColumnType("int");

                    b.Property<int>("Person2")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.HasKey("Person1", "Person2");

                    b.ToTable("whopickedwho");
                });
#pragma warning restore 612, 618
        }
    }
}
