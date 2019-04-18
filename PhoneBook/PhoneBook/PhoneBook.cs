﻿namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhoneBook
    {
        private List<Employee> allEmployees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            this.allEmployees.Add(employee);
        }

        public List<Employee> EmployeesFromLocation(Departments dep)
        {
            return this.allEmployees.Where(x => x.Department == dep).ToList();
        }
    }
}
