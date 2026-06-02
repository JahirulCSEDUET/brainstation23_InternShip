using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingDependencyInjection
{
    public interface INotificationService
    {
        void NotifyUsernameChanged(User user);
    }
}
