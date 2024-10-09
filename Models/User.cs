namespace PersoApp.Models
{
    public class User
    {
        // User som kan logge på hjemmesiden. Tænker at man kunne lave noget integration med employeelisten, evt. koble den på en medarbejer via en mail. 

        public string Username { get; set; }
        public string Password { get; set; } 
        public string Role { get; set; } 
        public int Id { get; set; }
    }
}
