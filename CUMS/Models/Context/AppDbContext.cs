using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUMS.Models.Context
{
    public class AppDbContext : DbContext
    {
        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<CourseAssign> CourseAssigns { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassroomAllocate> ClassroomAllocates { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<EnrollCourses> EnrollCourseses { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
