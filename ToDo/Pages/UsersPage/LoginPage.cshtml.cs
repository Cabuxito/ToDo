using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Models;
using ToDo.Service.Services;

namespace ToDo.Pages.UsersPage
{
    public class LoginPageModel : PageModel
    {
        private readonly IUserService _myService;

        public LoginPageModel(IUserService myService)
        {
            _myService = myService;
        }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public UsersModel loggedId { get; set; }
        

        public IActionResult OnPost()
        {
            bool isValid = _myService.LoginValidation(Username, Password);
            loggedId = _myService.GetUserIdByUsername(Username, Password);
            if (isValid == true)
            {
                return RedirectToPage($"/UsersPage/UserPrivatePage/{loggedId.User_Id}");
            }
            else
            {
                return RedirectToPage("/UsersPage/LoginPage");
            }
        }
    }
}
