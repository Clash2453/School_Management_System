﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementSystem.Data;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20230321182358_AddPasswordHashing")]
    partial class AddPasswordHashing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SchoolManagementSystem.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Organizer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.StudentEvent", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Models.Event");

                    b.Property<int?>("StudentUserId")
                        .HasColumnType("int");

                    b.HasIndex("StudentUserId");

                    b.ToTable("StudentEvents");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.TeacherEvent", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Models.Event");

                    b.Property<int?>("TeacherUserId")
                        .HasColumnType("int");

                    b.HasIndex("TeacherUserId");

                    b.ToTable("TeacherEvents");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.StudentSubject", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Models.Subject");

                    b.Property<int?>("StudentUserId")
                        .HasColumnType("int");

                    b.HasIndex("StudentUserId");

                    b.ToTable("StudentSubjects");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.TeacherSubject", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Models.Subject");

                    b.Property<int?>("TeacherUserId")
                        .HasColumnType("int");

                    b.HasIndex("TeacherUserId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Admin", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Models.User");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Student", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Models.User");

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Teacher", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Models.User");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.StudentEvent", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Event", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Models.StudentEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Student", null)
                        .WithMany("Events")
                        .HasForeignKey("StudentUserId");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.TeacherEvent", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Event", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Models.TeacherEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Teacher", null)
                        .WithMany("Events")
                        .HasForeignKey("TeacherUserId");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.StudentSubject", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Student", null)
                        .WithMany("Subjects")
                        .HasForeignKey("StudentUserId");

                    b.HasOne("SchoolManagementSystem.Models.Subject", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Models.StudentSubject", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.TeacherSubject", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Subject", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Models.TeacherSubject", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Teacher", null)
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherUserId");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Admin", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.User", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Models.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Student", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.User", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Teacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.User", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Models.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Student", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Teacher", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
