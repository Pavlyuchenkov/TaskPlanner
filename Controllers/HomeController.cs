using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskPlanner.Models;

namespace TaskPlanner.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Create(Models.Task task)
        {
            List<Models.Task> tasks = new List<Models.Task>
            {
                new Models.Task{TaskId = task.TaskId, TaskTime = DateTime.Now, TaskName = task.TaskName}
            };
            tasks.Add(task);
            return View("Index", tasks);
        }

        public ActionResult GetMessage()
        {
            return PartialView("_GetMessage");
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
