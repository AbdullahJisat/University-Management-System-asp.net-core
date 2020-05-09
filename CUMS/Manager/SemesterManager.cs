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
    public class SemesterManager
    {
        private UnitOfWork unitofWork;

        public SemesterManager()
        {
            unitofWork = new UnitOfWork();
        }
        //save
        public string Save(Semester semester)
        {
            if (unitofWork.Semester.IsExists(x => x.Name == semester.Name && x.IsDelete == 0))
            {
                return Message.Warning("Semester already exists");
            }
            else
            {
                unitofWork.Semester.Add(semester);
                int rowAffect = unitofWork.Completed();
                return (rowAffect > 0) ? Message.Success("Save Successful") : Message.Failed("Save Failed");
            }
        }
        //view
        public List<Semester> GetAll()
        {
            return unitofWork.Semester.GetAllByExpression(x => x.IsDelete == 0).ToList();
        }
        // get by id
        public Semester GetById(int id)
        {
            return unitofWork.Semester.Get(x => x.Id == id && x.IsDelete == 0);
        }
        // check is exists
        public bool IsExists(int id)
        {
            return unitofWork.Semester.IsExists(x => x.Id == id && x.IsDelete == 0);
        }
        // update
        public string Update(Semester semester)
        {
            if (unitofWork.Semester.IsExists(x => x.Name == semester.Name && x.IsDelete == 0 && x.Id != semester.Id))
            {
                return Message.Warning("Semester Already Exists");
            }
            else
            {
                unitofWork.Semester.Update(semester);
                int updated = unitofWork.Completed();
                return (updated > 0) ? "1" : Message.Failed("Update Failed");
            }
        }
        //get all for dropdown
        public List<SelectListItem> GetSemesterForDropDown()
        {
            return GetAll().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
        }
    }
}
