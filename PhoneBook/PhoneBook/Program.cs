namespace PhoneBook
{
    using System;
    using System.Linq;

    public class Program
    {
        private static PhoneBook myPhoneBook = new PhoneBook();

        public static void Main(string[] args)
        {
            SeedPhoneBookWithData();
            Console.WriteLine("Phone book");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Write AddEmployee, Badge, Location, Name or Quit");
            while (true)
            {
                var commands = Console.ReadLine().Split(' ');
                var command = commands[0].ToUpper();
                while (command == "CLEAR")
                {
                    Console.Clear();
                    Console.WriteLine("Phone book");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Write AddEmployee, Badge, Location, Name or Quit");
                    command = Console.ReadLine();
                }

                while (command != "ADDEMPLOYEE" && commands.Length != 2)
                {
                    switch (command)
                    {
                        case "LOCATION":
                            Console.WriteLine("Missing name of the location!\nType command once again with choosen location, splitted by spacebar.");
                            commands = Console.ReadLine().Split(' ');
                            command = commands[0].ToUpper();
                            break;
                        case "BADGE":
                            Console.WriteLine("Missing number of badge!\nType command once again with the number (5 digits), splitted by spacebar.");
                            commands = Console.ReadLine().Split(' ');
                            command = commands[0].ToUpper();
                            break;
                        case "NAME":
                            Console.WriteLine("Missing name of the employee!\nType command once again with choosen name, splitted by spacebar.");
                            commands = Console.ReadLine().Split(' ');
                            command = commands[0].ToUpper();
                            break;
                        case "QUIT":
                            return;
                    }
                }

                switch (command)
                {
                    case "LOCATION":
                        while (CheckIfLocationExist(commands[1]) != true)
                        {
                            Console.WriteLine("Chosen location does not exist!\nChoose one of the followed: Koszalin, Krakow, Szczecin, Wroclaw, ZielonaGora.");
                            commands[1] = Console.ReadLine().ToUpper();
                        }

                        AllEmployeesInLocation(commands[1]);
                        break;
                    case "BADGE":
                        while (CheckIfBadgeIsCorrect(commands[1]) != true)
                        {
                            Console.WriteLine("Choosen badge ID does not conform the pattern! Badge ID should contains 5 digits.\nType new badge ID.");
                            commands[1] = Console.ReadLine();
                        }

                        DisplayEmployeeByBadgeId(commands[1]);
                        break;
                    case "NAME":
                        DisplayEmployeesByName(commands[1]);
                        break;
                    case "ADDEMPLOYEE":
                        AddNewEmployee();
                        break;
                    default:
                        Console.WriteLine("Unknown command!\nUse one of the available commands: AddEmploye, Badge, Location, Name or Quit");
                        break;
                } 
            }
        }

        private static void SeedPhoneBookWithData()
        {
            var employee = new Employee("Bartek", "En", 12345, Departments.Koszalin, "123456789");
            var employee2 = new Employee("Bartek", "Zar", 45678, Departments.Wroclaw, "890890890");
            var employee3 = new Employee("Bartek", "Mroz", 78991, Departments.Szczecin, "123123123");
            var employee4 = new Employee("Marcin", "Rek", 96345, Departments.Szczecin, "456456456");

            myPhoneBook.AddEmployee(employee);
            myPhoneBook.AddEmployee(employee2);
            myPhoneBook.AddEmployee(employee3);
            myPhoneBook.AddEmployee(employee4);
        }

        private static bool CheckIfBadgeIsCorrect(string str)
        {
            if (CheckIfContainsOnlyDigits(str) && str.Length == 5)
            {
                return true;
            }

            return false;
        }

        private static bool CheckIfInternalPhoneNumberIsCorrect(string str)
        {
            if (CheckIfContainsOnlyDigits(str) && str.Length == 9)
            {
                return true;
            }

            return false;
        }

        private static bool CheckIfContainsOnlyDigits(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckIfLocationExist(string str)
        {
            if (Enum.IsDefined(typeof(Departments), str))
            {
                return true;
            }

            return false;
        }

        private static void DisplayEmployeeByBadgeId(string badgeId)
        {
            int parsedBadgeId;
            while (!int.TryParse(badgeId, out parsedBadgeId) || badgeId.Length != 5)
            {
                Console.WriteLine("BadgeID should have only 5 digits.\nType new BadgeID.");
                badgeId = Console.ReadLine();
            }

            try
            {
                Console.WriteLine(myPhoneBook.GetEmployeeByBadgeId(parsedBadgeId).PrintFullInfo());
                Console.WriteLine("\n");
            }
            catch
            {
                Console.WriteLine($"Could not find anyone with {badgeId} BadgeID.");
            }
        }

        private static void AllEmployeesInLocation(string location)
        {
            Enum.TryParse(location, out Departments parseDepartment);
            var employeesFromLocation = myPhoneBook.EmployeesFromLocation(parseDepartment);
            string result = string.Empty;
            int i = 1;
            employeesFromLocation.ForEach(e => result += $"{ i++ } { e.PrintFullInfo() }\n");
            Console.WriteLine("\n");
            if (result.Length == 0)
            {
                Console.WriteLine("There is noone who is working there.");
            }
            else
            {
                Console.WriteLine(result);
            }
        }

        private static void DisplayEmployeesByName(string name)
        {
            var employeesByName = myPhoneBook.GetEmployeeByName(name);
            string result = string.Empty;
            int i = 1;
            employeesByName.ForEach(e => result += $"{ i++ } { e.PrintFullInfo() }\n");
            Console.WriteLine("\n");
            if (result.Length == 0)
            {
                Console.WriteLine("There is noone with that name.");
            }
            else
            {
                Console.WriteLine(result);
            }
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
            while (CheckIfBadgeIsCorrect(badgeID) != true)
            {
                Console.WriteLine("Badge ID should contain 5 digits!");
                badgeID = Console.ReadLine();
            }

            Console.WriteLine("Location:");
            var department = Console.ReadLine();
            while (CheckIfLocationExist(department) != true)
            {
                Console.WriteLine("Chosen location does not exist!\nChoose one of the followed: Koszalin, Krakow, Szczecin, Wroclaw, ZielonaGora.");
                department = Console.ReadLine();
            }

            Console.WriteLine("Internal phone number:");
            var internalPhone = Console.ReadLine();
            while (CheckIfInternalPhoneNumberIsCorrect(internalPhone) != true)
            {
                Console.WriteLine("Phone number should contain 9 digits!");
                internalPhone = Console.ReadLine();
            }

            int.TryParse(badgeID, out int badge);

            Departments dep = (Departments)Enum.Parse(typeof(Departments), department);

            Employee employee = new Employee(name, surName, badge, dep, internalPhone);
            myPhoneBook.AddEmployee(employee);

            Console.WriteLine("Employee has been added.");
        }
    }
}