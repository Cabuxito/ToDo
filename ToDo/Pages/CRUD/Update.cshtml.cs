using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Domain.Connections;
using ToDo.Service.Models;

namespace ToDo.Pages.CRUD
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        private readonly IConnections _connection;

        public UpdateModel(IConnections connections)
        {
            _connection = connections;
        }

        [BindProperty(SupportsGet = true)]
        public int TaskId { get; set; }
        public string NewTaskName { get; set; }
        public string NewTaskDescription { get; set; }
        public string NewPriority { get; set; }
        public bool NewStatus { get; set; }
        public TasksModel myTask { get; set; }

        public void OnGet()
        {
            _connection.ShowTaskById(TaskId);
        }

        public IActionResult OnPost(int id)
        {
            _connection.UpdateTask(TaskId, NewTaskName, NewTaskDescription, NewPriority, NewStatus);
            return RedirectToPage("/Index");
        }
    }
}
