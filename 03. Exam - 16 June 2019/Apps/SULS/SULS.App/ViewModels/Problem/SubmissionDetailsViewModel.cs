using System;

namespace SULS.App.ViewModels.Problem
{
    public class SubmissionDetailsViewModel
    {        
        public string SubmissionId  { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }
    }
}