using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CUMS.Manager;
using CUMS.Models;
using CUMS.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CUMS.Controllers
{
    public class RoomController : Controller
    {
        public RoomManager roomManager;
        public RoomController()
        {
            roomManager = new RoomManager();
        }
        //save
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Rooms = roomManager.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Room room)
        {
            ViewBag.Rooms = roomManager.GetAll();
            //save
            if (ModelState.IsValid)
            {
                room.Action = Actions.ActionInsert;
                room.ActionDate = DateTime.Now.ToString("F");
                room.ActionBy = "Me";
                room.IsDelete = 0;
                ViewData["Message"] = roomManager.Save(room);
                ModelState.Clear();
                return Json(roomManager.Save(room));
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                return Json(room);
            }
        }
        //update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //edit
            if (id == null)
            {
                return View(ViewData["Message"] = "Room Not Available");
            }
            Room room = roomManager.GetById(id);
            if (room != null)
            {
                return View(room);
            }
            return NotFound("404- Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                room.Action = Actions.ActionUpdate;
                room.ActionDate = DateTime.Now.ToString("F");
                room.ActionBy = "Me";
                room.IsDelete = 0;
                string updated = roomManager.Update(room);
                ViewData["Message"] = updated;
                ModelState.Clear();
                if (updated.Equals("1"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Message"] = updated;
                    return View(room);
                }
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                //get by id
                Room roomModel = roomManager.GetById(room.Id);
                return View(roomModel);
            }
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Room room = roomManager.GetById(id);
            room.Action = Actions.ActionRemove;
            room.ActionDate = DateTime.Now.ToString("F");
            room.ActionBy = "Me";
            room.IsDelete = 1;
            string updated = roomManager.Update(room);
            ViewData["Message"] = "Delete Successful";
            return RedirectToAction(nameof(Index));
        }
        //public JsonResult GetAll()
        //{
        //    return Json(semesterManager.GetAll());
        //}
    }
}