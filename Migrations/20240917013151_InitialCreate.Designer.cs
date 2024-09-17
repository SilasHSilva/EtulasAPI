﻿// <auto-generated />
using System;
using EtulasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EtulasAPI.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20240917013151_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EtulasAPI.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("OccupiedBeds")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("EtulasAPI.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("HospitalId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("EtulasAPI.Models.Patient", b =>
                {
                    b.HasOne("EtulasAPI.Models.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });
#pragma warning restore 612, 618
        }
    }
}