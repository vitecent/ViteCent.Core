﻿#region

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ViteCent.Auth.Data.BaseUser;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;

#endregion

namespace ViteCent.Auth.Application.BaseUser;

/// <summary>
/// 初始化仓储
/// </summary>
/// <param name="logger"></param>
/// <param name="mediator"></param>
/// <param name="mapper"></param>
public class Initialize(
    ILogger<Initialize> logger,
    IMediator mediator,
    IMapper mapper) : IRequestHandler<InitializeArgs, BaseResult>
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<BaseResult> Handle(InitializeArgs request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Invoke ViteCent.Auth.Application.BaseUser.Initialize");

        var args = mapper.Map<AddBaseUserArgs>(request);
        args.IsSuper = (int)YesNoEnum.Yes;

        var validator = new BaseUserValidator(true);
        var result = await validator.ValidateAsync(args, cancellationToken);

        if (!result.IsValid)
        {
            var message = string.Join(",", result.Errors.Select(x => x.ErrorMessage));

            return new BaseResult(500, message);
        }

        var chackArgs = new PreInitializeArgs();

        var check = await mediator.Send(chackArgs, cancellationToken);

        if (!check.Data.Flag)
            return new BaseResult(500, "系统已初始化");

        return await mediator.Send(args, cancellationToken);
    }
}