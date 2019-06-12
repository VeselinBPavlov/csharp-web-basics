namespace Panda.Services
{
    using Panda.Models;
    using System.Collections.Generic;

    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}
