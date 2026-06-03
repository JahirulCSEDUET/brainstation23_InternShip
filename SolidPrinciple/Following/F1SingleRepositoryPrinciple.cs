
using System.Xml.Linq;

namespace SolidPrinciple.Following
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AttendClass { get; set; }
        
        
    }
    public class SyudentSaveToDataBase 
    {
        Student student= new Student();
        public void SaveToDataBase()
        {
            Console.WriteLine($"{student.Name} is saved to Database");
        }
    }
    public class StudentCheckAttendence
    {
        Student student = new Student();
        public void CheckAttendence()
        {
            Console.WriteLine($"{student.Name} attend for {student.AttendClass} days.");
        }
    }
}
