/*
 * 代码由工具自动生成
 * 重新生成时，不会覆盖原有代码
 */

#region

using MediatR;
using ViteCent.Auth.Data.BaseCompany;
using ViteCent.Auth.Data.BaseDepartment;
using ViteCent.Auth.Data.BaseUser;
using ViteCent.Basic.Data.UserRest;
using ViteCent.Basic.Entity.UserRest;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;
using ViteCent.Core.Web;

#endregion

namespace ViteCent.Basic.Application.UserRest;

/// <summary>
/// </summary>
public partial class AddUserRest
{
    /// <summary>
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="request"></param>
    /// <param name="user"></param>
    /// <param name="companyInvoke"></param>
    /// <param name="departmentInvoke"></param>
    /// <param name="userInvoke"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    internal static async Task<BaseResult> OverrideHandle(IMediator mediator, AddUserRestListArgs request,
        BaseUserInfo user,
        IBaseInvoke<SearchBaseCompanyArgs, PageResult<BaseCompanyResult>> companyInvoke,
        IBaseInvoke<SearchBaseDepartmentArgs, PageResult<BaseDepartmentResult>> departmentInvoke,
        IBaseInvoke<SearchBaseUserArgs, PageResult<BaseUserResult>> userInvoke, CancellationToken cancellationToken)
    {
        var companyId = user?.Company?.Id ?? string.Empty;
        var departmentId = user?.Department?.Id ?? string.Empty;

        foreach (var item in request.Items)
        {
            if (string.IsNullOrWhiteSpace(item.CompanyId))
                item.CompanyId = companyId;

            if (string.IsNullOrWhiteSpace(item.DepartmentId))
                item.DepartmentId = departmentId;
        }

        var companyIds = request.Items.Select(x => x.CompanyId).Distinct().ToList();
        var departmentIds = request.Items.Select(x => x.DepartmentId).Distinct().ToList();
        var userIds = request.Items.Select(x => x.UserId).Distinct().ToList();

        var companys = await companyInvoke.CheckCompanys(companyIds, user?.Token ?? string.Empty);

        if (!companys.Success)
            return companys;

        foreach (var item in companys.Rows)
        {
            var items = request.Items.Where(x => x.CompanyId == item.Id).ToList();

            foreach (var data in items)
                data.CompanyName = item.Name;
        }

        var departments =
            await departmentInvoke.CheckDepartments(companyIds, departmentIds, user?.Token ?? string.Empty);

        if (!departments.Success)
            return departments;

        foreach (var item in departments.Rows)
        {
            var items = request.Items.Where(x => x.DepartmentId == item.Id).ToList();

            foreach (var data in items)
                data.DepartmentName = item.Name;
        }

        var users = await userInvoke.CheckUsers(companyIds, departmentIds, [], userIds, user?.Token ?? string.Empty);

        if (!users.Success)
            return users;

        foreach (var item in users.Rows)
        {
            var items = request.Items.Where(x => x.UserId == item.Id).ToList();

            foreach (var data in items)
                data.UserName = item.RealName;
        }

        var hasListArgs = new HasUserRestEntityListArgs
        {
            CompanyIds = companyIds,
            DepartmentIds = departmentIds,
            UserIds = userIds,
            StartTime = request.Items.Min(x => x.StartTime),
            EndTime = request.Items.Max(x => x.EndTime)
        };

        return await mediator.Send(hasListArgs, cancellationToken);
    }

    /// <summary>
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="topic"></param>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    internal static async Task OverrideTopic(IMediator mediator, TopicEnum topic, UserRestEntity entity,
        CancellationToken cancellationToken)
    {
        await Task.FromResult(0);
    }

    /// <summary>
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<BaseResult> OverrideHandle(AddUserRestArgs request, CancellationToken cancellationToken)
    {
        var companyId = user?.Company?.Id ?? string.Empty;

        if (string.IsNullOrWhiteSpace(request.CompanyId))
            request.CompanyId = companyId;

        var hasCompany = await companyInvoke.CheckCompany(request.CompanyId, user?.Token ?? string.Empty);

        if (!hasCompany.Success)
            return hasCompany;

        request.CompanyName = hasCompany?.Data?.Name;

        var departmentId = user?.Department?.Id ?? string.Empty;

        if (string.IsNullOrWhiteSpace(request.DepartmentId))
            request.DepartmentId = departmentId;

        var hasDepartment =
            await departmentInvoke.CheckDepartment(request.CompanyId, request.DepartmentId,
                user?.Token ?? string.Empty);

        if (!hasDepartment.Success)
            return hasDepartment;

        request.DepartmentName = hasDepartment?.Data?.Name;

        var hasUser = await userInvoke.CheckUser(request.CompanyId, request.DepartmentId, string.Empty, request.UserId,
            user?.Token ?? string.Empty);

        if (!hasUser.Success)
            return hasUser;

        request.UserName = hasUser?.Data?.RealName;

        var hasArgs = new HasUserRestEntityArgs
        {
            CompanyId = request.CompanyId,
            DepartmentId = request.DepartmentId,
            UserId = request.UserId
        };

        return await mediator.Send(hasArgs, cancellationToken);
    }
}