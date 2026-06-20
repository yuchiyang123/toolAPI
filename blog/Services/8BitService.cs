using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Dtos._8bit;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities._8bit;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Services
{
    public class _8BitService(
        IMapper mapper,
        IDistributedCache cache,
        BlogContext context,
        _8BitRepository repository,
        JwtInfoHelper jwtInfoHelper
    )
    {
        public async Task<PageResponseDto<SequencerListRequestDto>> Get8BitListAsync(
            PageDto queryDto,
            CancellationToken ct = default
        )
        {
            var filterKey = PageHelper.ComputeFilterHash(queryDto);
            return await repository
                .GetSequencerNoInclude()
                .Page(queryDto.PageIndex, queryDto.PageSize)
                .ProjectTo<SequencerListRequestDto>(mapper.ConfigurationProvider)
                .ToPageResponseDtoWithCache(
                    queryDto.PageIndex,
                    queryDto.PageSize,
                    PageEnums._8BitList,
                    filterKey,
                    cache,
                    ct: ct
                );
        }

        public async Task<SequencerResponseDto> Get8BitDetailAsync(
            int id,
            CancellationToken ct = default
        )
        {
            return await repository
                    .GetSequencerNoInclude()
                    .ProjectTo<SequencerResponseDto>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == id, ct)
                ?? throw new KeyNotFoundException();
        }

        public async Task Add8BitAsync(SequencerRequestDto dto, CancellationToken ct = default)
        {
            var userId = await jwtInfoHelper.GetUserIdForJwt();
            var entity = mapper.Map<Sequencer>(dto);
            entity.CreateUser = userId;
            entity.UpdateUser = userId;
            context.Add(entity);
            await context.SaveChangesAsync(ct);
        }

        public async Task Delete8bitAsync(int id, CancellationToken ct = default)
        {
            await repository.GetSequencerNoInclude().Where(x => x.Id == id).ExecuteDeleteAsync(ct);
        }
    }
}
