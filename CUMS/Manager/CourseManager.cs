using CUMS.Gateway.UnitOfWorks;
using CUMS.Models;
using CUMS.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUMS.Manager
{
    public class CourseManager
    {
        private UnitOfWork unitofWork;

        public CourseManager()
        {
            unitofWork = new UnitOfWork();
        }
        //save
        public string Save(Course course)
        {
            if (unitofWork.Course.IsExists(x => x.Name == course.Name && x.IsDelete == 0))
            {
                return Message.Warning("Semester already exists");
            }
            else
            {
                unitofWork.Course.Add(course);
                int rowAffect = unitofWork.Completed();
                return (rowAffect > 0) ? Message.Success("Save Successful") : Message.Failed("Save Failed");
            }
        }
        //view
        public List<Course> GetAll()
        {
            return unitofWork.Course.GetAllByExpression(x => x.IsDelete == 0).ToList();
        }
        // get by id
        public Course GetById(int id)
        {
            return unitofWork.Course.Get(x => x.Id == id && x.IsDelete == 0);
        }
        // check is exists
        public bool IsExists(int id)
        {
            return unitofWork.Course.IsExists(x => x.Id == id && x.IsDelete == 0);
        }
        // update
        public string Update(Course course)
        {
            if (unitofWork.Course.IsExists(x => x.Name == course.Name && x.IsDelete == 0 && x.Id != course.Id))
            {
                return Message.Warning("Course Already Exists");
            }
            else
            {
                unitofWork.Course.Update(course);
                int updated = unitofWork.Completed();
                return (updated > 0) ? "1" : Message.Failed("Update Failed");
            }
        }
        //get all for dropdown
        public List<SelectListItem> GetSemesterForDropDown()
        {
            return GetAll().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
        }
        // get all course by department selection
        public List<Course> GetAllCourseByDepartment(int departmentId)
        {
            return unitofWork.Course.GetAllByExpression(x => x.DepartmentId == departmentId).ToList();
        }
    }
}
