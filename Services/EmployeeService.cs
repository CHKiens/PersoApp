using Microsoft.EntityFrameworkCore;
using PersoApp.Interfaces;
using PersoApp.Models;

namespace PersoApp.Services {
    public class EmployeeService :IEmployee {

        private PersoAppDBContext _Context;
        public EmployeeService(PersoAppDBContext context)
        {
            _Context = context;
        }

        public void AddEmployee(Employee employee)
        {
            _Context.Add(employee);
            _Context.SaveChanges();
        }
    }
}
