using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Dtos;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services
{
    public class BlogCacheService(IDistributedCache cache, PostRepository repository, IMapper mapper)
    {
        public async Task<PostDetailDto?> GetPostDetailAsync(int id, CancellationToken ct = default)
        {
            var key = $"Post:{id}";
            var cached = await cache.GetStringAsync(key, ct);

            if (cached is not null)
                return JsonSerializer.Deserialize<PostDetailDto>(cached);

            var postDetail = await repository.GetPostDetail().ProjectTo<PostDetailDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id, ct);
            if (postDetail is null) return null;

            var entity = JsonSerializer.Serialize(postDetail);
            await cache.SetStringAsync(key, entity, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            }, ct);

            return postDetail;
        }

        public async Task InvalidatePostAsync(int id)
        {
            await cache.RemoveAsync($"Post:{id}");
        }
    }
}
