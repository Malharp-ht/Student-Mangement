﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Data;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(mangementDBContext))]
    [Migration("20240123060333_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNetApplication.Data.Course", b =>
                {
                    b.Property<int>("courseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseId"));

                    b.Property<string>("courseDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("courseId");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            courseId = 1,
                            courseDescription = "ECE",
                            courseName = "ECE"
                        },
                        new
                        {
                            courseId = 2,
                            courseDescription = "CSE",
                            courseName = "CSE"
                        });
                });

            modelBuilder.Entity("DotNetApplication.Data.Enrollement", b =>
                {
                    b.Property<int>("enrollementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("enrollementId"));

                    b.Property<int>("courseId")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("enrollementId");

                    b.HasIndex("courseId");

                    b.HasIndex("studentId");

                    b.ToTable("Enrollements");
                });

            modelBuilder.Entity("DotNetApplication.Data.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentId"));

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("studentId");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            studentId = 1,
                            Address = "Baramati",
                            DOB = new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "malharp@gmail.com",
                            StudentName = "Malhar"
                        },
                        new
                        {
                            studentId = 2,
                            Address = "Satara",
                            DOB = new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mohitl@gmail.com",
                            StudentName = "Mohit"
                        });
                });

            modelBuilder.Entity("DotNetApplication.Data.Enrollement", b =>
                {
                    b.HasOne("DotNetApplication.Data.Course", "Course")
                        .WithMany("Enrollements")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetApplication.Data.Student", "Student")
                        .WithMany("Enrollements")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DotNetApplication.Data.Course", b =>
                {
                    b.Navigation("Enrollements");
                });

            modelBuilder.Entity("DotNetApplication.Data.Student", b =>
                {
                    b.Navigation("Enrollements");
                });
#pragma warning restore 612, 618
        }
    }
}
