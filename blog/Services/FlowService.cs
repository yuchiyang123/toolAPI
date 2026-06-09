using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos;
using blog.Dtos.Flow;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Flows;
using blog.Repository;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class FlowService(
        IMapper mapper,
        BlogContext context,
        FlowRepository repository,
        JwtInfoHelper jwtInfoHelper
    )
    {
        public async Task<PageResponseDto<FlowList>> GetFlowListAsync(FlowListQueryDto queryDto)
        {
            return await repository
                .GetFlowListAsQueryable(queryDto.FlowName)
                .ProjectTo<FlowList>(mapper.ConfigurationProvider)
                .ToPageResponseDto(queryDto.PageIndex, queryDto.PageSize);
        }

        public async Task<FlowDetailResponseDto> GetFlowDetailAsync(int id)
        {
            return await repository
                    .GetFlowDetailAsQueryable()
                    .Where(x => x.Id == id)
                    .ProjectTo<FlowDetailResponseDto>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException();
        }

        public async Task AddFlowAsync(CreateFlowDto createFlow, CancellationToken ct = default)
        {
            var userId = await jwtInfoHelper.GetUserIdForJwt();
            var entity = mapper.Map<Flow>(createFlow);
            entity.UpdateUser = userId;
            entity.CreateUser = userId;
            context.Flows.Add(entity);
            await context.SaveChangesAsync(ct);
        }

        public async Task AddFlowDetailAsync(
            FlowDetailsRequestDto responseDto,
            CancellationToken ct = default
        )
        {
            var currentTime = DateTime.UtcNow;
            var entity =
                await context.Flows.FirstOrDefaultAsync(x => x.Id == responseDto.FlowId, ct)
                ?? throw new KeyNotFoundException("找不到對應的流程主檔");
            var userId = await jwtInfoHelper.GetUserIdForJwt();
            using var transaction = await context.Database.BeginTransactionAsync(ct);
            try
            {
                await context
                    .FlowVersions.Where(x => x.FlowId == responseDto.FlowId && x.IsActive)
                    .ExecuteUpdateAsync(y => y.SetProperty(x => x.IsActive, false), ct);

                entity.FlowVersion.Add(
                    new FlowVersion
                    {
                        Version = responseDto.FlowVersion,
                        IsActive = true,
                        UpdateDate = currentTime,
                        CreateDate = currentTime,
                        UpdateUser = userId,
                        CreateUser = userId,
                        FlowNodes =
                        [
                            .. responseDto.Nodes.Select(x => new FlowNode
                            {
                                Id = x.Id,
                                StageName = x.StageName,
                                Type = x.Type,
                                PositionX = x.PositionX,
                                PositionY = x.PositionY,
                                UpdateDate = currentTime,
                                CreateDate = currentTime,
                                UpdateUser = userId,
                                CreateUser = userId,
                                FlowRules =
                                [
                                    .. x.Rules.Select(rule => new FlowRule
                                    {
                                        ConditionJson = JsonSerializer.Serialize(rule.Condition),
                                        ActionJson = JsonSerializer.Serialize(rule.Action),
                                        Sort = rule.Sort,
                                    }),
                                ],
                            }),
                        ],
                        FlowEdges =
                        [
                            .. responseDto.Edges.Select(x => new FlowEdge
                            {
                                SourceNodeId = x.SourceNodeId,
                                TargetNodeId = x.TargetNodeId,
                                DataJson = JsonSerializer.Serialize(x.Condition),
                                UpdateDate = currentTime,
                                CreateDate = currentTime,
                                UpdateUser = userId,
                                CreateUser = userId,
                            }),
                        ],
                    }
                );

                await context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }

        public async Task DeleteFlow(int id, CancellationToken ct = default)
        {
            await context.Flows.Where(x => x.Id == id).ExecuteDeleteAsync(ct);
        }

        public async Task DeleteFlowVerions(int versionId, CancellationToken ct = default)
        {
            await context.FlowVersions.Where(x => x.Id == versionId).ExecuteDeleteAsync(ct);
        }

        public async Task<List<DropDownListDto>> GetMainFlowDropDownInfoAsync()
        {
            var entity = await context.Flows.ToListAsync();
            return mapper.Map<List<DropDownListDto>>(entity);
        }
    }
}
