using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Models;
using ToDo.Service.Services;

namespace ToDo.Pages
{
    public class UserPageModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ITaskServices _taskServices;
        [BindProperty]
        public int UserId { get; set; }

        public UserPageModel(IUserService userService, ITaskServices taskServices)
        {
            _userService = userService;
            _taskServices = taskServices;
        }


        [BindProperty]
        public string UserChoice { get; set; }

        public List<TasksModel> Tasks { get; set; }
        public UsersModel User { get; set; }
        public bool UserCheck { get; set; }
        public bool TasksCheck { get; set; }
        [BindProperty]
        public bool CompletedCheck { get; set; }


        public void OnPost()
        {
            switch (UserChoice)
            {
                case "My Tasks":
                    TasksCheck = true;
                    Tasks = _taskServices.UsersTask(_userService.LoggedIndId());
                    break;
                case "My Profile":
                    UserCheck = true;
                    User = _userService.LoadLoggedIn();
                    break;
                default:
                    break;
            }
        }
    }
}
