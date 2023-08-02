using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult Create() {
            return View();
        }

        [HttpGet("/Students/{id}")]
        public ActionResult Details(int id) {
            return View();
        }

        [HttpGet("/Students/Edit/{id}")]
        public ActionResult Edit() {
            return View();
        }
    }
}