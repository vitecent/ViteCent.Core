/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
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

// 引入调休申请相关的数据参数
using ViteCent.Basic.Data.UserRest;

// 引入调休申请相关的数据模型
using ViteCent.Basic.Entity.UserRest;

// 引入核心数据类型
using ViteCent.Core.Data;

#endregion 引入命名空间

namespace ViteCent.Basic.Application.UserRest;

/// <summary>
/// 获取调休申请处理器
/// </summary>
/// <remarks>
/// 该类负责处理获取单个调休申请的请求，主要功能包括：
/// 1. 接收并处理获取调休申请的请求参数
/// 2. 查询指定公司的详细信息
/// 3. 转换查询结果为响应格式
/// 4. 处理查询结果为空的情况
/// </remarks>
/// <param name="logger">日志记录器，用于记录处理器的操作日志</param>
/// <param name="mapper">对象映射器，用于参数和模型对象之间的转换</param>
/// <param name="mediator">中介者，用于发送查询请求</param>
/// <param name="httpContextAccessor">HTTP上下文访问器，用于获取当前用户信息</param>
public class GetUserRest(
    // 注入日志记录器
    ILogger<GetUserRest> logger,
    // 注入对象映射器
    IMapper mapper,
    // 注入中介者
    IMediator mediator,
    // 注入HTTP上下文访问器
    IHttpContextAccessor httpContextAccessor)
    // 继承基类，指定查询参数和返回结果类型
    : IRequestHandler<GetUserRestArgs, DataResult<UserRestResult>>
{
    /// <summary>
    /// 用户信息
    /// </summary>
    private readonly BaseUserInfo user = httpContextAccessor.InitUser();

    /// <summary>
    /// 处理获取调休申请的请求
    /// </summary>
    /// <remarks>
    /// 该方法实现了IRequestHandler接口的Handle方法，主要功能包括：
    /// 1. 记录方法调用日志
    /// 2. 将请求参数转换为模型查询参数
    /// 3. 执行调休申请查询
    /// 4. 处理查询结果为空的情况
    /// 5. 转换查询结果为响应参数
    /// </remarks>
    /// <param name="request">获取调休申请的请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>返回包含调休申请的数据结果对象</returns>
    public async Task<DataResult<UserRestResult>> Handle(GetUserRestArgs request,
        CancellationToken cancellationToken)
    {
        // 记录方法调用日志，便于追踪和调试
        logger.LogInformation("Invoke ViteCent.Basic.Application.UserRest.GetUserRest");

        // 将请求参数转换为模型查询参数
        var args = mapper.Map<GetUserRestEntityArgs>(request);

        // 通过中介者发送查询请求，获取公司模型信息
        var entity = await mediator.Send(args, cancellationToken);

        // 如果查询结果为空，返回错误信息
        if (entity is null)
            return new DataResult<UserRestResult>(500, "调休申请不存在");

        // 将模型对象转换为响应参数
        var dto = mapper.Map<UserRestResult>(entity);

        // 返回成功的数据结果
        return new DataResult<UserRestResult>(dto);
    }
}