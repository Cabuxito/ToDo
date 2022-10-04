using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Services;

namespace ToDo.Pages.UsersPage
{
    [BindProperties]
    public class CreateUserModel : PageModel
    {
        private readonly IUserService _userService;
        public CreateUserModel(IUserService userService)
        {
            _userService = userService;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool CreateSucces { get; set; }

        public IActionResult OnPost()
        {
            _userService.NewUser(Username, Password, FirstName, LastName, Email);
            return RedirectToPage("/UsersPage/LoginPage");
        }
    }
}
