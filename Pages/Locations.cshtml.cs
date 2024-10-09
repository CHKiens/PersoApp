using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Interfaces;
using PersoApp.Models;
using PersoApp.Services;

namespace PersoApp.Pages
{
    public class LocationsModel : PageModel
    {
        public ILocation repo { get; set; }
        public List<Location> Locations { get; set; }
        public LocationsModel(ILocation repo)
        {
            this.repo = repo;
        }
        public void OnGet()
        {
            Locations = repo.GetAllLocations();
        }
    }
}
