
using SolidPrinciple.Violation;

namespace SolidPrinciple.Following
{
    public interface IWorkable
    {
        void Work();
    }
    public interface IEatable
    {
        void Eat();
    }
    public interface ISleepable
    {
        void Sleep();
    }
    public class Human : IWorkable, ISleepable, IEatable
    {
        public void Work()
        {
            Console.WriteLine("Working");
        }
        public void Eat()
        {
            Console.WriteLine("Eating");
        }
        public void Sleep()
        {
            Console.WriteLine("Sleeping");
        }
    }
    public class Robot : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Working.");
        }
    }
}
