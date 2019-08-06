using SULS.Data;
using SULS.Services.Interfaces;
using SULS.Models;
using System;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext context;
        private readonly IProblemService problemService;

        public SubmissionService(SULSContext context, IProblemService problemService)
        {
            this.problemService = problemService;
            this.context = context;
        }
        public void Create(string code, string problemId, string userId)
        {
            var problem = this.problemService.GetProblemById(problemId);

            var submission = new Submission
            {
                Code = code,
                AchievedResult = RandomNumber(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId
            };

            this.context.Submissions.Add(submission);
            this.context.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.context.Submissions.Find(id);
            this.context.Submissions.Remove(submission);
            this.context.SaveChanges();
        }

        private int RandomNumber(int min, int max)  
        {  
            Random random = new Random();  
            return random.Next(min, max);  
        }
    }
}