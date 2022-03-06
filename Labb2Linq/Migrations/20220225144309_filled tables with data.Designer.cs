﻿// <auto-generated />
using System;
using Labb2Linq.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb2Linq.Migrations
{
    [DbContext(typeof(DBContextSchool))]
    [Migration("20220225144309_filled tables with data")]
    partial class filledtableswithdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb2Linq.Elev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KlasserId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KlasserId");

                    b.ToTable("Elever");
                });

            modelBuilder.Entity("Labb2Linq.Klass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KlassNamn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Klasser");
                });

            modelBuilder.Entity("Labb2Linq.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KlasserId")
                        .HasColumnType("int");

                    b.Property<string>("KursNamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LärarnaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KlasserId");

                    b.HasIndex("LärarnaId");

                    b.ToTable("Kurser");
                });

            modelBuilder.Entity("Labb2Linq.Lärare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lärare");
                });

            modelBuilder.Entity("Labb2Linq.Elev", b =>
                {
                    b.HasOne("Labb2Linq.Klass", "Klasser")
                        .WithMany()
                        .HasForeignKey("KlasserId");
                });

            modelBuilder.Entity("Labb2Linq.Kurs", b =>
                {
                    b.HasOne("Labb2Linq.Klass", "Klasser")
                        .WithMany("Kurser")
                        .HasForeignKey("KlasserId");

                    b.HasOne("Labb2Linq.Lärare", "Lärarna")
                        .WithMany()
                        .HasForeignKey("LärarnaId");
                });
#pragma warning restore 612, 618
        }
    }
}
