using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Pages.LocationsPages
{
    public class CreateLocationModel : PageModel
    {
        private ILocation locationRepo;
        [BindProperty]
        public Location Location { get; set; }
        public CreateLocationModel(ILocation locationRepo)
        {
            this.locationRepo = locationRepo;
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

            locationRepo.AddLocation(location);
            return RedirectToPage("/Locations");
        }
    }
}
