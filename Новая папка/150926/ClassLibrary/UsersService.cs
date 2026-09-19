using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UsersService
    {
        IUsersRepository repository_;
        public UsersService(IUsersRepository repository)
        {
            repository_ = repository;
        }
        public bool Autorization(string login, string password)
        {
            bool result = false;
            User user = repository_.GetUser(login);
            if (user.Password == password)
            { result = true; }
            return result;
        }
        public bool Registation(string login, string password)
        {
            bool result = false;
            User user = new User { Login = login, Password = password };
            if (repository_.GetUser(login) == null)
            {
                repository_.SetUser(user);
                result = true;
            }
            return result;
        }
    }
}
