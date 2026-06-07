using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Helper;
using blog.Dtos.Flow;
using blog.Entities;
using blog.Entities.Flows;
using blog.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace blog.Services
{
    public class FlowService(IMapper mapper, BlogContext context, FlowRepository repository, JwtInfoHelper jwtInfoHelper)
    {
        public async Task<List<FlowList>> GetFlowListAsync(FlowListQueryDto queryDto)
        {
            return await repository.GetFlowListAsQueryable(queryDto.FlowName).ProjectTo<FlowList>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task AddFlowAsync(FlowDetails responseDto, CancellationToken ct = default)
        {
            var currentTime = DateTime.UtcNow;
            var entity = await context.Flows.FirstOrDefaultAsync(x => x.Id == responseDto.Id, ct)
                ?? throw new KeyNotFoundException("找不到對應的流程主檔");
            var userId = await jwtInfoHelper.GetUserIdForJwt();
            using var transaction = await context.Database.BeginTransactionAsync(ct);
            try
            {
                await context.FlowVersions.Where(x => x.FlowId == responseDto.Id && x.IsActive)
                    .ExecuteUpdateAsync(y => y.SetProperty(x => x.IsActive, false), ct);

                entity.FlowVersion.Add(new FlowVersion
                {
                    Version = responseDto.FlowVersion,
                    IsActive = true,
                    UpdateDate = currentTime,
                    CreateDate = currentTime,
                    UpdateUser = userId,
                    CreateUser = userId,
                    FlowNodes = [.. responseDto.Nodes.Select(x => new FlowNode
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
                        FlowRules = [..x.Rules.Select(rule => new FlowRule
                        {
                            ConditionJson = JsonSerializer.Serialize(rule.Condition),
                            ActionJson = JsonSerializer.Serialize( rule.Action),
                            Sort = rule.Sort
                        })]
                    })],
                    FlowEdges = [..responseDto.Edges.Select(x => new FlowEdge
                    {
                        SourceNodeId = x.SourceNodeId,
                        TargetNodeId = x.TargetNodeId,
                        DataJson = JsonSerializer.Serialize(x.Condition),
                        UpdateDate =currentTime,
                        CreateDate = currentTime,
                        UpdateUser = userId,
                        CreateUser = userId,
                    })]
                });

                await context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }
    }
}
