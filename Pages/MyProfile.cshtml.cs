using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using PersoApp.Models;
using PersoApp.Repository;
using System.Collections.Generic;
using PersoApp.Services;
using PersoApp.Interfaces;

namespace PersoApp.Pages
{
    public class MyProfileModel : PageModel
    {
        public int? Id { get; set; }
        private IEmployee eRepo;
        private ILocation iRepo;
        public Employee Employee { get; set; }
        public MyProfileModel(IEmployee eRepo, ILocation iRepo)
        {
            this.eRepo = eRepo;
            this.iRepo = iRepo;
        }

        public void OnGet()
        {

            Id = HttpContext.Session.GetInt32("Id");

            if (Id.HasValue)
            {
                Employee = eRepo.GetEmployeeById(Id);
                Employee.Location = iRepo.GetLocation(Employee.LocationId);

                if (Employee == null)
                {
                    RedirectToPage("/Error");
                }
            }
            else
            {
                RedirectToPage("/Login");
            }

        }
    }
}
