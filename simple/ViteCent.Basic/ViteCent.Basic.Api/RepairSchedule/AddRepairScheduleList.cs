/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * 如需扩展该类，请在partial类中实现
 * **********************************
 */

#region

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViteCent.Basic.Data.RepairSchedule;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;
using ViteCent.Core.Web.Api;
using ViteCent.Core.Web.Filter;

#endregion

namespace ViteCent.Basic.Api.RepairSchedule;

/// <summary>
/// 批量新增补卡申请接口
/// </summary>
/// <param name="logger"></param>
/// <param name="mediator"></param>
[ApiController]
[ServiceFilter(typeof(BaseLoginFilter))]
[Route("RepairSchedule")]
public class AddRepairScheduleList(
    ILogger<AddRepairScheduleList> logger,
    IMediator mediator)
    : BaseLoginApi<AddRepairScheduleListArgs, BaseResult>
{
    /// <summary>
    /// 批量新增补卡申请
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [HttpPost]
    [TypeFilter(typeof(BaseAuthFilter), Arguments = new object[] { "Basic", "RepairSchedule", "Add" })]
    [Route("AddList")]
    public override async Task<BaseResult> InvokeAsync(AddRepairScheduleListArgs args)
    {
        logger.LogInformation("Invoke ViteCent.Basic.Api.RepairSchedule.AddRepairScheduleList");

        if (args == null)
            return new BaseResult(500, "参数不能为空");

        if (args.Items.Count == 0)
            return new BaseResult(500, "补卡申请不能为空");

        var count = args.Items.Distinct().Count();

        if (count != args.Items.Count)
            return new BaseResult(500, "补卡申请重复");

        var cancellationToken = new CancellationToken();
        var validator = new RepairScheduleValidator();

        foreach (var item in args.Items)
        {
            AddRepairSchedule.OverrideInvoke(item, User);

            var check = await validator.ValidateAsync(item, cancellationToken);

            if (!check.IsValid)
                return new BaseResult(500, check.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty);

            if (User.IsSuper != (int)YesNoEnum.Yes)
                if (string.IsNullOrEmpty(item.CompanyId))
                    return new BaseResult(500, "公司标识不能为空");

            if (User.IsSuper != (int)YesNoEnum.Yes)
                if (string.IsNullOrEmpty(item.DepartmentId))
                    return new BaseResult(500, "部门标识不能为空");

            if (User.IsSuper != (int)YesNoEnum.Yes)
                if (string.IsNullOrEmpty(item.UserId))
                    return new BaseResult(500, "用户标识不能为空");
        }

        return await mediator.Send(args, cancellationToken);
    }
}