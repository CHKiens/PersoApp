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
        private readonly PersoAppDBContext db;
        private readonly EmployeeService _employeeService;


        // Dependency Injection af EmployeeService og DbContext
        public EmployeesModel(PersoAppDBContext db, EmployeeService employeeService)
        {
            this.db = db;
            _employeeService = employeeService;
        }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();

        // Metode til at hente medarbejderdata, når siden indlæses
        public void OnGet()
        {
            Employees = db.Employees.Include(e => e.Location).ToList();
        }

        // Metode til at generere rapporter (Excel eller PDF)
        public IActionResult OnGetGenerateReport(string format)
        {
            try
            {
                Console.WriteLine($"Modtog anmodning om at generere rapport i format: {format}");

                var employees = _employeeService.GetAllEmployees();

                if (format == "excel")
                {
                    Console.WriteLine("Genererer Excel-rapport...");
                    _employeeService.GenerateExcelReport(employees);

                    // Brug den korrekte sti til at læse Excel-filen fra wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MedarbejderRapport.xlsx");

                    // Returner filen med den korrekte filtype og filnavn
                    return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MedarbejderRapport.xlsx");
                }
                else if (format == "pdf")
                {
                    Console.WriteLine("Genererer PDF-rapport...");
                    _employeeService.GeneratePdfReport(employees);

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

