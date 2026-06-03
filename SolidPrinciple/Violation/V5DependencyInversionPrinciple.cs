
namespace SolidPrinciple.Violation
{
    //violate:
    public class FileLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Writing to local file{message}");
        }
    }
    public class CloudLogger
    {
        public void LogMessage(string message) => Console.WriteLine($"[CLOUD/AWS] {message}");
    }
    public class OrderService
    {
        private FileLogger _logger = new FileLogger(); //violate: Higher lavel class depend on lower level class.
        //private CloudLogger _logger = new CloudLogger(); //Violate : need to replace whole and no existence of previous 
        public void CreateOrder(int orderId)
        {
            Console.WriteLine($"Order {orderId} created successfully.");
            _logger.LogMessage($"Order {orderId} was procced");
        }
    }
}
