using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectAtADOWithCrud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAtADOWithCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StudentDataAccess dataAccess;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dataAccess = new StudentDataAccess();
        }

        public IActionResult Index()
        {
            var stud = dataAccess.GetStudentCourse();
            return View(stud);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
