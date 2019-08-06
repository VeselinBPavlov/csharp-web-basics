using System.Linq;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problem;
using SULS.Services.Interfaces;

namespace SULS.App.Controllers
{    
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemService.Create(input.Name, input.Points, input.UserId);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {   
            var problem = problemService.GetProblemById(id);

            var viewModel = new ProblemDetailsViewModel 
            {
                Name = problem.Name,
                Submissions = problem.Submissions.Select(x => new SubmissionDetailsViewModel
                {
                    SubmissionId  = x.Id,
                    Username = x.User.Username,
                    AchievedResult = x.AchievedResult,
                    MaxPoints = x.Problem.Points,
                    CreatedOn = x.CreatedOn,
                    ProblemId = x.ProblemId
                }).ToList()
            };

            return this.View(viewModel);
        }
    }
}