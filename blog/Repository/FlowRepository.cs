using blog.Dtos.Flow;
using blog.Entities;
using blog.Entities.Flows;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository
{
    public class FlowRepository(BlogContext context)
    {
        public IQueryable<Flow> GetFlowNoIncludeAsQueryable()
        {
            return context.Flows.AsQueryable();
        }

        public IQueryable<Flow> GetFlowListAsQueryable(string? stageName)
        {
            var query = context
                .Flows.Include(x => x.FlowVersion)
                .Include(x => x.CreateUsers)
                .Include(x => x.UpdateUsers)
                .AsQueryable();
            if (!string.IsNullOrEmpty(stageName))
            {
                query = query.Where(x => x.Name == stageName);
            }
            return query;
        }

        public IQueryable<FlowVersion> GetFlowDetailAsQueryable()
        {
            return context
                .FlowVersions.Include(x => x.FlowNodes)
                    .ThenInclude(x => x.FlowRules)
                .Include(x => x.FlowEdges)
                .Include(x => x.UpdateUsers)
                .Include(x => x.CreateUsers)
                .AsQueryable();
        }
    }
}
