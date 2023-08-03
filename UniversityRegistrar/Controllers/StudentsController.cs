using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UniversityRegistrar.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UniversityRegistrarContext _db;

        public StudentsController(UniversityRegistrarContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Student> students = _db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Student student = _db.Students
                .Include(student => student.JoinEntities)
                .ThenInclude(join => join.Course)
                .FirstOrDefault(student => student.StudentId == id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Update(int id)
        {

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student arg = _db.Students
                .FirstOrDefault(student => student.StudentId == id);
            return View(arg);
        }

        [HttpPost]
        public ActionResult Destroy(int id)
        {
            Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
            _db.Students.Remove(thisStudent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCourse(int id)
        {
            Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
            ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
            return View(thisStudent);
        }

        [HttpPost]
        public ActionResult AddCourse(Student student, int courseId)
        {
#nullable enable
            StudentCourse? joinEntity = _db.StudentCourses.FirstOrDefault(join =>
                (join.StudentId == student.StudentId && join.CourseId == courseId));
#nullable disable
            if (joinEntity == null && student.StudentId != 0)
            {
                _db.StudentCourses.Add(new StudentCourse() { StudentId = student.StudentId, CourseId = courseId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = student.StudentId });
        }
    }
}