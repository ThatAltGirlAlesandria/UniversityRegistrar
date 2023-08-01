using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;

namespace UniversityRegistrar
{
    public class HomeController : Controller
    {
        private readonly UniversityRegistrarContext _db;

        public HomeController(UniversityRegistrarContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}