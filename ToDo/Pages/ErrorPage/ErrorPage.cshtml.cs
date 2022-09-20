using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ToDo.Pages.ErrorPage
{
    public class ErrorPageModel : PageModel
    {
        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
