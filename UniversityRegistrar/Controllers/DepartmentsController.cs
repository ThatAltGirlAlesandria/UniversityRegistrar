using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;

namespace UniversityRegistrar
{
    public class DepartmentsController : Controller
    {
        private readonly UniversityRegistrarContext _db;

        public DepartmentsController(UniversityRegistrarContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            //List<Department> model = _db.Departments.ToList();
            return View();
        }
    }
}