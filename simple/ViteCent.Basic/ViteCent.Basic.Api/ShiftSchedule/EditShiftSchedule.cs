/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region 引入命名空间

// 引入 MediatR 用于实现中介者模式
using MediatR;

// 引入 Asp.Net Core Mvc 核心功能
using Microsoft.AspNetCore.Mvc;

// 引入基础日志数据参数
using ViteCent.Basic.Data.BaseLogs;

// 引入换班申请相关的数据参数
using ViteCent.Basic.Data.ShiftSchedule;

// 引入核心
using ViteCent.Core;

// 引入核心数据类型
using ViteCent.Core.Data;

// 引入核心接口基类
using ViteCent.Core.Web.Api;

// 引入核心过滤器
using ViteCent.Core.Web.Filter;

#endregion 引入命名空间

namespace ViteCent.Basic.Api.ShiftSchedule;

/// <summary>
/// 编辑换班申请接口
/// </summary>
/// <remarks>
/// 该接口负责处理编辑换班申请的请求，主要功能包括：
/// 1. 验证用户登录状态
/// 2. 验证用户权限
/// 3. 验证编辑数据的有效性
/// 4. 处理编辑换班申请的请求
/// 5. 返回操作结果
/// </remarks>
/// <param name="logger">日志记录器，用于记录接口的操作日志</param>
/// <param name="httpContextAccessor">HTTP上下文访问器，用于获取当前用户信息</param>
/// <param name="mediator">中介者，用于发送命令请求</param>
[ApiController] // 标记为 Api 接口
// 使用登录过滤器，确保用户已登录
[ServiceFilter(typeof(BaseLoginFilter))]
// 设置路由前缀
[Route("ShiftSchedule")]
public partial class EditShiftSchedule(
    // 注入日志记录器
    ILogger<EditShiftSchedule> logger,
    // 注入HTTP上下文访问器
    IHttpContextAccessor httpContextAccessor,
    // 注入中介者
    IMediator mediator)
    // 继承基类，指定查询参数和返回结果类型
    : BaseApi<EditShiftScheduleArgs, BaseResult>
{
    /// <summary>
    /// 用户信息
    /// </summary>
    private readonly BaseUserInfo user = httpContextAccessor.InitUser();

    /// <summary>
    /// 编辑换班申请
    /// </summary>
    /// <remarks>
    /// 该方法实现了以下功能：
    /// 1. 记录方法调用日志，便于追踪和调试
    /// 2. 创建取消令牌
    /// 3. 验证编辑数据的有效性
    /// 4. 通过中介者发送编辑命令
    /// 5. 返回操作结果
    /// </remarks>
    /// <param name="args">编辑参数，包含需要更新的换班申请数据</param>
    /// <returns>返回基础结果对象，标识操作是否成功</returns>
    [HttpPost] // 标记为 Post 请求
    // 权限验证过滤器，验证用户是否有权限访问该接口
    [TypeFilter(typeof(BaseAuthFilter), Arguments = new object[] { "Basic", "ShiftSchedule", "Edit" })]
    // 设置路由名称
    [Route("Edit")]
    public override async Task<BaseResult> InvokeAsync(EditShiftScheduleArgs args)
    {
        // 记录方法调用日志，便于追踪和调试，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Basic.Api.ShiftSchedule.EditShiftSchedule");

        // 重写调用方法
        OverrideInvoke(args, user);

        // 创建取消令牌，用于支持操作的取消
        var cancellationToken = new CancellationToken();

        // 创建日志参数对象，用于记录操作日志
        var logsArgs = new AddBaseLogsArgs()
        {
            CompanyId = user?.Company?.Id ?? string.Empty,
            CompanyName = user?.Company?.Name ?? string.Empty,
            DepartmentId = user?.Department?.Id ?? string.Empty,
            DepartmentName = user?.Department?.Name ?? string.Empty,
            SystemId = string.Empty,
            SystemName = "Basic",
            ResourceId = string.Empty,
            ResourceName = "ShiftSchedule",
            OperationId = string.Empty,
            OperationName = "Edit",
            Description = "编辑换班申请",
            Args = args.ToJson()
        };

        // 创建数据验证器
        var validator = new ShiftScheduleValidator(true);

        // 验证参数有效性
        var check = await validator.ValidateAsync(args, cancellationToken);

        // 如果验证失败，返回错误信息
        if (!check.IsValid)
        {
            // 记录失败操作日志
            await mediator.LogError(logsArgs, check.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty, cancellationToken);

            // 返回操作结果
            return new BaseResult(500, check.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty);
        }

        // 通过中介者发送编辑命令并返回结果
        var result = await mediator.Send(args, cancellationToken);

        // 记录失败操作日志
        if (!result.Success)
            await mediator.LogError(logsArgs, result.Message, cancellationToken);

        // 记录成功操作日志
        await mediator.LogSuccess(logsArgs, cancellationToken);

        // 返回操作结果
        return result;
    }
}