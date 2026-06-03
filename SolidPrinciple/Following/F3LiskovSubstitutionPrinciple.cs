
namespace SolidPrinciple.Following
{
    public interface INotification
    {
        string Message { get; set; }
        void send();
    }
    public interface ISubjective
    {
        string Subject { get; set; }
    }
    public class EmailNotification : INotification, ISubjective
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string EmailAddress { get; set; }

        public void send()
        {
            Console.WriteLine($"Email sent to {EmailAddress} with subject {Subject}");
        }
    }
    public class SmsNotification : INotification
    {
        public string Message { get; set; }
        public string PhoneNumber { get; set; }

        public void send()
        {
            Console.WriteLine($"SMS sent to {PhoneNumber}");
        }
    }
    public class PushNotification : INotification
    {
        public string Message { get; set; }
        public string DeviceToken { get; set; }

        public void send()
        {
            Console.WriteLine($"Push notification sent to device: {DeviceToken}");
        }
    }
}
