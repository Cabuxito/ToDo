using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Service.Services;

namespace ToDo.Pages.UsersPage
{
    public class SuccesRedirectModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("/UsersPage/UserPrivatePage");
        }
    }
}
