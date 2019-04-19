namespace PhoneBook
{
    using System.Collections.Generic;
    using System.Linq;

    public class PhoneBook
    {
        private List<Employee> allEmployees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            this.allEmployees.Add(employee);
        }

        public List<Employee> EmployeesFromLocation(Departments department)
        {
            return this.allEmployees.Where(x => x.Department == department).ToList();
        }
        
        public Employee GetEmployeeByBadgeId(int badgeId)
        {
            return this.allEmployees.Where(id => id.BadgeID == badgeId).First();
        }

        public List<Employee> GetEmployeeByName(string name)
        {
            return this.allEmployees.Where(n => n.Name == name).ToList();
        }


    }
}
