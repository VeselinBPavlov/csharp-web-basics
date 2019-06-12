using Panda.Data;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly PandaDbContext context;

        public ReceiptsService(PandaDbContext context)
        {
            this.context = context;
        }

        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Fee = weight * 2.67M,
                IssuedOn = DateTime.UtcNow
            };

            this.context.Receipts.Add(receipt);
            this.context.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            var receipts = this.context.Receipts;

            return receipts;
        }
    }
}
