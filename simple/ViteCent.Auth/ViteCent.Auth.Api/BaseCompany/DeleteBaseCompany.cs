/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViteCent.Auth.Data.BaseCompany;
using ViteCent.Core.Data;
using ViteCent.Core.Web.Api;
using ViteCent.Core.Web.Filter;

#endregion

namespace ViteCent.Auth.Api.BaseCompany;

/// <summary>
/// 删除公司信息接口
/// </summary>
/// <param name="logger"></param>
/// <param name="mediator"></param>
[ApiController]
[ServiceFilter(typeof(BaseLoginFilter))]
[Route("BaseCompany")]
public class DeleteBaseCompany(
    ILogger<DeleteBaseCompany> logger,
    IMediator mediator)
    : BaseLoginApi<DeleteBaseCompanyArgs, BaseResult>
{
    /// <summary>
    /// 删除公司信息
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [HttpPost]
    [TypeFilter(typeof(BaseAuthFilter), Arguments = new object[] { "Auth", "BaseCompany", "Delete" })]
    [Route("Delete")]
    public override async Task<BaseResult> InvokeAsync(DeleteBaseCompanyArgs args)
    {
        logger.LogInformation("Invoke ViteCent.Auth.Api.BaseCompany.DeleteBaseCompany");

        if (args == null)
            return new BaseResult(500, "参数不能为空");

        return await mediator.Send(args);
    }
}