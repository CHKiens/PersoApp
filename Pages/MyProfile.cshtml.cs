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
            // Retrieve the user ID from the session
            Id = HttpContext.Session.GetInt32("Id");

            if (Id.HasValue)
            {
                // Try to find the employee by ID
                Employee = DB.Employees.Find(Id.Value);

                if (Employee == null)
                {
                    // Handle case where Employee is not found
                    RedirectToPage("/Error");
                }
            }
            else
            {
                // User is not logged in, redirect to login page
                RedirectToPage("/Login");
            }

        }
    }
}
