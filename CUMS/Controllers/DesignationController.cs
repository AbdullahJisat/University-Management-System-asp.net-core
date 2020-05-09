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
    public class DesignationController : Controller
    {
        public DesignationManager designationManager;
        public DesignationController()
        {
            designationManager = new DesignationManager();
        }
        //save
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.Designations = designationManager.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Designation designation)
        {
            ViewBag.Designations = designationManager.GetAll();
            //save
            if (ModelState.IsValid)
            {
                designation.Action = Actions.ActionInsert;
                designation.ActionDate = DateTime.Now.ToString("F");
                designation.ActionBy = "Me";
                designation.IsDelete = 0;
                ViewData["Message"] = designationManager.Save(designation);
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                return View(designation);
            }
        }
        //update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //edit
            if (id == null)
            {
                return View(ViewData["Message"] = "Course Not Available");
            }
            Designation designation = designationManager.GetById(id);
            if (designation != null)
            {
                return View(designation);
            }
            return NotFound("404- Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Designation designation)
        {
            if (id != designation.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                designation.Action = Actions.ActionUpdate;
                designation.ActionDate = DateTime.Now.ToString("F");
                designation.ActionBy = "Me";
                designation.IsDelete = 0;
                string updated = designationManager.Update(designation);
                ViewData["Message"] = updated;
                ModelState.Clear();
                if (updated.Equals("1"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Message"] = updated;
                    return View(designation);
                }
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                //get by id
                Designation designationModel = designationManager.GetById(designation.Id);
                return View(designationModel);
            }
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Designation designation = designationManager.GetById(id);
            designation.Action = Actions.ActionRemove;
            designation.ActionDate = DateTime.Now.ToString("F");
            designation.ActionBy = "Me";
            designation.IsDelete = 1;
            string updated = designationManager.Update(designation);
            ViewData["Message"] = "Delete Successful";
            return RedirectToAction(nameof(Index));
        }
    }
}