using PersoApp.Models;

namespace PersoApp.Interfaces {
    public interface IEmployee {
        public void AddEmployee(Employee employee);
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int? id);
        public void GenerateExcelReport(List<Employee> employees);
        public void GeneratePdfReport(List<Employee> employees);
        public void DeleteEmployee(int id);
        void EditEmployee(Employee employee);
    }
}