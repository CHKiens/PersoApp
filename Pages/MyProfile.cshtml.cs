using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using PersoApp.Models;
using PersoApp.Repository;
using System.Collections.Generic;

namespace PersoApp.Pages
{
    public class MyProfileModel : PageModel
    {
        public int? Id { get; set; }
        public PersoAppDBContext DB { get; }
        public Employee Employee { get; set; }
        public MyProfileModel(PersoAppDBContext dB)
        {
            DB = dB;
        }

        public void OnGet()
        {

            Id = HttpContext.Session.GetInt32("Id");

            if (Id.HasValue)
            {
                Employee = DB.Employees.Find(Id.Value);
                Employee.Location = DB.Locations.Find(Employee.LocationId);

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
