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
    public class RoomManager
    {
        private UnitOfWork unitofWork;

        public RoomManager()
        {
            unitofWork = new UnitOfWork();
        }
        //save
        public string Save(Room room)
        {
            if (unitofWork.Room.IsExists(x => x.RoomNo == room.RoomNo && x.IsDelete == 0))
            {
                return Message.Warning("Room already exists");
            }
            else
            {
                unitofWork.Room.Add(room);
                int rowAffect = unitofWork.Completed();
                return (rowAffect > 0) ? Message.Success("Save Successful") : Message.Failed("Save Failed");
            }
        }
        //view
        public List<Room> GetAll()
        {
            return unitofWork.Room.GetAllByExpression(x => x.IsDelete == 0).ToList();
        }
        // get by id
        public Room GetById(int id)
        {
            return unitofWork.Room.Get(x => x.Id == id && x.IsDelete == 0);
        }
        // check is exists
        public bool IsExists(int id)
        {
            return unitofWork.Room.IsExists(x => x.Id == id && x.IsDelete == 0);
        }
        // update
        public string Update(Room room)
        {
            if (unitofWork.Room.IsExists(x => x.RoomNo == room.RoomNo && x.IsDelete == 0 && x.Id == room.Id))
            {
                return Message.Warning("Room Already Exists");
            }
            else
            {
                unitofWork.Room.Update(room);
                int updated = unitofWork.Completed();
                return (updated > 0) ? "1" : Message.Failed("Update Failed");
            }
        }
        //get all for dropdown
        public List<SelectListItem> GetSemesterForDropDown()
        {
            return GetAll().ConvertAll(x => new SelectListItem() { Text = x.RoomNo, Value = x.Id.ToString() });
        }
    }
}
