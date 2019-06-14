using Musaca.Models.Enums;
using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace Musaca.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [Authorize]
        public IActionResult Cashout(string userId)
        {
            var order = orderService.GetActiveOrderByUserId(userId);
            if (order != null)
            {
                orderService.CashoutOrder(order.Id);
            }
            return Redirect("/");
        }
    }
}
