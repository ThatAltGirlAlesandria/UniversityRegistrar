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
    
        [HttpGet("/Students")]
        public ActionResult Index()
        {
            List<Student> model = _db.Students.ToList();
            return View(model);
        }

        [HttpGet("/Students/New")]
        public ActionResult New() {
            return View("Create");
        }

        [HttpPost("/Students/New")]
        public ActionResult Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/Students/{id}")]
        public ActionResult Details(int id) {
            Student model = _db.Students
                .FirstOrDefault(student => student.StudentId == id);
            return View(model);
        }

        [HttpGet("/Students/Edit/{id}")]
        public ActionResult Edit() {
            return View();
        }
    }
}