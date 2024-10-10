using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersoApp.Interfaces;
using PersoApp.Models;
using PersoApp.Services; // Tilføj reference til EmployeeService

namespace PersoApp.Pages
{
    public class EmployeesModel : PageModel
    {

       // public PersoAppDBContext db; Tænker ikke vi behøver reference til DB da det gerne skulle hentes gennem vores service. Tester lige når jeg kommer hjem
       
       //private readonly PersoAppDBContext db;
        public IEmployee eRepo;
        public ILocation iRepo;

        [BindProperty(SupportsGet = true)]
        public int? SelectedLocationId { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Location> Locations { get; set; }

        // Constructor til Dependency Injection
        public EmployeesModel(IEmployee eRepo, ILocation iRepo)// PersoAppDBContext db) 
        {
            this.iRepo = iRepo;
            this.eRepo = eRepo;
          //  this.db = db;         
        }

        // Metode til at hente medarbejderdata, når siden indlæses
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

        // Metode til at generere rapporter (Excel eller PDF)
        public IActionResult OnGetGenerateReport(string format)
        {
            try
            {
                Console.WriteLine($"Modtog anmodning om at generere rapport i format: {format}");

                var employees = eRepo.GetAllEmployees();

                if (format == "excel")
                {
                    Console.WriteLine("Genererer Excel-rapport...");
                    eRepo.GenerateExcelReport(employees);

                    // Brug den korrekte sti til at læse Excel-filen fra wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MedarbejderRapport.xlsx");

                    // Returner filen med den korrekte filtype og filnavn
                    return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MedarbejderRapport.xlsx");
                }
                else if (format == "pdf")
                {
                    Console.WriteLine("Genererer PDF-rapport...");
                    eRepo.GeneratePdfReport(employees);

                    // Brug den korrekte sti til at læse PDF-filen fra wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MedarbejderRapport.pdf");
                    return PhysicalFile(filePath, "application/pdf", "MedarbejderRapport.pdf");
                }

                Console.WriteLine("Ugyldigt format modtaget.");
                return BadRequest("Ugyldigt format");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl under generering af rapport: {ex.Message}");
                return StatusCode(500, $"Der opstod en fejl: {ex.Message}");
            }
        }
    }
}
