using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagerUI.Services;
using TaskManagerUI.Models;
using System.Collections.Generic;

namespace TaskManagerUI.Pages
{
    public class TasksModel : PageModel
    {
        private readonly TaskService _taskService;

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();

        [BindProperty]
        public string NewTaskDescription { get; set; } = string.Empty;

        [BindProperty]
        public DateTime Deadline { get; set; }

        [BindProperty]
        public int Priority { get; set; }

        public TasksModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        public void OnGet(string filter, string sort)
        {
            Tasks = _taskService.GetTasks(filter, sort);
        }

        public IActionResult OnPostAddTask()
        {
            if (!string.IsNullOrEmpty(NewTaskDescription))
            {
                var task = new TaskItem
                {
                    Description = NewTaskDescription,
                    Deadline = Deadline,
                    Priority = Priority
                };
                _taskService.AddTask(task);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToPage();
        }
    }
}
