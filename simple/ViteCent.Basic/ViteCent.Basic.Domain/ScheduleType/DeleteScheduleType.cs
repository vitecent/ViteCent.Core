/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using Microsoft.Extensions.Logging;
using ViteCent.Basic.Entity.ScheduleType;
using ViteCent.Core.Data;
using ViteCent.Core.Orm.SqlSugar;

#endregion

namespace ViteCent.Basic.Domain.ScheduleType;

/// <summary>
/// 删除基础排班领域
/// </summary>
/// <param name="logger"></param>
public class DeleteScheduleType(
    ILogger<DeleteScheduleType> logger)
    : BaseDomain<DeleteScheduleTypeEntity>, IRequestHandler<DeleteScheduleTypeEntity, BaseResult>
{
    /// <summary>
    /// 数据库名称
    /// </summary>
    public override string DataBaseName => "ViteCent.Basic";

    /// <summary>
    /// 删除基础排班
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<BaseResult> Handle(DeleteScheduleTypeEntity request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Invoke ViteCent.Basic.Domain.ScheduleType.DeleteScheduleType");

        return await DeleteAsync(request);
    }
}