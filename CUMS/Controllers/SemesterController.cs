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
    public class SemesterController : Controller
    {
        public SemesterManager semesterManager;
        public SemesterController()
        {
            semesterManager = new SemesterManager();
        }
        //save
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.Semesters = semesterManager.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Semester semester)
        {
            ViewBag.Semesters = semesterManager.GetAll();
            //save
            if (ModelState.IsValid)
            {
                semester.Action = Actions.ActionInsert;
                semester.ActionDate = DateTime.Now.ToString("F");
                semester.ActionBy = "Me";
                semester.IsDelete = 0;
                ViewData["Message"] = semesterManager.Save(semester);
                ModelState.Clear();
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                return View(semester);
            }
            return View();
        }
        //update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //edit
            if (id == null)
            {
                return View(ViewData["Message"] = "Semester Not Available");
            }
            Semester semester = semesterManager.GetById(id);
            if (semester != null)
            {
                return View(semester);
            }
            return NotFound("404- Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Semester semester)
        {
            if (id != semester.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                semester.Action = Actions.ActionUpdate;
                semester.ActionDate = DateTime.Now.ToString("F");
                semester.ActionBy = "Me";
                semester.IsDelete = 0;
                string updated = semesterManager.Update(semester);
                ViewData["Message"] = updated;
                ModelState.Clear();
                if (updated.Equals("1"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Message"] = updated;
                    return View(semester);
                }
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                //get by id
                Semester semesterModel = semesterManager.GetById(semester.Id);
                return View(semesterModel);
            }
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Semester semester = semesterManager.GetById(id);
            semester.Action = Actions.ActionRemove;
            semester.ActionDate = DateTime.Now.ToString("F");
            semester.ActionBy = "Me";
            semester.IsDelete = 1;
            string updated = semesterManager.Update(semester);
            ViewData["Message"] = "Delete Successful";
            return RedirectToAction(nameof(Index));
        }
    }
}