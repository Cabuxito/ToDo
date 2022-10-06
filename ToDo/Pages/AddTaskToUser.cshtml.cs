using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Services;

namespace ToDo.Pages
{
    public class AddTaskToUserModel : PageModel
    {
        private readonly ITaskServices _taskServices;
        private readonly IUserService _userService;

        public AddTaskToUserModel(ITaskServices taskServices, IUserService userService)
        {
            _taskServices = taskServices;
            _userService = userService;
        }
        [BindProperty(SupportsGet = true)]
        public int TaskId { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            _userService.GetUserIdByUsername(Username,Password);
            _taskServices.AddTaskToUser(_userService.LoggedIndId(), TaskId);
            return RedirectToAction("/Index");
        }
    }
}
