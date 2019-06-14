using Musaca.App.ViewModels.Home;
using Musaca.Models.Enums;
using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System.Collections.Generic;
using System.Linq;

namespace Musaca.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return Index();
        }

        public IActionResult Index()
        {
            var products = new List<HomeProductsModel>();
            if (IsLoggedIn())
            {
                var order = orderService.GetActiveOrderByUserId(User.Id);
                products
                    .AddRange(order.Products
                    .Select(p => new HomeProductsModel { Name = p.Product.Name, Price = p.Product.Price }));

            }
            return View(products);


        }

    }
}
