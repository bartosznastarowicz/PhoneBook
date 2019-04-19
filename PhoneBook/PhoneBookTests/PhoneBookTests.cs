namespace PhoneBookTests
{
    using System;
    using NUnit.Framework;
    using PhoneBook;

    [TestFixture]
    public class PhoneBookTests
    {
        private Employee employee1, employee2, employee3, employee4;

        [SetUp]
        public void SetUp()
        {
            this.employee1 = new Employee("Bartek", "En", 123, Departments.Koszalin, "00-4567");
            this.employee2 = new Employee("Ania", "Zar", 456, Departments.Wroclaw, "00-1597");
            this.employee3 = new Employee("Sylwek", "Mroz", 789, Departments.Szczecin, "00-1999");
            this.employee4 = new Employee("Marcin", "Rek", 963, Departments.Szczecin, "00-1588");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Testing finished.");
        }

        [Test]
        public void Employee_Check_All_Info()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.employee1.Name, Is.EqualTo("Bartek"));
                Assert.That(this.employee1.SurName, Is.EqualTo("En"));
                Assert.That(this.employee1.BadgeID, Is.EqualTo(123));
                Assert.That(this.employee1.Department, Is.EqualTo(Departments.Koszalin));
                Assert.That(this.employee1.InternalPhone, Is.EqualTo("00-4567"));
            });           
        }

        [Test]
        public void Employee_Check_Basic_Print()
        {
            var employeeNameAndDepartment = this.employee1.Name + " " + this.employee1.Department;
            Assert.That(this.employee1.PrintBasicInfo(), Is.EqualTo(employeeNameAndDepartment));
        }

        [Test]
        public void Employee_Check_Full_Print()
        {
            var employeeFullData = this.employee1.Name + " " + this.employee1.SurName + " " + this.employee1.BadgeID.ToString() + " " + this.employee1.Department + " " + this.employee1.InternalPhone;
            Assert.That(this.employee1.PrintFullInfo(), Is.EqualTo(employeeFullData));
        }

        [Test]
        public void PhoneBook_Check_Department()
        {
            var phoneBook = new PhoneBook();

            phoneBook.AddEmployee(this.employee1);
            phoneBook.AddEmployee(this.employee2);
            phoneBook.AddEmployee(this.employee3);
            phoneBook.AddEmployee(this.employee4);

            foreach (var element in phoneBook.EmployeesFromLocation(Departments.Szczecin))
                {
                Console.WriteLine(element.Name);
                }
            }
        }
    }
