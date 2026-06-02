using PracticingDependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var notificationService = new ConsoleNotification();
        var user1 = new User("Jahir", notificationService);
        user1.ChangeUsername("Nayem");
    }
}