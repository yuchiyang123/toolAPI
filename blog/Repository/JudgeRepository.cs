using System.Threading.Tasks;
using blog.Common.Enum;
using blog.Entities;
using blog.Entities.Judge;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository
{
    public class JudgeRepository(BlogContext context)
    {
        public IQueryable<Problem> GetProblemNoInclaude()
        {
            return context.Problems.AsQueryable();
        }

        public IQueryable<Problem> GetProblemDetail()
        {
            return context
                .Problems.Include(x => x.Functions)
                .Include(x => x.Submissions)
                    .ThenInclude(x => x.Users)
                .Include(x => x.Submissions)
                    .ThenInclude(x => x.SubmissionResults)
                .Include(x => x.ProblemSignatures)
                .AsQueryable();
        }

        public IQueryable<Problem> GetProblemList()
        {
            return context.Problems.Include(x => x.Submissions).AsQueryable();
        }

        public IQueryable<Problem> GetProblemsFeature(JudgeLanguageEnum language)
        {
            return context.Problems.Include(x => x.Functions.Where(x => x.Language == language)).AsQueryable();
        }
    }
}
