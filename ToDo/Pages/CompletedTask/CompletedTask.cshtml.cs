using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Models;
using ToDo.Service.Services;

namespace ToDo.Pages.CompletedTask
{
    public class CompletedTaskModel : PageModel
    {
        private readonly ITaskServices _taskServices;

        public CompletedTaskModel(ITaskServices services)
        {
            _taskServices = services;
        }
        public List<TasksModel> TaskList { get; set; }

        public void OnGet()
        {
            TaskList = _taskServices.ShowAllTask();
        }
    }
}
