namespace SULS.Services.Interfaces
{
    public interface ISubmissionService
    {
         void Create(string code, string problemId, string userId);

         void Delete(string id);
    }
}