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
    public class DepartmentController : Controller
    {
        public DepartmentManager departmentManager;
        public DepartmentController()
        {
            departmentManager = new DepartmentManager();
        }
        //save
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Departments = departmentManager.GetAll();
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Department department)
        {
            ViewBag.Departments = departmentManager.GetAll();
            //save
            if (ModelState.IsValid)
            {
                department.Action = Actions.ActionInsert;
                department.ActionDate = DateTime.Now.ToString("F");
                department.ActionBy = "Me";
                department.IsDelete = 0;
                ViewData["Message"] = departmentManager.Save(department);
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                return View(department);
            }
        }
        //update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //edit
            if (id == null)
            {
                return View(ViewData["Message"] = "Category Not Available");
            }
            Department department = departmentManager.GetById(id);
            if (department != null)
            {
                return View(department);
            }
            return NotFound("404- Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                department.Action = Actions.ActionUpdate;
                department.ActionDate = DateTime.Now.ToString("F");
                department.ActionBy = "Me";
                department.IsDelete = 0;
                string updated = departmentManager.Update(department);
                ViewData["Message"] = updated;
                ModelState.Clear();
                if (updated.Equals("1"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Message"] = updated;
                    return View(department);
                }
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                //get by id
                Department departmentModel = departmentManager.GetById(department.Id);
                return View(departmentModel);
            }
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Department department = departmentManager.GetById(id);
            department.Action = Actions.ActionRemove;
            department.ActionDate = DateTime.Now.ToString("F");
            department.ActionBy = "Me";
            department.IsDelete = 1;
            string updated = departmentManager.Update(department);
            ViewData["Message"] = "Delete Successful";
            return RedirectToAction(nameof(Index));
        }
        public JsonResult GetAllDepartments()
        {
            return Json(departmentManager.GetAll());
        }
    }
}