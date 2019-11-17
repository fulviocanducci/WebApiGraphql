﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppiGraphql.Services;

namespace WebAppiGraphql.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0-preview1.19506.2");

            modelBuilder.Entity("WebAppiGraphql.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Updated")
                        .HasColumnName("updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("peoples");
                });
#pragma warning restore 612, 618
        }
    }
}
