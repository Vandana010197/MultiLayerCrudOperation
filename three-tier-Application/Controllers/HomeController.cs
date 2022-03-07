using BusinessLayer;
using CommonAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using three_tier_Application.Models;

namespace three_tier_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private BLEmployeeBusiness business = new BLEmployeeBusiness();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var emp = business.GetEmployees();
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees employee)
        {
            var result=business.CreateEmployee(employee);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create employee");
                return View(employee);
            }
        }
        public IActionResult Update(int id)
        {
            var emp = business.GetEmployeeById(id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Update(Employees employee)
        {
            var emp=business.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            business.DeleteEmployee(id);
            return RedirectToAction("Index");
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
