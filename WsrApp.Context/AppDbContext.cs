using Microsoft.EntityFrameworkCore;
using System;
using WsrApp.Model;

namespace WsrApp.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Server=ocmssql02;" +
                "Initial catalog=Wsr21_1AppDb;" +
                "User=WS09;" +
                "Password=Qwerty123$");
        }

        public DbSet<ApiToken> ApiTokens { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FacultySpecialty> FacultySpecialties { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStage> ProjectStages { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSkill> StudentSkills { get; set; }
        public DbSet<Teacher> Teachers { get; set; } 
        public DbSet<User> Users { get; set; }
    }
}
