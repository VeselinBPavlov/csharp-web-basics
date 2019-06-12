namespace Panda.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Package
    {
        public Package()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }
        public virtual User Recipient { get; set; }
    }
}
