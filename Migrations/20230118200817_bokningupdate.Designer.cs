﻿// <auto-generated />
using System;
using Bokning_G.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bokning_G.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230118200817_bokningupdate")]
    partial class bokningupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bokning_G.Models.Bokningar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("KundNamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkapaKontoId")
                        .HasColumnType("int");

                    b.Property<int>("SummaPerMånad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tid")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SkapaKontoId");

                    b.ToTable("Bokningarna");
                });

            modelBuilder.Entity("Bokning_G.Models.SkapaKonto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Användernamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Lösenord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefonnummer")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Ålder")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Användernamn")
                        .IsUnique();

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.ToTable("Skapade");
                });

            modelBuilder.Entity("Bokning_G.Models.Bokningar", b =>
                {
                    b.HasOne("Bokning_G.Models.SkapaKonto", null)
                        .WithMany("Bokningarna")
                        .HasForeignKey("SkapaKontoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bokning_G.Models.SkapaKonto", b =>
                {
                    b.Navigation("Bokningarna");
                });
#pragma warning restore 612, 618
        }
    }
}
