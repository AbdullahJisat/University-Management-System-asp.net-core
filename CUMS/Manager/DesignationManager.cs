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
    public class DesignationManager
    {
        private UnitOfWork unitofWork;

        public DesignationManager()
        {
            unitofWork = new UnitOfWork();
        }
        //save
        public string Save(Designation designation)
        {
            if (unitofWork.Designation.IsExists(x => x.Name == designation.Name && x.IsDelete == 0))
            {
                return Message.Warning("Designation already exists");
            }
            else
            {
                unitofWork.Designation.Add(designation);
                int rowAffect = unitofWork.Completed();
                return (rowAffect > 0) ? Message.Success("Save Successful") : Message.Failed("Save Failed");
            }
        }
        //view
        public List<Designation> GetAll()
        {
            return unitofWork.Designation.GetAllByExpression(x => x.IsDelete == 0).ToList();
        }
        // get by id
        public Designation GetById(int id)
        {
            return unitofWork.Designation.Get(x => x.Id == id && x.IsDelete == 0);
        }
        // check is exists
        public bool IsExists(int id)
        {
            return unitofWork.Designation.IsExists(x => x.Id == id && x.IsDelete == 0);
        }
        // update
        public string Update(Designation designation)
        {
            if (unitofWork.Designation.IsExists(x => x.Name == designation.Name && x.IsDelete == 0 && x.Id == designation.Id))
            {
                return Message.Warning("Designation Already Exists");
            }
            else
            {
                unitofWork.Designation.Update(designation);
                int updated = unitofWork.Completed();
                return (updated > 0) ? "1" : Message.Failed("Update Failed");
            }
        }
        // get all for dropdown
        public List<SelectListItem> GetDesignationForDropDown()
        {
            return GetAll().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
        }
    }
}