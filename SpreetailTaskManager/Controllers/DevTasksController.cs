using Microsoft.AspNet.Identity;
using SpreetailTaskManager.Models;
using SpreetailTaskManager.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SpreetailTaskManager.Controllers
{
    public class DevTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevTasksController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new DevTaskViewModel
            {
                Priorities = _context.Priorities.ToList(),
                Tasks = _context.DevTasks.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            DevTasks currentTask = _context.DevTasks.Find(id);



            var viewModel = new DevTaskViewModel
            {
                Title = currentTask.Title,
                DueDate = currentTask.DueDate.ToString("MM/dd/yyyy"),
                Description = currentTask.Description,
                Priorities = _context.Priorities.ToList(),
                Tasks = _context.DevTasks.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DevTaskViewModel viewModel)
        {
            var foo = viewModel.ParentId;
            if (viewModel.ParentId < 1)
            {
                viewModel.ParentId = 0;
            }

            if (!ModelState.IsValid)
            {
                viewModel.Priorities = _context.Priorities.ToList();
                viewModel.Tasks = _context.DevTasks.ToList();
                return View("Create", viewModel);
            }

            var devTask = new DevTasks
            {
                DeveloperId = User.Identity.GetUserId(),
                Title = viewModel.Title,
                Description = viewModel.Description,
                DueDate = viewModel.GetDateTime(),
                CreateDate = DateTime.Now,
                PriorityId = viewModel.Priority,
                ParentId = viewModel.ParentId,
                IsComplete = 0
            };

            _context.DevTasks.Add(devTask);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(DevTaskViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Priorities = _context.Priorities.ToList();
                viewModel.Tasks = _context.DevTasks.ToList();
                return View("Update", viewModel);
            }

            var result = _context.DevTasks.SingleOrDefault(t => t.Id == viewModel.Id);

            if (result != null)
            {
                result.Title = viewModel.Title;
                result.DueDate = viewModel.GetDateTime();
                result.PriorityId = viewModel.Priority;
                result.ParentId = viewModel.ParentId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}