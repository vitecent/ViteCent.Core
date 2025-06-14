/*
 * **********************************
 * 代码由工具自动生成
 * 重新生成时，不会覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using Microsoft.Extensions.Logging;
using ViteCent.Basic.Entity.BaseLogs;
using ViteCent.Core.Data;
using ViteCent.Core.Orm.SqlSugar;

#endregion

namespace ViteCent.Basic.Domain.BaseLogs;

/// <summary>
/// 批量职位信息判重领域
/// </summary>
/// <param name="logger"></param>
public class HasBaseLogsList(
    ILogger<HasBaseLogsList> logger)
    : BaseDomain<BaseLogsEntity>, IRequestHandler<HasBaseLogsEntityListArgs, BaseResult>
{
    /// <summary>
    /// 职位信息库名称
    /// </summary>
    public override string DataBaseName => "ViteCent.Basic";

    /// <summary>
    /// 批量职位信息判重
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<BaseResult> Handle(HasBaseLogsEntityListArgs request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Invoke ViteCent.Basic.Domain.BaseLogs.HasBaseLogs");

        var query = Client.Query<BaseLogsEntity>();

        request.CompanyIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.CompanyIds.Count > 0)
            query.Where(x => request.CompanyIds.Contains(x.Id));

        request.DepartmentIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.DepartmentIds.Count > 0)
            query.Where(x => request.DepartmentIds.Contains(x.DepartmentId));

        request.SystemIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.SystemIds.Count > 0)
            query.Where(x => request.SystemIds.Contains(x.SystemId));

        request.ResourceIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.ResourceIds.Count > 0)
            query.Where(x => request.ResourceIds.Contains(x.ResourceId));

        request.OperationIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.OperationIds.Count > 0)
            query.Where(x => request.OperationIds.Contains(x.OperationId));

        var entity = await query.CountAsync(cancellationToken);

        if (entity > 0)
            return new BaseResult(500, "职位信息重复");

        return new BaseResult();
    }
}