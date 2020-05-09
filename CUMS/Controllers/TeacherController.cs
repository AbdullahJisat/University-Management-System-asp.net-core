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
    public class TeacherController : Controller
    {
        public DepartmentManager departmentManager;
        public DesignationManager designationManager;
        public TeacherManager teacherManager;
        public CourseManager courseManager;
        public CourseAssignManager courseAssignManager;
        public TeacherController()
        {
            departmentManager = new DepartmentManager();
            designationManager = new DesignationManager();
            teacherManager = new TeacherManager();
            courseManager = new CourseManager();
            courseAssignManager = new CourseAssignManager();
        }
        //save
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Teachers = teacherManager.GetAll();
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Designation = designationManager.GetDesignationForDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Teacher teacher)
        {
            ViewBag.Teachers = teacherManager.GetAll();
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Designation = designationManager.GetDesignationForDropDown();
            //save
            if (ModelState.IsValid)
            {
                teacher.Action = Actions.ActionInsert;
                teacher.ActionDate = DateTime.Now.ToString("F");
                teacher.ActionBy = "Me";
                teacher.IsDelete = 0;
                ViewData["Message"] = teacherManager.Save(teacher);
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                return View(teacher);
            }
        }
        //update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Designation = designationManager.GetDesignationForDropDown();
            //edit
            if (id == null)
            {
                return View(ViewData["Message"] = "Course Not Available");
            }
            Teacher teacher = teacherManager.GetById(id);
            if (teacher != null)
            {
                return View(teacher);
            }
            return NotFound("404- Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Teacher teacher)
        {
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            ViewBag.Designation = designationManager.GetDesignationForDropDown();
            if (id != teacher.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                teacher.Action = Actions.ActionUpdate;
                teacher.ActionDate = DateTime.Now.ToString("F");
                teacher.ActionBy = "Me";
                teacher.IsDelete = 0;
                string updated = teacherManager.Update(teacher);
                ViewData["Message"] = updated;
                ModelState.Clear();
                if (updated.Equals("1"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Message"] = updated;
                    return View(teacher);
                }
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                //get by id
                Teacher teacherModel = teacherManager.GetById(teacher.Id);
                return View(teacherModel);
            }
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Teacher teacher = teacherManager.GetById(id);
            teacher.Action = Actions.ActionRemove;
            teacher.ActionDate = DateTime.Now.ToString("F");
            teacher.ActionBy = "Me";
            teacher.IsDelete = 1;
            string updated = teacherManager.Update(teacher);
            ViewData["Message"] = "Delete Successful";
            return RedirectToAction(nameof(Index));
        }
        //Assign Course To Teacher
        [HttpGet]
        public ActionResult AssignCourseToTeacher()
        {
            ViewBag.Department = departmentManager.GetCategoryForDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult AssignCourseToTeacher(CourseAssign courseAssign)
        {
            ViewBag.Departments = departmentManager.GetCategoryForDropDown();
            if (ModelState.IsValid)
            {
                courseAssign.Action = Actions.ActionInsert;
                courseAssign.ActionDate = DateTime.Now.ToString("F");
                courseAssign.ActionBy = "Me";
                courseAssign.IsDelete = 0;
                ViewData["Message"] = courseAssignManager.Save(courseAssign);
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewData["Message"] = Message.Warning("Fill up all fields correctly");
                return View(courseAssign);
            }
        }
        // get all teacher by department
        public JsonResult GetAllTeacherByDepartment(int departmentId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeacherByDepartment(departmentId);
            return Json(teachers);
        }

        // get all course by department selection
        public JsonResult GetAllCourseByDepartment(int deptId)
        {
            return Json(courseManager.GetAllCourseByDepartment(deptId));
        }
    }
}