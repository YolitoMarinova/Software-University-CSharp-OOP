using System.Collections.Generic;

namespace P02._Identity_Before.Contracts
{
    public interface IUsersManager
    {
        IEnumerable<IUser> GetAllUsersOnline();

        IEnumerable<IUser> GetAllUsers();

        IUser GetUserByName(string name);
    }
}
