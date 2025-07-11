/*
 * **********************************
 * 代码由工具自动生成
 * 重新生成时，不会覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using Microsoft.Extensions.Logging;
using ViteCent.Basic.Data.RepairSchedule;
using ViteCent.Basic.Entity.RepairSchedule;
using ViteCent.Core.Data;
using ViteCent.Core.Orm.SqlSugar;

#endregion

namespace ViteCent.Basic.Domain.RepairSchedule;

/// <summary>
/// 批量补卡申请判重
/// </summary>
/// <param name="logger">日志记录器，用于记录处理器的操作日志</param>
public class HasRepairScheduleList(ILogger<HasRepairScheduleList> logger) : BaseDomain<RepairScheduleEntity>,
    IRequestHandler<HasRepairScheduleEntityListArgs, BaseResult>
{
    /// <summary>
    /// 数据库名称
    /// </summary>
    public override string Database => "ViteCent.Basic";

    /// <summary>
    /// 批量补卡申请判重
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>处理结果</returns>
    public async Task<BaseResult> Handle(HasRepairScheduleEntityListArgs request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Invoke ViteCent.Basic.Domain.RepairSchedule.HasRepairSchedule");

        var query = Client.Query<RepairScheduleEntity>().Where(x => x.Status != (int)RepairScheduleEnum.Pass);

        request.CompanyIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.CompanyIds.Count > 0)
            query.Where(x => request.CompanyIds.Contains(x.CompanyId));

        request.DepartmentIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.DepartmentIds.Count > 0)
            query.Where(x => request.DepartmentIds.Contains(x.DepartmentId));

        request.UserIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.UserIds.Count > 0)
            query.Where(x => request.UserIds.Contains(x.UserId));

        request.ScheduleIds.RemoveAll(x => string.IsNullOrWhiteSpace(x));

        if (request.ScheduleIds.Count > 0)
            query.Where(x => request.ScheduleIds.Contains(x.ScheduleId));

        request.RepairTypes.RemoveAll(x => x < 1);

        if (request.RepairTypes.Count > 0)
            query.Where(x => request.RepairTypes.Contains(x.RepairType));

        var entity = await query.CountAsync(cancellationToken);

        if (entity > 0)
            return new BaseResult(500, "数据重复");

        return new BaseResult();
    }
}