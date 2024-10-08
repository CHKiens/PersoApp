using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PersoApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public List<EmployeeInfo> listEmployees = new List<EmployeeInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=persoapp;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM employees";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeInfo info = new EmployeeInfo();
                                info.id = reader.GetInt32(0).ToString();
                                info.Name = reader.GetString(1);
                                info.email = reader.GetString(2);
                                info.phone = reader.GetString(3);
                                info.address = reader.GetString(4);
                                info.created_at = reader.GetDateTime(5).ToString("yyyy-MM-dd");

                                listEmployees.Add(info);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class EmployeeInfo
    {
        public String id { get; set; }
        public String Name { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String address { get; set; }
        public String created_at { get; set; }
    }
}


