using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Pages
{
    public class LocationsModel : PageModel
    {

        
        public ILocation repo;
        public LocationsModel( ILocation repo)
        {
            this.repo = repo;
        }
        public IEnumerable<Location> Locations { get; set; } = new List<Location>();
        public void OnGet()
        {
            Locations = repo.GetAllLocations();
        }
    }
}
