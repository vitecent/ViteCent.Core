/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region

using MediatR;
using ViteCent.Core.Data;

#endregion

namespace ViteCent.Auth.Entity.BaseRolePermission;

/// <summary>
/// 搜索角色权限模型参数
/// </summary>
[Serializable]
public class SearchBaseRolePermissionEntityArgs : SearchArgs, IRequest<List<BaseRolePermissionEntity>>
{
}