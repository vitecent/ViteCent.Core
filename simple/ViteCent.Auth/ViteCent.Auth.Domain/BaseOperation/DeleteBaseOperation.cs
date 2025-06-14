/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using Microsoft.Extensions.Logging;
using ViteCent.Auth.Entity.BaseOperation;
using ViteCent.Core.Data;
using ViteCent.Core.Orm.SqlSugar;

#endregion

namespace ViteCent.Auth.Domain.BaseOperation;

/// <summary>
/// 删除操作信息领域
/// </summary>
/// <param name="logger"></param>
public class DeleteBaseOperation(
    ILogger<DeleteBaseOperation> logger)
    : BaseDomain<DeleteBaseOperationEntity>, IRequestHandler<DeleteBaseOperationEntity, BaseResult>
{
    /// <summary>
    /// 数据库名称
    /// </summary>
    public override string DataBaseName => "ViteCent.Auth";

    /// <summary>
    /// 删除操作信息
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<BaseResult> Handle(DeleteBaseOperationEntity request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Invoke ViteCent.Auth.Domain.BaseOperation.DeleteBaseOperation");

        return await DeleteAsync(request);
    }
}