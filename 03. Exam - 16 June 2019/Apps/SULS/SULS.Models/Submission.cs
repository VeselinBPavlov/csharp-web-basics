using System;

namespace SULS.Models
{
    public class Submission
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public int  AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public virtual Problem Problem { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
