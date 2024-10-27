
using PersoApp.Interfaces;
using PersoApp.Models; 
using OfficeOpenXml;  
using iTextSharp.text;  
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace PersoApp.Services {
    public class EmployeeService : IEmployee {
        private readonly PersoAppDBContext _dbContext;

        public EmployeeService(PersoAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.Include(e => e.Location).ToList(); 
        }

      
        public void DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }

        public void GenerateExcelReport(List<Employee> employees)
        {
            
        }

        public void GeneratePdfReport(List<Employee> employees)
        {
            
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public Employee GetEmployeeById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }
        public void EditEmployee(Employee employee)
        {
            _dbContext.Update(employee);
            _dbContext.SaveChanges();
        }
    }

}