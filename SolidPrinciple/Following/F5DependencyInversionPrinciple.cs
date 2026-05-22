
namespace SolidPrinciple.Following
{
    public interface ILogger
    {
        void LogMessage(string message);
    }
    public class FileLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Writing to local file {message}");
        }
    }
    public class CloudLogger : ILogger
    {
        public void LogMessage(string message) 
        {
            Console.WriteLine($"Writing to cloud {message}");
        } 
    }
    public class OrderService
    {
        private readonly ILogger _logger;
        public OrderService(ILogger logger)
        {
            _logger = logger;
        }
        public void CreateOrder(int orderId)
        {
            Console.WriteLine($"Order {orderId} created successfully.");
            _logger.LogMessage($"Order {orderId} was procced");
        }
    }
}
