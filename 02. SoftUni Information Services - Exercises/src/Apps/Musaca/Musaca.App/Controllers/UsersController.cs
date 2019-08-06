using Musaca.Models;
using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace Musaca.App.Controllers
{
    using Musaca.App.ViewModels.Users;
    using SIS.MvcFramework.Attributes.Security;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;

        public UsersController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            User userFromDb = userService.LoginUser(model.Username, model.Password);

            if (userFromDb == null)
            {
                return Redirect("/Users/Login");
            }

            SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return Redirect("/");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Redirect("/Users/Register");
            }

            User user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };

            var userId = userService.RegisterUser(user);
            SignIn(userId, model.Username, model.Email);
            return Redirect("/");
        }
        [Authorize]
        public IActionResult Logout()
        {
            SignOut();

            return Redirect("/");
        }
        [Authorize]
        public IActionResult Profile()
        {
            var orders = orderService.GetCompletedOrders(User.Id)
                .Select(o => new UserProfileModel
                {
                    Id = o.Id,
                    CashierName = o.Cashier.Username,
                    IssuedOn = o.IssuedOn.ToString(@"dd/MM/yyyy"),
                    Total = o.Products.Sum(p => p.Product.Price)
                }).ToList(); ;
            return View(orders);
        }

    }
}
