using PersoApp.Models;

namespace PersoApp.Repository
{
    public class UserRepository
    {
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
