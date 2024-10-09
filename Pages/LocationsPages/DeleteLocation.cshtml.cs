using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Pages.LocationsPages
{
    public class DeleteLocationModel : PageModel
    {
        private ILocation repo;
        [BindProperty]
        public Location Location { get; set; }
        public DeleteLocationModel(ILocation repo)
        {
            this.repo = repo;
        }

        public void OnGet(int id)
        {
            Location = repo.GetLocation(id);
        }
        public IActionResult OnPost(int id)
        {
            if (Location == null) 
            {
                return null;
            }
            repo.DeleteLocation(id);
            return RedirectToPage("/Locations");
        }

    }
}
