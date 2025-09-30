using Microsoft.AspNetCore.Mvc;
using TodoApp.Business.Interfaces;
using TodoApp.Entities;

namespace TodoApp.WebUI.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskItemService.GetAllTasksAsync();
            return View(tasks);
        }

        public async Task<IActionResult> Completed()
        {
            var completedTasks = await _taskItemService.GetCompletedTasksAsync();
            return View(completedTasks);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                await _taskItemService.AddTaskAsync(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

    }
}
