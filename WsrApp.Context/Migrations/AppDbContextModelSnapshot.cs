﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WsrApp.Context;

namespace WsrApp.Context.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WsrApp.Model.ApiToken", b =>
                {
                    b.Property<Guid>("Token")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("ApiTokens");
                });

            modelBuilder.Entity("WsrApp.Model.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsUnaccepted")
                        .HasColumnType("bit");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("WsrApp.Model.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("WsrApp.Model.FacultySpecialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("FacultySpecialties");
                });

            modelBuilder.Entity("WsrApp.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("WsrApp.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WsrApp.Model.ProjectStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectStages");
                });

            modelBuilder.Entity("WsrApp.Model.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("WsrApp.Model.StudentSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentSkills");
                });

            modelBuilder.Entity("WsrApp.Model.Student", b =>
                {
                    b.HasBaseType("WsrApp.Model.Person");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.HasIndex("FacultyId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WsrApp.Model.User", b =>
                {
                    b.HasBaseType("WsrApp.Model.Person");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WsrApp.Model.Teacher", b =>
                {
                    b.HasBaseType("WsrApp.Model.User");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.HasIndex("FacultyId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("WsrApp.Model.ApiToken", b =>
                {
                    b.HasOne("WsrApp.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WsrApp.Model.Consultation", b =>
                {
                    b.HasOne("WsrApp.Model.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("WsrApp.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("WsrApp.Model.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Project");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("WsrApp.Model.FacultySpecialty", b =>
                {
                    b.HasOne("WsrApp.Model.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("WsrApp.Model.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId");

                    b.Navigation("Faculty");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("WsrApp.Model.ProjectStage", b =>
                {
                    b.HasOne("WsrApp.Model.Project", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WsrApp.Model.StudentSkill", b =>
                {
                    b.HasOne("WsrApp.Model.Student", "Student")
                        .WithMany("Skills")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WsrApp.Model.Student", b =>
                {
                    b.HasOne("WsrApp.Model.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("WsrApp.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("WsrApp.Model.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("WsrApp.Model.User", b =>
                {
                    b.HasOne("WsrApp.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("WsrApp.Model.User", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WsrApp.Model.Teacher", b =>
                {
                    b.HasOne("WsrApp.Model.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("WsrApp.Model.User", null)
                        .WithOne()
                        .HasForeignKey("WsrApp.Model.Teacher", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("WsrApp.Model.Project", b =>
                {
                    b.Navigation("Stages");
                });

            modelBuilder.Entity("WsrApp.Model.Student", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
