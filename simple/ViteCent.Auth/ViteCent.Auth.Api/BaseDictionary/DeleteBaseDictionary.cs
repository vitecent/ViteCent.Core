/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViteCent.Auth.Data.BaseDictionary;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;
using ViteCent.Core.Web.Api;
using ViteCent.Core.Web.Filter;

#endregion

namespace ViteCent.Auth.Api.BaseDictionary;

/// <summary>
/// 删除字典信息接口
/// </summary>
/// <param name="logger"></param>
/// <param name="mediator"></param>
[ApiController]
[ServiceFilter(typeof(BaseLoginFilter))]
[Route("BaseDictionary")]
public class DeleteBaseDictionary(
    ILogger<DeleteBaseDictionary> logger,
    IMediator mediator)
    : BaseLoginApi<DeleteBaseDictionaryArgs, BaseResult>
{
    /// <summary>
    /// 删除字典信息
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [HttpPost]
    [TypeFilter(typeof(BaseAuthFilter), Arguments = new object[] { "Auth", "BaseDictionary", "Delete" })]
    [Route("Delete")]
    public override async Task<BaseResult> InvokeAsync(DeleteBaseDictionaryArgs args)
    {
        logger.LogInformation("Invoke ViteCent.Auth.Api.BaseDictionary.DeleteBaseDictionary");

        if (args == null)
            return new BaseResult(500, "参数不能为空");

        if (User.IsSuper != (int)YesNoEnum.Yes)
            if (string.IsNullOrEmpty(args.CompanyId))
                return new BaseResult(500, "公司标识不能为空");

        var check = User.CheckCompanyId(args.CompanyId);

        if (check != null && !check.Success)
            return check;

        return await mediator.Send(args);
    }
}