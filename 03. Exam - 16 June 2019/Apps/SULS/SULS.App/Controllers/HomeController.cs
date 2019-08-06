using System.Linq;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problem;
using SULS.Services.Interfaces;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        // /Home/Index
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var viewModel = this.problemService.GetAll().Select(
                x => new ProblemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count
                }).ToList();

                return this.View(viewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}