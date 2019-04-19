namespace PhoneBook
{
    using System;

    public class Program
    {
        private static PhoneBook myPhoneBook = new PhoneBook();

        public static void Main(string[] args)
        {
            SeedPhoneBookWithData();
            Console.WriteLine("Phone book");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Write AddEmployee, Badge, Location, Name or Quit");
            string userInput;
            while (true)
            {
                userInput = Console.ReadLine();
                var commands = userInput.Split(' ');
                switch (commands[0])
                {
                    case "Location":
                        AllEmployeesInLocation(commands[1]);
                        break;
                    case "Badge":
                        DisplayEmployeeByBadgeId(commands[1]);
                        break;
                    case "Name":
                        DisplayEmployeesByName(commands[1]);
                        break;
                    case "AddEmployee":
                        AddNewEmployee();
                        break;
                    case "Quit":
                        return;
                    default:
                        Console.WriteLine("Unknown value");
                        break;
                }               
            }
        }

        public static void SeedPhoneBookWithData()
        {
            var employee = new Employee("Bartek", "En", 123, Departments.Koszalin, "00-4567");
            var employee2 = new Employee("Bartek", "Zar", 456, Departments.Wroclaw, "00-1597");
            var employee3 = new Employee("Bartek", "Mroz", 789, Departments.Szczecin, "00-1999");
            var employee4 = new Employee("Marcin", "Rek", 963, Departments.Szczecin, "00-1588");

            myPhoneBook.AddEmployee(employee);
            myPhoneBook.AddEmployee(employee2);
            myPhoneBook.AddEmployee(employee3);
            myPhoneBook.AddEmployee(employee4);
        }
        
        public static void DisplayEmployeeByBadgeId(string badgeId)
        {
            int parsedBadgeId = int.Parse(badgeId);
            Console.WriteLine(myPhoneBook.GetEmployeeByBadgeId(parsedBadgeId).PrintFullInfo());
        }

        private static void AllEmployeesInLocation(string location)
        {
            Departments parseDepartment;
            Enum.TryParse(location, out parseDepartment);
            var employeesFromLocation = myPhoneBook.EmployeesFromLocation(parseDepartment);
            string result = string.Empty;
            employeesFromLocation.ForEach(e => result += $"{ e.PrintFullInfo() }");
            Console.WriteLine(result);
        }

        private static void DisplayEmployeesByName(string name)
        {
            var employeesByName = myPhoneBook.GetEmployeeByName(name);
            string result = string.Empty;
            employeesByName.ForEach(e => result += $"{ e.PrintFullInfo() }\n");
            Console.WriteLine(result);
        }

        private static void AddNewEmployee()
        {
            Console.WriteLine("Write personal details for new Employee:");
            Console.WriteLine("Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Last name:");
            var surName = Console.ReadLine();
            Console.WriteLine("Badge ID:");
            var badgeID = Console.ReadLine();
            Console.WriteLine("Department:");
            var department = Console.ReadLine();
            Console.WriteLine("Internal phone number:");
            var internalPhone = Console.ReadLine();

            int badge;
            int.TryParse(badgeID, out badge);

            Departments dep = (Departments)Enum.Parse(typeof(Departments), department);

            Employee employee = new Employee(name, surName, badge, dep, internalPhone);
            myPhoneBook.AddEmployee(employee);
        }
    }
}