using System.Linq;
using SULS.Models;

namespace SULS.Services.Interfaces
{
    public interface IProblemService
    {
         void Create(string name, int points, string userId);

         IQueryable<Problem> GetAll();

         Problem GetProblemById(string id);
    }
}