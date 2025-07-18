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

// 引入字典信息相关的数据模型
using ViteCent.Auth.Entity.BaseDictionary;

// 引入核心数据类型
using ViteCent.Core.Data;

// 引入ORM基础设施
using ViteCent.Core.Orm.SqlSugar;

#endregion 引入命名空间

namespace ViteCent.Auth.Domain.BaseDictionary;

/// <summary>
/// 删除字典信息领域服务类
/// </summary>
/// <remarks>该类负责处理字典信息的删除操作，继承自 BaseDomain 基类并实现 IRequestHandler 接口 通过依赖注入方式接收日志记录器，用于记录操作日志</remarks>
/// <param name="logger">日志记录器实例</param>
public class DeleteBaseDictionary(
    // 注入日志记录器
    ILogger<DeleteBaseDictionary> logger)
    : BaseDomain<DeleteBaseDictionaryEntity>, IRequestHandler<DeleteBaseDictionaryEntity, BaseResult>
{
    /// <summary>
    /// 数据库名称
    /// </summary>
    public override string Database => "ViteCent.Auth";

    /// <summary>
    /// 处理删除字典信息的请求
    /// </summary>
    /// <remarks>实现 IRequestHandler 接口的 Handle 方法 记录操作日志并调用基类的 DeleteAsync 方法执行实际的删除操作</remarks>
    /// <param name="request">包含要删除的字典信息的请求模型</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>返回删除操作的结果</returns>
    public async Task<BaseResult> Handle(DeleteBaseDictionaryEntity request, CancellationToken cancellationToken)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Auth.Domain.BaseDictionary.DeleteBaseDictionary");

        // 调用基类的删除方法执行实际的删除操作
        return await DeleteAsync(request);
    }
}