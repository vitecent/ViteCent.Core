#region

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViteCent.Auth.Application;
using ViteCent.Auth.Data.BaseRolePermission;
using ViteCent.Core.Data;
using ViteCent.Core.Web.Api;
using ViteCent.Core.Web.Filter;

#endregion

namespace ViteCent.Auth.Api.BaseRolePermission;

/// <summary>
/// 获取所有权限接口
/// </summary>
/// <param name="logger"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="mediator"></param>
[ApiController]
[ServiceFilter(typeof(BaseLoginFilter))]
[Route("BaseRolePermission")]
public class GetAllPermission(
    ILogger<GetAllPermission> logger,
    IHttpContextAccessor httpContextAccessor,
    IMediator mediator) : BaseApi<GetAllPermissionArgs, DataResult<AllPermissionResult>>
{
    /// <summary>
    /// 用户信息
    /// </summary>
    private readonly BaseUserInfo user = httpContextAccessor.InitUser();

    /// <summary>
    /// 获取角色权限
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [HttpPost]
    [TypeFilter(typeof(BaseAuthFilter), Arguments = new object[] { "Auth", "BaseRolePermission", "Get" })]
    [Route("All")]
    public override async Task<DataResult<AllPermissionResult>> InvokeAsync(GetAllPermissionArgs args)
    {
        logger.LogInformation("Invoke ViteCent.Auth.Api.BaseRolePermission.GetAllPermission");

        if (args is null)
            return new DataResult<AllPermissionResult>(500, "参数不能为空");

        if (string.IsNullOrEmpty(args.CompanyId))
            return new DataResult<AllPermissionResult>(500, "公司标识不能为空");

        return await mediator.Send(args);
    }
}