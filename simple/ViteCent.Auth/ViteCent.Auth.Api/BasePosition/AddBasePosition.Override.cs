/*
 * 代码由工具自动生成
 * 重新生成时，不会覆盖原有代码
 */

#region

using ViteCent.Auth.Data.BasePosition;
using ViteCent.Core;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;

#endregion

namespace ViteCent.Auth.Api.BasePosition;

/// <summary>
/// </summary>
public partial class AddBasePosition
{
    /// <summary>
    /// </summary>
    /// <param name="args"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    internal static void OverrideInvoke(AddBasePositionArgs args, BaseUserInfo user)
    {
        args.Status = (int)StatusEnum.Enable;

        if (string.IsNullOrEmpty(args.CompanyId))
            args.CompanyId = user?.Company?.Id ?? string.Empty;

        if (string.IsNullOrWhiteSpace(args.Code) && !string.IsNullOrWhiteSpace(args.Name))
            args.Code = args.Name.GetPinYin().ToCamelCase();
    }
}