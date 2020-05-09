using CUMS.Gateway.IRepositories;
using CUMS.Gateway.Repositories;
using CUMS.Models;
using CUMS.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUMS.Gateway.UnitOfWorks
{
    public class UnitOfWork
    {
        public Repository<Department> Department { get; set; }
        public Repository<Semester> Semester { get; set; }
        public Repository<Course> Course { get; set; }
        public Repository<CourseAssign> CourseAssign { get; set; }
        public Repository<EnrollCourses> EnrollCourses { get; set; }
        public Repository<Teacher> Teacher { get; set; }
        public Repository<Designation> Designation { get; set; }
        public Repository<Result> Result { get; set; }
        public Repository<Room> Room { get; set; }
        public Repository<ClassroomAllocate> ClassroomAllocate { get; set; }
        public Repository<Student> Student { get; set; }
     
        AppDbContext context = new AppDbContext();

        public UnitOfWork()
        {
            Department = new Repository<Department>(context);
            Semester = new Repository<Semester>(context);
            Course = new Repository<Course>(context);
            CourseAssign = new Repository<CourseAssign>(context);
            EnrollCourses = new Repository<EnrollCourses>(context);
            Teacher = new Repository<Teacher>(context);
            Designation = new Repository<Designation>(context);
            Result = new Repository<Result>(context);
            Room = new Repository<Room>(context);
            ClassroomAllocate = new Repository<ClassroomAllocate>(context);
            Student = new Repository<Student>(context);
        }

        public int Completed()
        {
            return context.SaveChanges();
        }
    }
}