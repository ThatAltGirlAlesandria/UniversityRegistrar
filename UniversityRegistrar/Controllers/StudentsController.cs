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
            List<Student> arg = _db.Students.ToList();
            return View(arg);
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
            Student arg = _db.Students
                .FirstOrDefault(student => student.StudentId == id);
            return View(arg);
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

        [HttpPost, ActionName("Delete")]
        public ActionResult Destroy(int id)
        {
            Student thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
            _db.Students.Remove(thisStudent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}