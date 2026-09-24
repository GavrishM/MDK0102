using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class User
    {
        public string Login {get; set;}
        public string Password {get; set;} 
        public string Name {get; set;}
        public string Familia {get; set;}

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public User (string login, string password, string name, string familia)
        {
            Login = login;
            Password = password;
            Name = name;
            Familia = familia;
        }
    }
}
