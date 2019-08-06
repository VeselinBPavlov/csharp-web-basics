using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Problem
{
    public class ProblemInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Problem name should be between 5 and 20 characters")]
        public string Name { get; set; }

        [RangeSis(50, 300, "Points should be between 50 and 300")]
        public int Points { get; set; }

        [RequiredSis]
        public string UserId { get; set; }
    }
}