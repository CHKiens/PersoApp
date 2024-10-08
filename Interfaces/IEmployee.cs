using PersoApp.Models;

namespace PersoApp.Interfaces {
    public class IEmployee {

        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public double Salary { get; set; }

        public DateTime DateOfEmployment { get; set; }
        public Location Location { get; set; }
        public double AbsenceInHours { get; set; }
        public double ScheduledHours { get; set; } //pr. år, fuldtid = 1650
    }
}
