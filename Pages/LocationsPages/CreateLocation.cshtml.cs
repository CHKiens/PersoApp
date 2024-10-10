using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Interfaces;
using PersoApp.Models;
using PersoApp.Services;

namespace PersoApp.Pages.LocationsPages
{
    public class CreateLocationModel : PageModel
    {
        private ILocation repo;
        [BindProperty]
        public Location Location { get; set; }
        public CreateLocationModel(ILocation locationRepo)
        {
            this.repo = locationRepo;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.AddLocation(location);
            return RedirectToPage("/Locations");
        }
    }
}
