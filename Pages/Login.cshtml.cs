using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersoApp.Repository;

namespace PersoApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var user = UserRepository.ValidateUser(Username, Password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToPage("/Index"); 
            }
            ErrorMessage = "Invalid username or password.";
            return Page(); 
        }
    }
}
