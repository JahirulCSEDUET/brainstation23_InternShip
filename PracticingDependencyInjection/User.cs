using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingDependencyInjection
{
    public class User
    {
        
        public User(string username)
        {
            Username = username;
        }
        public string Username { get;set; }
    }
}
