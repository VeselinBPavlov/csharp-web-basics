namespace Panda.WebApp.Controllers
{
    using System.Linq;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    using Services;
    using ViewModels.Receipts;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var recipients = this.receiptsService.GetAll().Select(x => new ReceiptViewModel
            {
                Id = x.Id,
                Fee = x.Fee,
                IssuedOn = x.IssuedOn,
                RecipientName = x.Recipient.Username
            })
            .ToList();

            return this.View(recipients);
        }
    }
}
