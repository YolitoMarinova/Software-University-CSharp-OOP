using System;
using System.Collections.Generic;
using P02._Identity_Before.Contracts;

namespace P02._Identity_Before.Models
{
    public class UsersManager:IUsersManager
    {
        public IEnumerable<IUser> GetAllUsersOnline()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
