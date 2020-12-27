using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverFramework.business_objects
{
    class User
    {
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        } 

    public string Name { get; set; }
    public string Password { get; set; }
    }
}
