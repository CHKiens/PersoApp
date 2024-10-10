using PersoApp.Models;

namespace PersoApp.Interfaces {
    public interface IEmployee {
        public void AddEmployee(Employee employee);
        public List<Employee> GetAllEmployees();

        public Employee GetEmployeeById(int? id);
    }
}
