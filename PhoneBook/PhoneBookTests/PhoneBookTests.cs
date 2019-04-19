namespace PhoneBookTests
{
    using System;
    using NUnit.Framework;
    using PhoneBook;

    [TestFixture]
    public class PhoneBookTests
    {
        [Test]
        public void Employee_Check_All_Info()
        {
            var employee = new Employee("Emma", "Mazuni", 123, Departments.Koszalin, "00-4567");
            Assert.Multiple(() =>
            {
                Assert.That(employee.Name, Is.EqualTo("Emma"));
                Assert.That(employee.SurName, Is.EqualTo("Mazuni"));
                Assert.That(employee.BadgeID, Is.EqualTo(123));
                Assert.That(employee.Department, Is.EqualTo(Departments.Koszalin));
                Assert.That(employee.InternalPhone, Is.EqualTo("00-4567"));
            });           
        }

        [Test]
        public void Employee_Check_Basic_Print()
        {
            var employee = new Employee("Emma", "Mazuni", 123, Departments.Koszalin, "00-4567");
            var employeeNameAndDepartment = employee.Name + " " + employee.Department;
            Assert.That(employee.PrintBasicInfo(), Is.EqualTo(employeeNameAndDepartment));
        }

        [Test]
        public void Employee_Check_Full_Print()
        {
            var employee = new Employee("Emma", "Mazuni", 123, Departments.Koszalin, "00-4567");
            var employeeFullData = employee.Name + " " + employee.SurName + " " + employee.BadgeID.ToString() + " " + employee.Department + " " + employee.InternalPhone;
            Assert.That(employee.PrintFullInfo(), Is.EqualTo(employeeFullData));
        }

        [Test]
        public void PhoneBook_Add_Employees()
        {
            var employee = new Employee("Bartek", "En", 123, Departments.Koszalin, "00-4567");
            var employee2 = new Employee("Ania", "Zar", 456, Departments.Wroclaw, "00-1597");
            var employee3 = new Employee("Sylwek", "Mroz", 789, Departments.Szczecin, "00-1999");
            var employee4 = new Employee("Marcin", "Rek", 963, Departments.Szczecin, "00-1588");

            var phoneBook = new PhoneBook();

            phoneBook.AddEmployee(employee);
            phoneBook.AddEmployee(employee2);
            phoneBook.AddEmployee(employee3);
            phoneBook.AddEmployee(employee4);

            foreach (var element in phoneBook.EmployeesFromLocation(Departments.Szczecin))
                {
                Console.WriteLine(element.Name);
                }
            }
        }
    }
