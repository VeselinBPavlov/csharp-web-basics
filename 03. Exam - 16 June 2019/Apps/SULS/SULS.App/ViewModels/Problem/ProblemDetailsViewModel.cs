using System.Collections.Generic;

namespace SULS.App.ViewModels.Problem
{
    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionDetailsViewModel> Submissions { get; set; }

    }
}