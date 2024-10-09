using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Models;

namespace PersoApp.Pages
{
    public class LocationsModel : PageModel
    {

        public PersoAppDBContext db;

        public LocationsModel(PersoAppDBContext db)
        {
            this.db = db;
        }
        public IEnumerable<Location> Locations { get; set; } = new List<Location>();
        public void OnGet()
        {

            Locations = db.Locations;
        }
    }
}
