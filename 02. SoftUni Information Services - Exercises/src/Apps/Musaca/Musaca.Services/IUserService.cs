using Musaca.Models;

namespace Musaca.Services
{
    public interface IUserService
    {
        string RegisterUser(User user);
        User LoginUser(string username, string password);
    }
}