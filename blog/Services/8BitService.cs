using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos._8bit;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities._8bit;
using blog.Repository;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class _8BitService(IMapper mapper, BlogContext context, _8BitRepository repository)
    {
        public async Task<PageResponseDto<SequencerListRequestDto>> Get8BitListAsync(
            PageDto queryDto,
            CancellationToken ct = default
        )
        {
            var entity = await repository
                .GetSequencerNoInclude()
                .Page(queryDto.PageIndex, queryDto.PageSize)
                .ToListAsync(ct);
            var dto = mapper.Map<List<SequencerListRequestDto>>(entity);
            return dto.ToPageResponseDtoNoToPage(queryDto.PageIndex, queryDto.PageSize);
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
            var entity = mapper.Map<Sequencer>(dto);
            context.Add(entity);
            await context.SaveChangesAsync(ct);
        }

        public async Task Delete8bitAsync(int id, CancellationToken ct = default)
        {
            await repository.GetSequencerNoInclude().Where(x => x.Id == id).ExecuteDeleteAsync(ct);
        }
    }
}
