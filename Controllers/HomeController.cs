using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskPlanner.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext db;
        public HomeController(TaskContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Tasks.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Task task)
        {
            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //----------------------------------------------------------------
        public IActionResult GetMessage()
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
