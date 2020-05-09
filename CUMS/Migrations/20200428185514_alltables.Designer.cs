﻿// <auto-generated />
using CUMS.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CUMS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200428185514_alltables")]
    partial class alltables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CUMS.Models.ClassroomAllocate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<int>("CourseId");

                    b.Property<string>("Day");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("EndTime");

                    b.Property<int>("IsDelete");

                    b.Property<int>("RoomId");

                    b.Property<string>("StartTime");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoomId");

                    b.ToTable("ClassroomAllocates");
                });

            modelBuilder.Entity("CUMS.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<string>("Code");

                    b.Property<decimal>("Credit");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<int>("IsDelete");

                    b.Property<string>("Name");

                    b.Property<int>("SemesterId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CUMS.Models.CourseAssign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<int>("CourseId");

                    b.Property<int>("IsDelete");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseAssigns");
                });

            modelBuilder.Entity("CUMS.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<string>("Code");

                    b.Property<int>("IsDelete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CUMS.Models.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<int>("IsDelete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("CUMS.Models.EnrollCourses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<int>("CourseId");

                    b.Property<string>("Date");

                    b.Property<int>("IsDelete");

                    b.Property<int>("StudentId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("EnrollCourseses");
                });

            modelBuilder.Entity("CUMS.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<int>("CourseId");

                    b.Property<string>("Grade");

                    b.Property<int>("IsDelete");

                    b.Property<int>("StudentId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("CUMS.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<int>("IsDelete");

                    b.Property<string>("RoomNo");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("CUMS.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<int>("IsDelete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("CUMS.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<string>("Address");

                    b.Property<string>("Contact");

                    b.Property<string>("Date");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<int>("IsDelete");

                    b.Property<string>("Name");

                    b.Property<string>("RegNo");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CUMS.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("ActionBy");

                    b.Property<string>("ActionDate");

                    b.Property<string>("Address");

                    b.Property<string>("Contact");

                    b.Property<decimal>("CreditTaken");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DesignationId");

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<int>("IsDelete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CUMS.Models.ClassroomAllocate", b =>
                {
                    b.HasOne("CUMS.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CUMS.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CUMS.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CUMS.Models.Course", b =>
                {
                    b.HasOne("CUMS.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CUMS.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CUMS.Models.CourseAssign", b =>
                {
                    b.HasOne("CUMS.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CUMS.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CUMS.Models.EnrollCourses", b =>
                {
                    b.HasOne("CUMS.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CUMS.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CUMS.Models.Result", b =>
                {
                    b.HasOne("CUMS.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CUMS.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CUMS.Models.Student", b =>
                {
                    b.HasOne("CUMS.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CUMS.Models.Teacher", b =>
                {
                    b.HasOne("CUMS.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CUMS.Models.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}