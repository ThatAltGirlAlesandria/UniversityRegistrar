using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UniversityRegistrarContext _db;

        public CoursesController(UniversityRegistrarContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Course> model = _db.Courses.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("Create");
        }

        //("/courses/new")
        [HttpPost]
        public ActionResult Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Course course = _db.Courses
                .Include(student => student.JoinEntities)
                .ThenInclude(join => join.Student)
                .FirstOrDefault(course => course.CourseId == id);
            return View(course);
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
            Course arg = _db.Courses
                .FirstOrDefault(course => course.CourseId == id);
            return View(arg);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Destroy(int id)
        {
            Course course = _db.Courses.FirstOrDefault(course => course.CourseId == id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddStudent(int id)
        {
            Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
            ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
            return View(thisCourse);
        }

        [HttpPost]
        public ActionResult AddStudent(Course course, int studentId)
        {
#nullable enable
            StudentCourse? joinEntity = _db.StudentCourses.FirstOrDefault(join =>
                (join.CourseId == course.CourseId && join.StudentId == studentId));
#nullable disable
            if (joinEntity == null && course.CourseId != 0)
            {
                _db.StudentCourses.Add(new StudentCourse() { CourseId = course.CourseId, StudentId = studentId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = course.CourseId });
        }
    }
}