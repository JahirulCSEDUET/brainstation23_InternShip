
namespace SolidPrinciple.Violation
{
    public interface IWorker
    {
        void Work();
        void Eat();
        void Sleep();
    }
    public class Human : IWorker
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
    public class Robot : IWorker
    {
        public void Eat()
        {
            throw new InvalidOperationException("Robot Cannot be eat.");
        }

        public void Sleep()
        {
            throw new InvalidOperationException("Robot Cannot be sleep.");
        }

        public void Work()
        {
            Console.WriteLine("Working");
        }
    }
}
