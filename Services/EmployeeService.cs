using PersoApp.Interfaces;
using PersoApp.Models; // Employee modellen
using OfficeOpenXml;  // Til Excel
using iTextSharp.text;  // Til PDF
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore; // Til Include()

namespace PersoApp.Services {
    public class EmployeeService : IEmployee {
        private readonly PersoAppDBContext _dbContext;

        public EmployeeService(PersoAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Metode til at hente alle medarbejdere fra databasen
        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.Include(e => e.Location).ToList(); // Hent medarbejdere inkl. lokation
        }

        // Metode til at generere Excel-rapport
        public void GenerateExcelReport(List<Employee> employees)
        {
            try
            {
                // Gem Excel-filen i wwwroot-mappen
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MedarbejderRapport.xlsx");

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Medarbejder Rapport");
                    worksheet.Cells[1, 1].Value = "Navn";
                    worksheet.Cells[1, 2].Value = "Rolle";
                    worksheet.Cells[1, 3].Value = "Løn";
                    worksheet.Cells[1, 4].Value = "Lokation";

                    int row = 2;
                    foreach (var employee in employees)
                    {
                        worksheet.Cells[row, 1].Value = employee.Name;
                        worksheet.Cells[row, 2].Value = employee.Role;
                        worksheet.Cells[row, 3].Value = employee.Salary;
                        worksheet.Cells[row, 4].Value = employee.Location?.City; // Lokationens by
                        row++;
                    }

                    // Gem Excel-filen i den angivne sti
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                }

                if (!File.Exists(filePath))
                {
                    throw new Exception("Excel-filen blev ikke oprettet korrekt.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl under Excel-generering: {ex.Message}");
                throw;
            }
        }

        // Metode til at generere PDF-rapport
        public void GeneratePdfReport(List<Employee> employees)
        {
            try
            {
                // Gem PDF'en i wwwroot-mappen
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MedarbejderRapport.pdf");

                using (Document document = new Document())
                {
                    PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                    document.Open();

                    // Tilføj overskrift til PDF-rapporten
                    document.Add(new Paragraph("Medarbejderrapport"));
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("Genereret dato: " + DateTime.Now.ToString()));
                    document.Add(new Paragraph(" "));

                    // Tilføj tabel til at vise medarbejderdata
                    PdfPTable table = new PdfPTable(4); // Fire kolonner: Navn, Rolle, Løn, Lokation
                    table.AddCell("Navn");
                    table.AddCell("Rolle");
                    table.AddCell("Løn");
                    table.AddCell("Lokation");

                    // Tilføj rækker med medarbejderdata
                    foreach (var employee in employees)
                    {
                        table.AddCell(employee.Name);
                        table.AddCell(employee.Role);
                        table.AddCell(employee.Salary.ToString("C")); // Formatér løn som valuta
                        table.AddCell(employee.Location?.City ?? "Ukendt"); // Lokationens by, fallback til "Ukendt"
                    }

                    // Tilføj tabel til dokumentet
                    document.Add(table);

                    document.Close();
                }

                if (!File.Exists(filePath))
                {
                    throw new Exception("PDF-filen blev ikke oprettet korrekt.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl under PDF-generering: {ex.Message}");
                throw;
            }
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public Employee GetEmployeeById(int? id)
        {
            return _dbContext.Employees.FirstOrDefault();
        }
    }
}