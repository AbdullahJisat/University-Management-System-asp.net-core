using CUMS.Gateway.UnitOfWorks;
using CUMS.Models;
using CUMS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUMS.Manager
{
    public class CourseAssignManager
    {
        private UnitOfWork unitofWork;

        public CourseAssignManager()
        {
            unitofWork = new UnitOfWork();
        }
        //save
        public string Save(CourseAssign courseAssign)
        {
            if (unitofWork.CourseAssign.IsExists(x => x.TeacherId == courseAssign.TeacherId && x.CourseId == courseAssign.CourseId && x.IsDelete == 0))
            {
                return Message.Warning("Course" + courseAssign.Course.Name + "was already assign by" + courseAssign.Teacher.Name + "Teacher");
            }
            else
            {
                unitofWork.CourseAssign.Add(courseAssign);
                int rowAffect = unitofWork.Completed();
                return (rowAffect > 0) ? Message.Success("Save Successful") : Message.Failed("Save Failed");
            }
        }
        //view
        public List<CourseAssign> GetAll()
        {
            return unitofWork.CourseAssign.GetAllByExpression(x => x.IsDelete == 0).ToList();
        }
        //public List<CourseAssign> GetByIncludeOperationWithExpression(CourseAssign courseAssign)
        //{
        //    return unitofWork.CourseAssign.GetByIncludeOperationWithExpression(x=>x.CourseId == courseAssign.Id).ToList();
        //}
        // get by id
        public CourseAssign GetById(int id)
        {
            return unitofWork.CourseAssign.Get(x => x.Id == id && x.IsDelete == 0);
        }
        // check is exists
        public bool IsExists(int id)
        {
            return unitofWork.CourseAssign.IsExists(x => x.Id == id && x.IsDelete == 0);
        }
        // update
        public string Update(CourseAssign courseAssign)
        {
            if (unitofWork.CourseAssign.IsExists(x => x.TeacherId == courseAssign.TeacherId && x.CourseId == courseAssign.CourseId && x.IsDelete == 0 && x.Id == courseAssign.Id))
            {
                return Message.Warning("Course Already Exists");
            }
            else
            {
                unitofWork.CourseAssign.Update(courseAssign);
                int updated = unitofWork.Completed();
                return (updated > 0) ? "1" : Message.Failed("Update Failed");
            }
        }
    }
}
