using Musaca.Data;
using Musaca.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Musaca.Services
{
    public class UserService : IUserService
    {
        private readonly MusacaDbContext db;
        private readonly IOrderService orderService;

        public UserService(MusacaDbContext db, IOrderService orderService)
        {
            this.db = db;
            this.orderService = orderService;
        }

        public string RegisterUser(User user)
        {
            user.Password = HashPassword(user.Password);
            user = db.Users.Add(user).Entity;
            db.SaveChanges();
            orderService.CreateOrder(user.Id);
          

            return user.Id;


        }

        public User LoginUser(string username, string password)
        {
            var user = db.Users
                .SingleOrDefault(u => u.Username == username && u.Password == HashPassword(password));
            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

   
    }


}
