﻿// <auto-generated />
using BloodSugarCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodSugarCore.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("BloodSugarCore.Model.BloodReading", b =>
                {
                    b.Property<int>("ReadingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReadingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReadingTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ReadingValue")
                        .HasColumnType("TEXT");

                    b.HasKey("ReadingID");

                    b.ToTable("BloodReadings");
                });
#pragma warning restore 612, 618
        }
    }
}
