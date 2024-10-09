using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Pages.EmployeePages
{
    public class CreateEmployeeModel : PageModel
    {
        private IEmployee repository;
        private ILocation locationRepo;
        [BindProperty]
        public Employee employee { get; set; }
        public List<Location> locations { get; set; }


        public CreateEmployeeModel(IEmployee repo, ILocation locationRepo)
        {
            repository = repo;
            this.locationRepo = locationRepo;
        }

        public void OnGet()
        {
            locations = locationRepo.GetAllLocations();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.AddEmployee(employee);
            return RedirectToPage("/Employees");

        }
    }
}
