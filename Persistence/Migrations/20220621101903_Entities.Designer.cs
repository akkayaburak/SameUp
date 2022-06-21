﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220621101903_Entities")]
    partial class Entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Domain.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Domain.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineBrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelName")
                        .HasColumnType("TEXT");

                    b.Property<int>("YearOfProduction")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MachineBrandId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Domain.MachineBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MachineCategoryId");

                    b.ToTable("MachineBrands");
                });

            modelBuilder.Entity("Domain.MachineCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MachineCategories");
                });

            modelBuilder.Entity("Domain.MachineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MachineCategoryId");

                    b.ToTable("MachineTypes");
                });

            modelBuilder.Entity("Domain.Attachment", b =>
                {
                    b.HasOne("Domain.MachineType", "MachineType")
                        .WithMany("Attachments")
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("Domain.Machine", b =>
                {
                    b.HasOne("Domain.MachineBrand", "MachineBrand")
                        .WithMany("Machines")
                        .HasForeignKey("MachineBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.MachineType", "MachineType")
                        .WithMany("Machines")
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineBrand");

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("Domain.MachineBrand", b =>
                {
                    b.HasOne("Domain.MachineCategory", "MachineCategory")
                        .WithMany("MachineBrands")
                        .HasForeignKey("MachineCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineCategory");
                });

            modelBuilder.Entity("Domain.MachineType", b =>
                {
                    b.HasOne("Domain.MachineCategory", "MachineCategory")
                        .WithMany("MachineTypes")
                        .HasForeignKey("MachineCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineCategory");
                });

            modelBuilder.Entity("Domain.MachineBrand", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("Domain.MachineCategory", b =>
                {
                    b.Navigation("MachineBrands");

                    b.Navigation("MachineTypes");
                });

            modelBuilder.Entity("Domain.MachineType", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Machines");
                });
#pragma warning restore 612, 618
        }
    }
}