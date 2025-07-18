/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region 引入命名空间

// 引入 MediatR 用于实现中介者模式
using MediatR;

// 引入 Microsoft.Extensions.Logging 用于日志记录
using Microsoft.Extensions.Logging;

// 引入核心数据类型
using ViteCent.Core.Data;

// 引入ORM基础设施
using ViteCent.Core.Orm.SqlSugar;

// 引入数据表信息相关的数据模型
using ViteCent.Database.Entity.BaseTable;

#endregion 引入命名空间

namespace ViteCent.Database.Domain.BaseTable;

/// <summary>
/// 编辑数据表信息领域服务类
/// </summary>
/// <remarks>
/// 该类负责处理编辑数据表信息的业务逻辑，包括：
/// 1. 记录操作日志
/// 2. 调用基类方法更新数据表信息
/// 3. 返回操作结果
/// </remarks>
/// <param name="logger">日志记录器实例</param>
public class EditBaseTable(
    // 注入日志记录器
    ILogger<EditBaseTable> logger)
    : BaseDomain<BaseTableEntity>, IRequestHandler<BaseTableEntity, BaseResult>
{
    /// <summary>
    /// 数据库名称
    /// </summary>
    public override string Database => "ViteCent.Database";

    /// <summary>
    /// 处理编辑数据表信息的请求
    /// </summary>
    /// <param name="request">包含更新信息的数据表信息模型</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>操作结果，包含状态码和提示信息</returns>
    /// <remarks>
    /// 该方法执行以下步骤：
    /// 1. 记录方法调用日志
    /// 2. 调用基类的EditAsync方法执行更新操作
    /// 3. 返回更新结果
    /// </remarks>
    public async Task<BaseResult> Handle(BaseTableEntity request, CancellationToken cancellationToken)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Database.Domain.BaseTable.EditBaseTable");

        // 调用基类方法执行更新操作并返回结果
        return await base.EditAsync(request);
    }
}