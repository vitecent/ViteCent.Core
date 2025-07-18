/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * 如需扩展该类，请在partial类中实现
 * **********************************
 */

#region 引入命名空间

// 引入 MediatR 用于实现中介者模式
using MediatR;

// 引入 Asp.Net Core Mvc 核心功能
using Microsoft.AspNetCore.Mvc;

// 引入日志信息相关的数据参数
using ViteCent.Basic.Data.BaseLogs;

// 引入核心数据类型
using ViteCent.Core.Data;

// 引入核心接口基类
using ViteCent.Core.Web.Api;

// 引入核心过滤器
using ViteCent.Core.Web.Filter;

#endregion 引入命名空间

namespace ViteCent.Basic.Api.BaseLogs;

/// <summary>
/// 新增日志信息接口
/// </summary>
/// <remarks>
/// 该接口负责处理新增日志信息的请求，主要功能包括：
/// 1. 验证用户登录状态
/// 2. 验证用户权限
/// 3. 验证新增数据的有效性
/// 4. 设置新增日志信息的请求
/// 5. 返回操作结果
/// </remarks>
/// <param name="logger">日志记录器，用于记录处理器的操作日志</param>
/// <param name="httpContextAccessor">HTTP上下文访问器，用于获取当前用户信息</param>
/// <param name="mediator">中介者，用于发送查询请求</param>
[ApiController] // 标记为 Api 接口
// 使用登录过滤器，确保用户已登录
[ServiceFilter(typeof(BaseLoginFilter))]
// 设置路由前缀
[Route("BaseLogs")]
public partial class AddBaseLogs(
    // 注入日志记录器
    ILogger<AddBaseLogs> logger,
    // 注入HTTP上下文访问器
    IHttpContextAccessor httpContextAccessor,
    // 注入中介者
    IMediator mediator)
    // 继承基类，指定查询参数和返回结果类型
    : BaseApi<AddBaseLogsArgs, BaseResult>
{
    /// <summary>
    /// 用户信息
    /// </summary>
    private readonly BaseUserInfo user = httpContextAccessor.InitUser();

    /// <summary>
    /// 新增日志信息
    /// </summary>
    /// <remarks>
    /// 该方法主要完成以下功能：
    /// 1. 记录方法调用日志，便于追踪和调试
    /// 2. 重写调用方法
    /// 3. 创建取消令牌和数据验证器
    /// 4. 验证日志信息的有效性
    /// 5. 通过中介者发送新增命令
    /// 6. 返回操作结果
    /// </remarks>
    /// <param name="args">新增日志信息的参数</param>
    /// <returns>返回新增操作的结果</returns>
    [HttpPost] // 标记为 Post 请求
    // 使用权限验证过滤器，验证用户是否有权限访问该接口
    [TypeFilter(typeof(BaseAuthFilter), Arguments = new object[] { "Basic", "BaseLogs", "Add" })]
    // 设置路由名称
    [Route("Add")]
    public override async Task<BaseResult> InvokeAsync(AddBaseLogsArgs args)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Basic.Api.BaseLogs.AddBaseLogs");

        // 重写调用方法
        OverrideInvoke(args, user);

        // 创建取消令牌，用于支持操作的取消
        var cancellationToken = new CancellationToken();

        // 创建数据验证器
        var validator = new BaseLogsValidator();

        // 验证日志信息的有效性
        var check = await validator.ValidateAsync(args, cancellationToken);

        // 如果验证失败，返回错误信息
        if (!check.IsValid)
        {
            // 返回操作结果
            return new BaseResult(500, check.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty);
        }

        // 通过中介者发送新增命令并返回结果
        var result = await mediator.Send(args, cancellationToken);

        // 返回操作结果
        return result;
    }
}