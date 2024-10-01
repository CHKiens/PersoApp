using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PersoApp.Interfaces;

namespace PersoApp.Pages.HR
{
    public class CreatNewEmployeeModel : PageModel
    {
        

        [BindProperty] public IEmployee Employee { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    repo.AddEvent(Event);
        //    return RedirectToPage("/Events/AdminPage");
        //}
    }
}
