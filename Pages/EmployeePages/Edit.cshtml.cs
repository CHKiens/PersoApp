using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Pages.EmployeePages
{
    public class EditModel : PageModel
    {
        private readonly IEmployee _context;
        private ILocation locationRepo;

        public EditModel(IEmployee context, ILocation locationRepo)
        {
            _context = context;
            this.locationRepo = locationRepo;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public List<Location> locations { get; set; }

        public IActionResult OnGet(int? id)
        {
            locations = locationRepo.GetAllLocations();

            this.Employee =  _context.GetEmployeeById(id);
           
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.EditEmployee(this.Employee);

            return RedirectToPage("/Employees");
        }
    }
}
