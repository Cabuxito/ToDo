using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ToDo.Domain.Connections;

namespace ToDo.Pages.CRUD
{
    public class NewTaskModel : PageModel
    {
        private readonly IConnections _connection;

        public NewTaskModel(IConnections connection)
        {
            _connection = connection;
        }

        [BindProperty]
        public string TaskName { get; set; }
        [BindProperty, MaxLength(25)]
        public string TaskDescription { get; set; }
        [BindProperty]
        public string Priority { get; set; }

        public IActionResult OnPost()
        {
            _connection.NewTask(TaskName, TaskDescription, Priority);
            return RedirectToPage("/Index");
        }

    }
}
