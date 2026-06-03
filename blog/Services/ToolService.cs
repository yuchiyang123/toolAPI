using System.Linq.Dynamic.Core;
using blog.Dtos;
using blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class ToolService(BlogContext context)
    {
        public string GetSql(ToolDto tool)
        {
            var query = context.Posts.AsQueryable();
            if (!string.IsNullOrEmpty(tool.Where))
                query = query.Where(tool.Where);
            if (!string.IsNullOrEmpty(tool.OrderBy))
                query = query.OrderBy(tool.OrderBy);
            return query.ToQueryString();
        }
    }
}
