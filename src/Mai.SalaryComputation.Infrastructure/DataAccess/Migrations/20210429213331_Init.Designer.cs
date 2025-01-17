﻿// <auto-generated />
using System;
using Mai.SalaryComputation.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mai.SalaryComputation.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210429213331_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Mai.SalaryComputation.Domain.Entities.ProcessedFile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("payload");

                    b.Property<string>("Sha512Hash")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("hash");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("processed_files");
                });
#pragma warning restore 612, 618
        }
    }
}
