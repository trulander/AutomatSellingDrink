﻿// <auto-generated />
using AutomatSellingDrink.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutomatSellingDrink.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210726204123_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.Coin", b =>
                {
                    b.HasOne("AutomatSellingDrink.DataAccess.Entities.User", "Owner")
                        .WithMany("Coins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.Drink", b =>
                {
                    b.HasOne("AutomatSellingDrink.DataAccess.Entities.File", "Image")
                        .WithOne("Drink")
                        .HasForeignKey("AutomatSellingDrink.DataAccess.Entities.Drink", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.File", b =>
                {
                    b.Navigation("Drink");
                });

            modelBuilder.Entity("AutomatSellingDrink.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Coins");
                });
#pragma warning restore 612, 618
        }
    }
}
