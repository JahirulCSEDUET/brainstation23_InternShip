using Autofac;
using PracticingDependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<ConsoleNotification>().As<INotificationService>();
        containerBuilder.RegisterType<UserService>().AsSelf();
        var container = containerBuilder.Build();

        var notificationService =  container.Resolve<INotificationService>();
        var userService = container.Resolve<UserService>();
        var user1 = new User("Jahir");
        userService.ChangeUsername("nayem", user1);


    }
}