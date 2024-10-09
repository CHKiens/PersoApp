using PersoApp.Models;

namespace PersoApp.Repository
{
    public class UserRepository
    {
        // Laver liste med brugere. Brugernavn og kode er hardcoded her, men kunne sagtens kobles på databasen, evt. integreres med vores employee liste, m. mail som login.
        public static List<User> Users = new List<User>
    {
        new User { Id = 1, Username = "hr", Password = "password", Role = "HR" },
        new User { Id = 2, Username = "employee", Password = "password", Role = "Employee" }
    };

        public static User ValidateUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }

}
