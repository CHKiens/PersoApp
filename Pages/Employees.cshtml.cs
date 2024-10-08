using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersoApp.Models;

namespace PersoApp.Pages
{
    public class EmployeesModel : PageModel
    {

        public PersoAppDBContext db;

        public EmployeesModel(PersoAppDBContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
        public void OnGet()
        {
            Employees = db.Employees.Include(e => e.Location).ToList();
                
        }
    }
}
