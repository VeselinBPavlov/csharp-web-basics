using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.App.ViewModels.Products
{
    public class ProductCreateModel
    {
        private const string NameErrorMessage = "Product's name must be between 3 and 10 chars!";

        [RequiredSis]
        [StringLengthSis(3, 10, NameErrorMessage)]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
