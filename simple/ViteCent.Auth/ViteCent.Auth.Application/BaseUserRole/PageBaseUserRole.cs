/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * 如需扩展该类，请在partial类中实现
 * **********************************
 */

#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ViteCent.Auth.Data.BaseUserRole;
using ViteCent.Auth.Entity.BaseUserRole;
using ViteCent.Core.Data;

#endregion

namespace ViteCent.Auth.Application.BaseUserRole;

/// <summary>
/// 用户角色分页应用
/// </summary>
/// <param name="logger"></param>
/// <param name="mapper"></param>
/// <param name="mediator"></param>
/// <param name="httpContextAccessor"></param>
public partial class PageBaseUserRole(
    ILogger<PageBaseUserRole> logger,
    IMapper mapper,
    IMediator mediator,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<SearchBaseUserRoleArgs, PageResult<BaseUserRoleResult>>
{
    /// <summary>
    /// 用户信息
    /// </summary>
    private BaseUserInfo user = new();

    /// <summary>
    /// 用户角色分页
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PageResult<BaseUserRoleResult>> Handle(SearchBaseUserRoleArgs request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Invoke ViteCent.Auth.Application.BaseUserRole.PageBaseUserRole");

        user = httpContextAccessor.InitUser();

        var args = mapper.Map<SearchBaseUserRoleEntityArgs>(request);

        OverrideHandle(args, user);

        var list = await mediator.Send(args, cancellationToken);

        var rows = mapper.Map<List<BaseUserRoleResult>>(list);

        var result = new PageResult<BaseUserRoleResult>(args.Offset, args.Limit, args.Total, rows);

        return result;
    }
}