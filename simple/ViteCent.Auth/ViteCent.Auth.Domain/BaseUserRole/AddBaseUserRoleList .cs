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

// 引入用户角色相关的数据模型
using ViteCent.Auth.Entity.BaseUserRole;

// 引入核心数据类型
using ViteCent.Core.Data;

// 引入ORM基础设施
using ViteCent.Core.Orm.SqlSugar;

#endregion 引入命名空间

namespace ViteCent.Auth.Domain.BaseUserRole;

/// <summary>
/// 批量新增用户角色领域服务类
/// </summary>
/// <remarks>该类负责处理批量新增用户角色的业务逻辑 继承自 BaseDomain 基类并实现 IRequestHandler 接口 通过依赖注入方式接收日志记录器，用于记录操作日志</remarks>
/// <param name="logger">日志记录器实例</param>
public class AddBaseUserRoleList(
    // 注入日志记录器
    ILogger<AddBaseUserRoleList> logger)
    : BaseDomain<AddBaseUserRoleEntity>, IRequestHandler<AddBaseUserRoleEntityListArgs, BaseResult>
{
    /// <summary>
    /// 数据库名称
    /// </summary>
    public override string Database => "ViteCent.Auth";

    /// <summary>
    /// 处理批量新增用户角色的请求
    /// </summary>
    /// <remarks>实现 IRequestHandler 接口的 Handle 方法 记录操作日志并调用基类的 AddAsync 方法执行批量新增操作</remarks>
    /// <param name="request">包含要新增的用户角色列表的请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>返回批量新增操作的结果</returns>
    public async Task<BaseResult> Handle(AddBaseUserRoleEntityListArgs request, CancellationToken cancellationToken)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Auth.Domain.BaseUserRole.AddBaseUserRoleList");

        // 调用基类的批量新增方法，传入请求中的用户角色列表
        return await base.AddAsync(request.Items);
    }
}