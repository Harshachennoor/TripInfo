﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripInfo.Models;

#nullable disable

namespace TripInfo.Migrations
{
    [DbContext(typeof(TripContext))]
    [Migration("20240116170648_PopulateAccommodationData")]
    partial class PopulateAccommodationData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("TripInfo.Models.ExistingData", b =>
                {
                    b.Property<int>("ExistingDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ExistingDataId");

                    b.ToTable("ExistingDatas");

                    b.HasData(
                        new
                        {
                            ExistingDataId = 1,
                            Email = "harshachennoor@gmail.com",
                            PhoneNumber = "3316660212"
                        });
                });

            modelBuilder.Entity("TripInfo.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Accommodation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("TripID");

                    b.ToTable("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
