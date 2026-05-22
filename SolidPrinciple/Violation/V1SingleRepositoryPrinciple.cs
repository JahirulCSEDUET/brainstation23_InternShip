
namespace SolidPrinciple.Violation
{
    // This class is not following Single Responsibility Principle. Because it contains more than one responsibilities or functionalities.
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AttendClass { get; set; }
        public void SaveToDataBase()
        {
            Console.WriteLine($"{Name} is saved to Database");
        }
        public void CheckAttendence()
        {
            Console.WriteLine($"{Name} attend for {AttendClass} days.");
        }
    }
}
