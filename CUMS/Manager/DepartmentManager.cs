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
    public class DepartmentManager
    {
        private UnitOfWork unitofWork;

        public DepartmentManager()
        {
            unitofWork = new UnitOfWork();
        }
        //save
        public string Save(Department department)
        {
            if (unitofWork.Department.IsExists(x =>x.Code == department.Code && x.Name == department.Name && x.IsDelete == 0))
            {
                return Message.Warning("Department already exists");
            }
            else
            {
                unitofWork.Department.Add(department);
                int rowAffect = unitofWork.Completed();
                return (rowAffect > 0) ? Message.Success("Save Successful") : Message.Failed("Save Failed");
            }
        }
        //view
        public List<Department> GetAll()
        {
            return unitofWork.Department.GetAllByExpression(x => x.IsDelete == 0).ToList();
        }
        // get by id
        public Department GetById(int id)
        {
            return unitofWork.Department.Get(x => x.Id == id && x.IsDelete == 0);
        }
        // check is exists
        public bool IsExists(int id)
        {
            return unitofWork.Department.IsExists(x => x.Id == id && x.IsDelete == 0);
        }
        // update
        public string Update(Department department)
        {
            if (unitofWork.Department.IsExists(x => x.Code == department.Code && x.Name == department.Name && x.IsDelete == 0 && x.Id != department.Id))
            {
                return Message.Warning("Department Already Exists");
            }
            else
            {
                unitofWork.Department.Update(department);
                int updated = unitofWork.Completed();
                return (updated > 0) ? "1" : Message.Failed("Update Failed");
            }
        }
        // get all for dropdown
        public List<SelectListItem> GetCategoryForDropDown()
        {
            return GetAll().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
        }
    }
}
