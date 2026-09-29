using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Importer
    {
        IFile file_;
        IUsersRepository repository_;
        UsersService service_;
        public Importer(IFile file, IUsersRepository repository)
        {
            file_ = file;
            repository_ = repository;
            service_ = new UsersService(repository_);
        }
        public bool UsersImport(string filePath)
        {
            List<User> users = file_.GetUsers(filePath);
            bool result = false;
            bool temp = true;
            foreach (User user in users)
            {
                //result = service_.Registration(user.Login, user.Password);
                if (repository_.GetUser(user.Login) == null)
                {
                    if (user.Login != "")
                    {
                        if (user.Password.Length >= 8)
                        {
                            result = true;
                        }
                        else result = false;
                    }
                    else result = false;
                }
                else result = false;
                if (result == false) temp = false;

            }
            result = temp;
            if (result)
            {
                repository_.ImportUsersList(users);
            }
            return result;
        }
    }
}
