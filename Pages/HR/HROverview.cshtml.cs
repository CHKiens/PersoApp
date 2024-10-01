using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Pages
{
    public class HROverviewModel : PageModel
    {
        [BindProperty]
        public IEmployee employee { get; set; }
        public List<IEmployee> employees { get; set; }
        public void OnGet()
        {
        }
    }
}
