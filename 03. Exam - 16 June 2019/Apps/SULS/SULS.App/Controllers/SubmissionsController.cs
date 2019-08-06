using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problem;
using SULS.App.ViewModels.Submission;
using SULS.Services.Interfaces;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService.GetProblemById(id);
            var viewModel = new ProblemSubmissionViewModel 
            {
                ProblemId = problem.Id,
                Name = problem.Name
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(SubmissionInputModel input)
        {       
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={input.ProblemId}");
            }       

            this.submissionService.Create(input.Code, input.ProblemId, input.UserId);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionService.Delete(id);

            return this.Redirect("/");
        }
    }
}