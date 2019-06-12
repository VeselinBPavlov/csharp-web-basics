namespace Panda.Services
{
    using System.Linq;

    using Data;
    using Models;

    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext context;
        private readonly IReceiptsService receiptsService;

        public PackagesService(PandaDbContext context, IReceiptsService receiptsService)
        {
            this.context = context;
            this.receiptsService = receiptsService;
        }

        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.context.Users.Where(x => x.Username == recipientName).Select(x => x.Id).FirstOrDefault();
            
            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                ShippingAddress = shippingAddress,
                RecipientId = userId
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();
        }

        public void Deliver(string id)
        {
            var package = this.context.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.context.SaveChanges();

            this.receiptsService.CreateFromPackage(package.Weight, package.Id, package.RecipientId);
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var packages = this.context.Packages.Where(x => x.Status == status);

            return packages;
        }
    }
}
