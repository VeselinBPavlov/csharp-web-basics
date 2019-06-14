using Musaca.App.ViewModels.Products;
using Musaca.Models;
using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;

namespace Musaca.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductsController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(ProductCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Products/Create");
            }
            var product = new Product() { Name = model.Name, Price = model.Price };
            productService.CreateProduct(product);
            return Redirect("/Products/All");
        }
        [Authorize]
        public IActionResult All()
        {
            var products = productService
                .GetAll()
                .Select(p => new ProductAllModel { Name = p.Name, Price = p.Price })
                .ToList();
            return View(products);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Order(ProductOrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/");
            }
            var product = productService.GetByName(model.Name);
            if (product != null)
            {
                orderService.AddProduct(product, User.Id);
            }
            return Redirect("/");
        }
    }
}
