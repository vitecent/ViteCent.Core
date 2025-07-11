﻿#region

// 引入 MediatR 用于实现中介者模式
using MediatR;

// 引入 ASP.NET Core MVC 核心功能
using Microsoft.AspNetCore.Mvc;

// 引入基础数据传输对象

// 引入基础日志数据传输对象
using ViteCent.Auth.Data.BaseLogs;

// 引入用户信息相关的数据传输对象
using ViteCent.Auth.Data.BaseUser;
using ViteCent.Auth.Entity.BaseUser;

// 引入核心
using ViteCent.Core;
using ViteCent.Core.Cache;

// 引入核心数据类型
using ViteCent.Core.Data;
using ViteCent.Core.Enums;

// 引入核心接口基类
using ViteCent.Core.Web.Api;

// 引入核心过滤器
using ViteCent.Core.Web.Filter;

#endregion

namespace ViteCent.Auth.Api.BaseUser;

/// <summary>
/// 重置密码接口
/// </summary>
/// <param name="logger">日志记录器，用于记录处理器的操作日志</param>
/// <param name="httpContextAccessor">HTTP上下文访问器，用于获取当前用户信息</param>
/// <param name="cache">缓存器，用于处理缓存信息</param>
/// <param name="mediator">中介者，用于发送查询请求</param>
[ApiController] // 标记为 API 接口
// 使用登录过滤器，确保用户已登录
[ServiceFilter(typeof(BaseLoginFilter))]
// 设置路由前缀
[Route("BaseUser")]
public class ChangePasword(
    // 注入日志记录器
    ILogger<ChangePasword> logger,
    // 注入HTTP上下文访问器
    IHttpContextAccessor httpContextAccessor,
    // 注入缓存器
    IBaseCache cache,
    // 注入中介者
    IMediator mediator)
    // 继承基类，指定查询参数和返回结果类型
    : BaseApi<ChangePaswordArgs, BaseResult>
{
    /// <summary>
    /// 用户信息
    /// </summary>
    private readonly BaseUserInfo user = httpContextAccessor.InitUser();

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="args">请求参数</param>
    /// <returns>处理结果</returns>
    // 标记为 POST 请求
    [HttpPost]
    // 设置路由名称
    [Route("ChangePasword")]
    public override async Task<BaseResult> InvokeAsync(ChangePaswordArgs args)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Auth.Api.BaseUser.ChangePasword");

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
            SystemName = "Auth",
            ResourceId = string.Empty,
            ResourceName = "BaseUser",
            OperationId = string.Empty,
            OperationName = "Pasword",
            Description = "重置密码",
            Args = args.ToJson()
        };

        // 创建数据验证器
        var validator = new ChangePaswordValidator();

        // 验证用户信息的有效性
        var check = await validator.ValidateAsync(args, cancellationToken);

        // 如果验证失败，返回错误信息
        if (!check.IsValid)
        {
            // 记录失败操作日志
            await mediator.LogError(logsArgs, check.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty, cancellationToken);

            // 返回操作结果
            return new BaseResult(500, check.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty);
        }

        args.OriginalPassword = $"{user.Name}{args.OriginalPassword}{BaseConst.Salf}".EncryptMD5();

        var requert = new LoginEntityArgs
        {
            Username = user.Code,
            Password = args.OriginalPassword
        };

        var entity = await mediator.Send(requert, cancellationToken);

        if (entity is null)
            return new DataResult<LoginResult>(500, "用户名或密码错误");

        if (entity.Status == (int)StatusEnum.Disable)
            return new DataResult<LoginResult>(500, "用户已被禁用");

        args.Password = $"{entity.Username}{args.Password}{BaseConst.Salf}".EncryptMD5();

        entity.Password = args.Password;
        entity.Updater = user?.Name ?? string.Empty;
        entity.UpdateTime = DateTime.Now;
        entity.Version = DateTime.Now;

        var result = await mediator.Send(entity, cancellationToken);

        cache.DeleteKey($"User{user?.Id}");
        cache.DeleteKey($"UserInfo{user?.Id}");

        return result;
    }
}