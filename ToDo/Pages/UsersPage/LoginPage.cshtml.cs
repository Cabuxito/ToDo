using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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
        [BindProperty, Required]
        public string? Username { get; set; }
        [BindProperty, Required]
        public string? Password { get; set; }
        
        public IActionResult OnPost()
        {
            _myService.GetUserIdByUsername(Username, Password);
            if (ModelState.IsValid)
            {
                return RedirectToPage("/UsersPage/SuccesRedirect");
            }
            else
            {
                return RedirectToPage("/UsersPage/LoginPage");
            }
        }
    }
}
