/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViteCent.Basic.Data.UserLeave;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;
using ViteCent.Core.Web.Api;
using ViteCent.Core.Web.Filter;

#endregion

namespace ViteCent.Basic.Api.UserLeave;

/// <summary>
/// 获取请假申请接口
/// </summary>
/// <param name="logger"></param>
/// <param name="mediator"></param>
[ApiController]
[ServiceFilter(typeof(BaseLoginFilter))]
[Route("UserLeave")]
public class GetUserLeave(
    ILogger<GetUserLeave> logger,
    IMediator mediator)
    : BaseLoginApi<GetUserLeaveArgs, DataResult<UserLeaveResult>>
{
    /// <summary>
    /// 获取请假申请
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [HttpPost]
    [TypeFilter(typeof(BaseAuthFilter), Arguments = new object[] { "Basic", "UserLeave", "Get" })]
    [Route("Get")]
    public override async Task<DataResult<UserLeaveResult>> InvokeAsync(GetUserLeaveArgs args)
    {
        logger.LogInformation("Invoke ViteCent.Basic.Api.UserLeave.GetUserLeave");

        if (args == null)
            return new DataResult<UserLeaveResult>(500, "参数不能为空");

        if (User.IsSuper != (int)YesNoEnum.Yes)
            if (string.IsNullOrEmpty(args.CompanyId))
                return new DataResult<UserLeaveResult>(500, "公司标识不能为空");

        var check = User.CheckCompanyId(args.CompanyId);

        if (check != null && !check.Success)
            return new DataResult<UserLeaveResult>(check.Code, check.Message);

        if (User.IsSuper != (int)YesNoEnum.Yes)
            if (string.IsNullOrEmpty(args.DepartmentId))
                return new DataResult<UserLeaveResult>(500, "部门标识不能为空");

        if (User.IsSuper != (int)YesNoEnum.Yes)
            if (string.IsNullOrEmpty(args.UserId))
                return new DataResult<UserLeaveResult>(500, "用户标识不能为空");

        return await mediator.Send(args);
    }
}