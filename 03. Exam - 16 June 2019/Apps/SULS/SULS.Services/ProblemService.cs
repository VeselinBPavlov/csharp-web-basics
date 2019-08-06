using System.Linq;
using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using SULS.Services.Interfaces;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly SULSContext context;

        public ProblemService(SULSContext context)
        {
            this.context = context;
        }
        public void Create(string name, int points, string userId)
        {
            var problem = new Problem 
            {
                Name = name,
                Points = points,
                UserId = userId
            };

            this.context.Problems.Add(problem);
            this.context.SaveChanges();
        }

        public IQueryable<Problem> GetAll()
        {
            return this.context.Problems;
        }

        public Problem GetProblemById(string id)
        {
            return this.context.Problems.Include(p => p.Submissions).Include(p => p.User).SingleOrDefault(p => p.Id == id);
        }
    }
}