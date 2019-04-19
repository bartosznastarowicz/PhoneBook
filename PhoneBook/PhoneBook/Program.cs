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
            Console.WriteLine("Write Location, Badge or Quit");
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
            var employee2 = new Employee("Ania", "Zar", 456, Departments.Wroclaw, "00-1597");
            var employee3 = new Employee("Sylwek", "Mroz", 789, Departments.Szczecin, "00-1999");
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
            employeesFromLocation.ForEach(e => result += $"{ e.PrintFullInfo()}");
            Console.WriteLine(result);
        }
    }
}