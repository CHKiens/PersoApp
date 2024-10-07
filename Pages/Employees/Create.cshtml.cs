using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PersoApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        public EmployeeInfo employeeInfo = new EmployeeInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            employeeInfo.Name = Request.Form["name"];
            employeeInfo.email = Request.Form["email"];
            employeeInfo.phone = Request.Form["phone"];
            employeeInfo.address = Request.Form["address"];

            if (string.IsNullOrEmpty(employeeInfo.Name) || string.IsNullOrEmpty(employeeInfo.email) ||
                string.IsNullOrEmpty(employeeInfo.phone) || string.IsNullOrEmpty(employeeInfo.address))
            {
                errorMessage = "All fields are required.";
                return;
            }

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=persoapp;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO employees (name, email, phone, address) VALUES (@name, @email, @phone, @address)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", employeeInfo.Name);
                        command.Parameters.AddWithValue("@email", employeeInfo.email);
                        command.Parameters.AddWithValue("@phone", employeeInfo.phone);
                        command.Parameters.AddWithValue("@address", employeeInfo.address);

                        command.ExecuteNonQuery();
                    }
                }

                employeeInfo.Name = "";
                employeeInfo.email = "";
                employeeInfo.phone = "";
                employeeInfo.address = "";
                successMessage = "Employee added successfully.";

                Response.Redirect("/Employees/Index");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}

