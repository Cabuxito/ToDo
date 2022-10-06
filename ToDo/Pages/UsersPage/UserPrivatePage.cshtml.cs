using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Models;
using ToDo.Service.Services;

namespace ToDo.Pages.UsersPage
{
    public class UserPrivatePageModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ITaskServices _taskServices;

        public UserPrivatePageModel(IUserService userService, ITaskServices taskServices) 
        {
            _userService = userService;
            _taskServices = taskServices;
            UserId = _userService.LoadLoggedIn();
        }


        [BindProperty]
        public int UserId { get; set; }
        [BindProperty]
        public bool CompleteCheck { get; set; }

        public List<TasksModel> tasks { get; set; }

        public void OnGet()
        {
            tasks = _taskServices.usersTask(UserId);
        }
    }
}
