﻿#region

// 引入 MediatR 用于实现中介者模式
using AutoMapper;
using MediatR;

// 引入 ASP.NET Core MVC 核心功能
using Microsoft.AspNetCore.Mvc;

// 引入基础日志数据传输对象
using ViteCent.Auth.Data.BaseLogs;

// 引入用户信息相关的数据传输对象
using ViteCent.Auth.Data.BaseUser;

// 引入核心
using ViteCent.Core;

// 引入核心数据类型
using ViteCent.Core.Data;
using ViteCent.Core.Enums;

// 引入核心接口基类
using ViteCent.Core.Web.Api;

// 引入核心过滤器

#endregion

namespace ViteCent.Auth.Api.BaseUser;

/// <summary>
/// 初始化接口
/// </summary>
/// <param name="logger">日志记录器，用于记录处理器的操作日志</param>
/// <param name="mapper">对象映射器，用于参数和模型对象之间的转换</param>
/// <param name="mediator">中介者，用于发送查询请求</param>
[ApiController] // 标记为 API 接口
// 设置路由前缀
[Route("BaseUser")]
public class Initialize(
    // 注入日志记录器
    ILogger<Initialize> logger,
    // 注入对象映射器
    IMapper mapper,
    // 注入中介者
    IMediator mediator)
    // 继承基类，指定查询参数和返回结果类型
    : BaseApi<InitializeArgs, BaseResult>
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="args">请求参数</param>
    /// <returns>初始化结果</returns>
    [HttpPost] // 标记为 POST 请求
    // 设置路由名称
    [Route("Initialize")]
    public override async Task<BaseResult> InvokeAsync(InitializeArgs args)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Auth.Api.BaseUser.Initialize");

        if (string.IsNullOrEmpty(args.Username) && !string.IsNullOrWhiteSpace(args.RealName))
            args.Username = args.RealName.GetPinYin().ToCamelCase();

        if (string.IsNullOrEmpty(args.Password))
            args.Password = BaseConst.DefaultPassword;

        // 创建取消令牌，用于支持操作的取消
        var cancellationToken = new CancellationToken();

        // 创建日志参数对象，用于记录操作日志
        var logsArgs = new AddBaseLogsArgs()
        {
            CompanyId = string.Empty,
            CompanyName = string.Empty,
            DepartmentId = string.Empty,
            DepartmentName = string.Empty,
            SystemId = string.Empty,
            SystemName = "Auth",
            ResourceId = string.Empty,
            ResourceName = "BaseUser",
            OperationId = string.Empty,
            OperationName = "Initialize",
            Description = "初始化",
            Args = args.ToJson()
        };

        var addArgs = mapper.Map<AddBaseUserArgs>(args);
        addArgs.IsSuper = (int)YesNoEnum.Yes;

        var validator = new BaseUserValidator(false);

        var result = await validator.ValidateAsync(addArgs, cancellationToken);

        if (!result.IsValid)
        {
            var message = string.Join(",", result.Errors.Select(x => x.ErrorMessage));

            return new BaseResult(500, message);
        }

        var chackArgs = new PreInitializeArgs();

        var check = await mediator.Send(chackArgs, cancellationToken);

        if (!check.Data.Flag)
            return new BaseResult(500, "系统已初始化");

        return await mediator.Send(addArgs, cancellationToken);
    }
}