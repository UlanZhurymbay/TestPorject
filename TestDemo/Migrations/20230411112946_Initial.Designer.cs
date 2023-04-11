﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestDemo.Models.Data;

#nullable disable

namespace TestDemo.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20230411112946_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestDemo.Models.Entities.R_CURRENCY", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("A_Date")
                        .HasColumnType("Date");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RCurrencies");
                });
#pragma warning restore 612, 618
        }
    }
}