using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IUsersRepository
    {
        List<User> GetAllUsers();
        User GetUser(string login);
    }
}
