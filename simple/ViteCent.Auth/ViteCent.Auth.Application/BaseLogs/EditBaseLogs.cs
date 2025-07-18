/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * 如需扩展该类，请在partial类中实现
 * **********************************
 */

#region 引入命名空间

// 引入 AutoMapper 用于对象映射
using AutoMapper;

// 引入 MediatR 用于实现中介者模式
using MediatR;

// 引入 Asp.Net Core Mvc 核心功能
using Microsoft.AspNetCore.Http;

// 引入 Microsoft.Extensions.Logging 用于日志记录
using Microsoft.Extensions.Logging;

// 引入日志信息相关的数据参数
using ViteCent.Auth.Data.BaseLogs;

// 引入日志信息相关的数据模型
using ViteCent.Auth.Entity.BaseLogs;

// 引入核心数据类型
using ViteCent.Core.Data;

// 引入核心枚举类型
using ViteCent.Core.Enums;

#endregion 引入命名空间

namespace ViteCent.Auth.Application.BaseLogs;

/// <summary>
/// 编辑日志信息应用
/// </summary>
/// <param name="logger">日志记录器，用于记录处理器的操作日志</param>
/// <param name="mapper">对象映射器，用于参数和模型对象之间的转换</param>
/// <param name="mediator">中介者，用于发送查询请求</param>
/// <param name="httpContextAccessor">HTTP上下文访问器，用于获取当前用户信息</param>
public partial class EditBaseLogs(
    // 注入日志记录器
    ILogger<EditBaseLogs> logger,
    // 注入对象映射器
    IMapper mapper,
    // 注入中介者
    IMediator mediator,
    // 注入HTTP上下文访问器
    IHttpContextAccessor httpContextAccessor)
    // 继承基类，指定查询参数和返回结果类型
    : IRequestHandler<EditBaseLogsArgs, BaseResult>
{
    /// <summary>
    /// 用户信息
    /// </summary>
    private readonly BaseUserInfo user = httpContextAccessor.InitUser();

    /// <summary>
    /// 编辑日志信息
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>处理结果</returns>
    public async Task<BaseResult> Handle(EditBaseLogsArgs request, CancellationToken cancellationToken)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Auth.Application.BaseLogs.EditBaseLogs");

        var check = await OverrideHandle(request, cancellationToken);

        if (!check.Success)
            return check;

        var getArgs = mapper.Map<GetBaseLogsEntityArgs>(request);

        var entity = await mediator.Send(getArgs, cancellationToken);

        if (entity is null)
            return new BaseResult(500, "日志信息不存在");

        check = await OverrideHandle(entity, cancellationToken);

        if (!check.Success)
            return check;

        if (request.Args is not null)
            entity.Args = request.Args;

        entity.CompanyId = request.CompanyId;

        if (request.CompanyName is not null)
            entity.CompanyName = request.CompanyName;

        entity.DepartmentId = request.DepartmentId;

        if (request.DepartmentName is not null)
            entity.DepartmentName = request.DepartmentName;

        if (request.Description is not null)
            entity.Description = request.Description;

        entity.OperationId = request.OperationId;

        entity.OperationName = request.OperationName;

        entity.ResourceId = request.ResourceId;

        if (request.ResourceName is not null)
            entity.ResourceName = request.ResourceName;

        if (request.Status.HasValue)
            entity.Status = request.Status.Value;

        entity.SystemId = request.SystemId;

        if (request.SystemName is not null)
            entity.SystemName = request.SystemName;

        entity.Updater = user?.Name ?? string.Empty;
        entity.UpdateTime = DateTime.Now;
        entity.Version = DateTime.Now;

        var result = await mediator.Send(entity, cancellationToken);

        await AddBaseLogs.OverrideTopic(mediator, TopicEnum.Edit, entity, cancellationToken);

        return result;
    }
}