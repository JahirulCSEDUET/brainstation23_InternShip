using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingDependencyInjection
{
    public class UserService
    {
        private INotificationService _notificationService;
        public UserService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void ChangeUsername(string newUsername, User user)
        {
            user.Username = newUsername;
            _notificationService.NotifyUsernameChanged(user);
        }
    }
}
