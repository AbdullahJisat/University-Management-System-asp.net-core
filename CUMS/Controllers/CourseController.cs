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
    public class CourseController : Controller
    {
        public CourseManager courseManager;
        public DepartmentManager departmentManager;
        public SemesterManager semesterManager;
        public CourseController()
        {
            courseManager = new CourseManager();
            departmentManager = new DepartmentManager();
            semesterManager = new SemesterManager();
        }
        //save
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.Courses = courseManager.GetAll();
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Semester = semesterManager.GetSemesterForDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Course course)
        {
            ViewBag.Courses = courseManager.GetAll();
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Semester = semesterManager.GetSemesterForDropDown();
            //save
            if (ModelState.IsValid)
            {
                course.Action = Actions.ActionInsert;
                course.ActionDate = DateTime.Now.ToString("F");
                course.ActionBy = "Me";
                course.IsDelete = 0;
                ViewData["Message"] = courseManager.Save(course);
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                return View(course);
            }
        }
        //update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Semester = semesterManager.GetSemesterForDropDown();
            //edit
            if (id == null)
            {
                return View(ViewData["Message"] = "Course Not Available");
            }
            Course course = courseManager.GetById(id);
            if (course != null)
            {
                return View(course);
            }
            return NotFound("404- Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Semester = semesterManager.GetSemesterForDropDown();
            if (id != course.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                course.Action = Actions.ActionUpdate;
                course.ActionDate = DateTime.Now.ToString("F");
                course.ActionBy = "Me";
                course.IsDelete = 0;
                string updated = courseManager.Update(course);
                ViewData["Message"] = updated;
                ModelState.Clear();
                if (updated.Equals("1"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Message"] = updated;
                    return View(course);
                }
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                //get by id
                Course courseModel = courseManager.GetById(course.Id);
                return View(courseModel);
            }
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course course = courseManager.GetById(id);
            course.Action = Actions.ActionRemove;
            course.ActionDate = DateTime.Now.ToString("F");
            course.ActionBy = "Me";
            course.IsDelete = 1;
            string updated = courseManager.Update(course);
            ViewData["Message"] = "Delete Successful";
            return RedirectToAction(nameof(Index));
        }
    }
}