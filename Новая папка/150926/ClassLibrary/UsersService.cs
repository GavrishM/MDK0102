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
        public string Autorization(string login, string password)
        {
            string result = "ERORE";
            User user = repository_.GetUser(login);
            if (user.Password == password)
            { result = "true"; }
            return result;
        }
    }
}
