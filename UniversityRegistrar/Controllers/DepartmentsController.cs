using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;

namespace UniversityRegistrar
{
    public class DepartmentsController : Controller
    {
        private readonly UniversityRegistrarContext _db;

        public DepartmentsController(UniversityRegistrarContext db)
        {
            _db = db;
        }
    }
}