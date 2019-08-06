using SULS.Models;

namespace SULS.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);
    }
}