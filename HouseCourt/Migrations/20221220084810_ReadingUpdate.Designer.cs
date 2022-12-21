﻿// <auto-generated />
using System;
using HouseCourt.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HouseCourt.Migrations
{
    [DbContext(typeof(HouseCourtContext))]
    [Migration("20221220084810_ReadingUpdate")]
    partial class ReadingUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HouseCourt.Entities.Consumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int>("SensorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("Consumptions");
                });

            modelBuilder.Entity("HouseCourt.Entities.House", b =>
                {
                    b.Property<string>("MACAdress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MACAdress");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("HouseCourt.Entities.Reading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HouseMACAdress")
                        .HasColumnType("text");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("HouseMACAdress");

                    b.ToTable("Readings");
                });

            modelBuilder.Entity("HouseCourt.Entities.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SensorId"));

                    b.Property<string>("HouseMACAdress")
                        .HasColumnType("text");

                    b.Property<string>("MACAdress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SensorAverageConsuption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SensorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SensorId");

                    b.HasIndex("HouseMACAdress");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("HouseCourt.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("TypeReading");
                });

            modelBuilder.Entity("HouseCourt.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("HouseCourt.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("HouseMACAdress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HouseMACAdress");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HouseCourt.Entities.Consumption", b =>
                {
                    b.HasOne("HouseCourt.Entities.Sensor", "Sensor")
                        .WithMany("Consuptions")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("HouseCourt.Entities.Reading", b =>
                {
                    b.HasOne("HouseCourt.Entities.House", "House")
                        .WithMany("Readings")
                        .HasForeignKey("HouseMACAdress");

                    b.Navigation("House");
                });

            modelBuilder.Entity("HouseCourt.Entities.Sensor", b =>
                {
                    b.HasOne("HouseCourt.Entities.House", null)
                        .WithMany("Sensors")
                        .HasForeignKey("HouseMACAdress");
                });

            modelBuilder.Entity("HouseCourt.Entities.Type", b =>
                {
                    b.HasOne("HouseCourt.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("HouseCourt.Entities.User", b =>
                {
                    b.HasOne("HouseCourt.Entities.House", "House")
                        .WithMany("Users")
                        .HasForeignKey("HouseMACAdress");

                    b.Navigation("House");
                });

            modelBuilder.Entity("HouseCourt.Entities.House", b =>
                {
                    b.Navigation("Readings");

                    b.Navigation("Sensors");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HouseCourt.Entities.Sensor", b =>
                {
                    b.Navigation("Consuptions");
                });
#pragma warning restore 612, 618
        }
    }
}
