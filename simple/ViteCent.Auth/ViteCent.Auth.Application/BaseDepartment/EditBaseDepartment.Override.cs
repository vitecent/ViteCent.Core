﻿/*
 * 代码由工具自动生成
 * 重新生成时，不会覆盖原有代码
 */

#region

using ViteCent.Auth.Data.BaseDepartment;
using ViteCent.Auth.Entity.BaseDepartment;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;

#endregion

namespace ViteCent.Auth.Application.BaseDepartment;

/// <summary>
/// </summary>
public partial class EditBaseDepartment
{
    /// <summary>
    /// </summary>
    /// <param name="entity">数据库模型</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>处理结果</returns>
    private async Task<BaseResult> OverrideHandle(BaseDepartmentEntity entity, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new BaseResult());
    }

    /// <summary>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>处理结果</returns>
    private async Task<BaseResult> OverrideHandle(EditBaseDepartmentArgs request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.ParentId))
        {
            var hasParentArgs = new GetBaseDepartmentEntityArgs
            {
                CompanyId = request.CompanyId,
                Id = request.ParentId
            };

            var hasParent = await mediator.Send(hasParentArgs, cancellationToken);

            if (hasParent is null)
                return new BaseResult(500, "父级部门不存在");

            if (hasParent.Status == (int)StatusEnum.Disable)
                return new BaseResult(500, "父级部门已禁用");

            if (string.IsNullOrWhiteSpace(hasParent.Level))
                request.Level = hasParent.Id;
            else
                request.Level = $"{hasParent.Level},{hasParent.Id}";
        }

        var companyId = user?.Company?.Id ?? string.Empty;

        if (string.IsNullOrWhiteSpace(request.CompanyId))
            request.CompanyId = companyId;

        var hasCompany = await mediator.CheckCompany(request.CompanyId);

        if (!hasCompany.Success)
            return hasCompany;

        request.CompanyName = hasCompany?.Data?.Name;

        var hasArgs = new HasBaseDepartmentEntityArgs
        {
            Id = request.Id,
            CompanyId = request.CompanyId,
            Code = request.Code,
            Name = request.Name
        };

        return await mediator.Send(hasArgs, cancellationToken);
    }
}