using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingDependencyInjection
{
    public class ConsoleNotification:INotificationService
    {
        public void NotifyUsernameChanged(User user)
        {
            Console.WriteLine($"Username has been changed to: {user.Username}");
        }
    }
}
