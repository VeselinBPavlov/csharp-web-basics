namespace Panda.WebApp.Controllers
{
    using System.Linq;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Attributes;

    using Services;
    using Models;
    using ViewModels.Packages;

    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {            
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var usernames = usersService.GetUsernames();

            return this.View(usernames);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreatePackageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.Redirect("/Packages/Create");
            }

            this.packagesService.Create(input.Description, input.Weight, input.ShippingAddress, input.RecipientName);

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = this.packagesService.GetAllByStatus(PackageStatus.Delivered)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username
                })
                .ToList();

            return this.View(new PackagesListViewModel { Packages = packages });
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = this.packagesService.GetAllByStatus(PackageStatus.Pending)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username
                })
                .ToList();

            return this.View(new PackagesListViewModel { Packages = packages });
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            packagesService.Deliver(id);

            return this.Redirect("/Packages/Delivered");
        }
    }
}
