using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Domain.Connections;
using ToDo.Service.Models;
using ToDo.Service.Services;

namespace ToDo.Pages.CRUD
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        private readonly ITaskServices _connection;

        public UpdateModel(ITaskServices connections)
        {
            _connection = connections;
        }

        [BindProperty(SupportsGet = true)]
        public int TaskId { get; set; }
        public string NewTaskName { get; set; }
        public string NewTaskDescription { get; set; }
        public string NewPriority { get; set; }
        public TasksModel myTask { get; set; }

        public void OnGet()
        {
            myTask = _connection.ShowTaskById(TaskId);
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                _connection.UpdateTask(TaskId, NewTaskName, NewTaskDescription, NewPriority);
            }
            catch (Exception)
            {
                RedirectToPage("/ErrorPage/ErrorPage");
            }
            return RedirectToPage("/Index");
        }
    }
}
