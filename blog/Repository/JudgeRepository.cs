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
                .Include(x => x.ProblemTags)
                .AsQueryable();
        }

        public IQueryable<Problem> GetProblemList()
        {
            return context
                .Problems.Include(x => x.ProblemTags)
                .Include(x => x.Submissions)
                .AsQueryable();
        }

        public IQueryable<Problem> GetProblemsFeature(JudgeLanguageEnum language)
        {
            return context
                .Problems.Include(x => x.Functions.Where(x => x.Language == language))
                .Include(x => x.ProblemSignatures.Where(x => x.Language == language))
                .AsQueryable();
        }

        public IQueryable<ProblemSignature> GetComieDataAsQueryable()
        {
            return context
                .ProblemSignatures.Include(x => x.ProblemParameters)
                .Include(x => x.ProblemReturnTypes)
                .AsQueryable();
        }

        public IQueryable<Problem> GetTestResultAsQueryable(
            int submissionsId,
            JudgeLanguageEnum language
        )
        {
            return context
                .Problems.Include(x => x.Functions.Where(x => x.Language == language))
                .Include(x => x.Submissions.Where(x => x.Id == submissionsId))
                    .ThenInclude(x => x.SubmissionResults)
                .AsQueryable();
        }
    }
}
