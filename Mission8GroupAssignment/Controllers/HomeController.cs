using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission8GroupAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8GroupAssignment.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private TodoContext todoContext { get; set; }
        public HomeController(ILogger<HomeController> logger, TodoContext tc)
        {
            _logger = logger;
            todoContext = tc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var applications = todoContext.Responses.ToList();
            return View(applications);
        }

        [HttpGet]
        public IActionResult Task()
        {
            ViewBag.Categories = todoContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Task(TaskApplication ta)
        {
            if (ModelState.IsValid)
            {
                todoContext.Add(ta);
                todoContext.SaveChanges();
                return View("Confirmation", ta);
            }
            else
            {
                ViewBag.Categories = todoContext.Categories.ToList();
                return View(ta);
            }

        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = todoContext.Categories.ToList();
            var application = todoContext.Responses.Single(x => x.ApplicationId == applicationid);
            return View("Task", application);
        }

        [HttpPost]

        public IActionResult Edit(TaskApplication ta)
        {
            todoContext.Update(ta);
            todoContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = todoContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(TaskApplication ta)
        {
            todoContext.Responses.Remove(ta);
            todoContext.SaveChanges();
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
