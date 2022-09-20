using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Models;
using ToDo.Service.Services;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITaskServices _taskServices;

        public IndexModel(ITaskServices services)
        {
            _taskServices = services;
        }

        public List<TasksModel> TaskList { get; set; }
        [BindProperty]
        public bool CompleteCheck { get; set; }

        public void OnGet()
        {
            TaskList = _taskServices.ShowAllTask();
        }
        public IActionResult OnPostDeleteButton(int TaskId)
        {
            _taskServices.DeleteTaskById(TaskId);
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostSave(int TaskId)
        {
            if (CompleteCheck == true)
            {
                _taskServices.TaskIsCompleted(TaskId);
                return RedirectToPage("/Index");
            }
            return RedirectToPage("/Index");
        }
    }
}