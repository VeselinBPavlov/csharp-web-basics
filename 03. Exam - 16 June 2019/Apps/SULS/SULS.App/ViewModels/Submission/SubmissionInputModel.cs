using System;
using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Submission
{
    public class SubmissionInputModel
    {
        [RequiredSis]
        [StringLengthSis(30, 800, "Code should be between 30 and 800 characters")]
        public string Code { get; set; }

        [RequiredSis]
        public string ProblemId { get; set; }
        
        [RequiredSis]
        public string UserId { get; set; }
    }
}

