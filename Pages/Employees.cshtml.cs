using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersoApp.Models;

namespace PersoApp.Pages
{
    public class EmployeesModel : PageModel
    {

        public PersoAppDBContext db;

        [BindProperty(SupportsGet = true)]
        public int? SelectedLocationId { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Location> Locations { get; set; }
        public EmployeesModel(PersoAppDBContext db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            Locations = db.Locations.ToList();
            if (SelectedLocationId > 0)
            {
                Employees = db.Employees
                    .Where(e => e.LocationId == SelectedLocationId)
                    .ToList();
            }
            else
            {
                Employees = db.Employees.ToList();
            }
        }
    }
}
