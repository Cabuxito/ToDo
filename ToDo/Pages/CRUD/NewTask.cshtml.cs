using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ToDo.Domain.Connections;
using ToDo.Service.Services;

namespace ToDo.Pages.CRUD
{
    public class NewTaskModel : PageModel
    {
        private readonly ITaskServices _connection;

        public NewTaskModel(ITaskServices connection)
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
            try
            {
                _connection.NewTask(TaskName, TaskDescription, Priority);

            }
            catch (Exception)
            {
                RedirectToPage("/ErrorPage/ErrorPage");
            }
            return RedirectToPage("/Index");
        }

    }
}
