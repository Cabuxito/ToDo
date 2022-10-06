using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Services;

namespace ToDo.Pages
{
    public class AddTaskToUserModel : PageModel
    {
        private readonly ITaskServices _taskServices;
        
        public AddTaskToUserModel(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }
        [BindProperty(SupportsGet = true)]
        public int TaskId { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnPost()
        {
            _taskServices.Add
        }
    }
}
