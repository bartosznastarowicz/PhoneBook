namespace PhoneBook
{
    public class Employee
    {
        public Employee(string name, string surName, int badgeId, Departments department, string internalPhone)
        {
            this.Name = name;
            this.SurName = surName;
            this.BadgeID = badgeId;
            this.Department = department;
            this.InternalPhone = internalPhone;
        }

        public string Name { get; set; }

        public string SurName { get; set; }

        public int BadgeID { get; set; }

        public Departments Department { get; set; }

        public string InternalPhone { get; set; }

        public string PrintBasicInfo()
        {
            return $"Name: {Name}, Location: {Department}";
        }

        public string PrintFullInfo()
        {
            return $"Name: {Name}, Last name: {SurName}, ID Number: {BadgeID}, Location: {Department}, Internal Phone: {InternalPhone}";
        }
    }
}
