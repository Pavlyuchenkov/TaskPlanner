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

        //Create
        #region
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
        #endregion

        //Details
        #region
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Models.Task task = await db.Tasks.FirstOrDefaultAsync(p => p.TaskId == id);
                if (task != null)
                    return View(task);
            }
            return NotFound();
        }
        #endregion

        //Edit
        #region
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Models.Task task = await db.Tasks.FirstOrDefaultAsync(p => p.TaskId == id);
                if (task != null)
                    return View(task);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Task task)
        {
            db.Tasks.Update(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        //Delete
        #region
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Models.Task task = await db.Tasks.FirstOrDefaultAsync(p => p.TaskId == id);
                if (task != null)
                    return View(task);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Models.Task  task = new Models.Task { TaskId = id.Value };
                db.Entry(task).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        #endregion

        //------------------------------------------------------------------------------------------
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
