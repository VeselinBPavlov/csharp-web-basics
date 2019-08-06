using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.App.Controllers
{
    public class ProductOrderModel
    {
        [RequiredSis]
        public string Name { get; set; }
    }
}