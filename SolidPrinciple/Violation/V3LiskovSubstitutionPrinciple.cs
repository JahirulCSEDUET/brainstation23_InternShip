namespace SolidPrinciple.Violation
{
    public interface INotification
    {
        string Subject { get; set; }
        string Message { get; set; }
        string RecipientAddress { get; set; }
        void send();
    }
    public class EmailNotification : INotification
    {
        public string Subject { get ; set ; }
        public string Message { get; set; }
        public string RecipientAddress { get; set; }

        public void send()
        {
            Console.WriteLine($"Email sent to {RecipientAddress} with subject {Subject}");
        }
    }
    public class SmsNotification : INotification
    {
        //violation: SMS text messages do not have a Subject line!
        public string Subject 
        { 
            get => throw new NotSupportedException("SMS doesnot support subject."); 
            set => throw new NotSupportedException("SMS doesnot support subject."); 
        }
        public string Message { get; set; }
        public string RecipientAddress { get; set; }

        public void send()
        {
            Console.WriteLine($"SNS sent to {RecipientAddress}");
        }
    }
}
