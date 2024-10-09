using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersoApp.Interfaces;
using PersoApp.Models;
using PersoApp.Services;

namespace PersoApp.Pages
{
    public class EmployeesModel : PageModel
    {

        public IEmployee eRepo;
        public ILocation iRepo;
        [BindProperty(SupportsGet = true)]
        public int? SelectedLocationId { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Location> Locations { get; set; }
        public EmployeesModel(IEmployee eRepo, ILocation iRepo)
        {
            this.iRepo = iRepo;
            this.eRepo = eRepo;
        }

        public void OnGet()
        {
            Locations = iRepo.GetAllLocations();
            if (SelectedLocationId > 0)
            {
                Employees = eRepo.GetAllEmployees()
                    .Where(e => e.LocationId == SelectedLocationId)
                    .ToList();
            }
            else
            {
                Employees = eRepo.GetAllEmployees();
            }
        }
    }
}
