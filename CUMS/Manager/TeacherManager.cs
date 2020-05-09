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
    public class TeacherManager
    {
        private UnitOfWork unitofWork;

        public TeacherManager()
        {
            unitofWork = new UnitOfWork();
        }
        //save
        public string Save(Teacher teacher)
        {
            if (unitofWork.Teacher.IsExists(x => x.Email == teacher.Email && x.IsDelete == 0))
            {
                return Message.Warning("Semester already exists");
            }
            else
            {
                unitofWork.Teacher.Add(teacher);
                int rowAffect = unitofWork.Completed();
                return (rowAffect > 0) ? Message.Success("Save Successful") : Message.Failed("Save Failed");
            }
        }
        //view
        public List<Teacher> GetAll()
        {
            return unitofWork.Teacher.GetAllByExpression(x => x.IsDelete == 0).ToList();
        }
        // get by id
        public Teacher GetById(int id)
        {
            return unitofWork.Teacher.Get(x => x.Id == id && x.IsDelete == 0);
        }
        // check is exists
        public bool IsExists(int id)
        {
            return unitofWork.Teacher.IsExists(x => x.Id == id && x.IsDelete == 0);
        }
        // update
        public string Update(Teacher teacher)
        {
            if (unitofWork.Teacher.IsExists(x => x.Email == teacher.Email && x.IsDelete == 0 && x.Id == teacher.Id))
            {
                return Message.Warning("Course Already Exists");
            }
            else
            {
                unitofWork.Teacher.Update(teacher);
                int updated = unitofWork.Completed();
                return (updated > 0) ? "1" : Message.Failed("Update Failed");
            }
        }
        //get all for dropdown
        public List<SelectListItem> GetSemesterForDropDown()
        {
            return GetAll().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
        }
        // get all teacher by department selection
        public List<Teacher> GetAllTeacherByDepartment(int departmentId)
        {
            return unitofWork.Teacher.GetAllByExpression(x => x.DepartmentId == departmentId).ToList();
        }
    }
}
