using SULS.Models;

namespace SULS.Services.Interfaces
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);
        
        User GetUserOrNull(string username, string password);
    }
}