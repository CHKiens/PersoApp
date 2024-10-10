using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Pages.LocationsPages
{
    public class EditLocationModel : PageModel
    {
        private ILocation repo;
        [BindProperty]
        public Location Location { get; set; }
        public EditLocationModel (ILocation repo)
        {
            this.repo = repo;
        }
        public IActionResult OnGet(int Id)
        {
            this.Location = repo.GetLocation(Id);
            if (Location == null)
            {
                return null;
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdateLocation(Location);
            return RedirectToPage("/Locations");
        }
    }
}
