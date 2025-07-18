/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * 如需扩展该类，请在partial类中实现
 * **********************************
 */

#region 引入命名空间

// 引入 FluentValidation 核心
using FluentValidation;

#endregion 引入命名空间

namespace ViteCent.Auth.Data.BaseResource;

/// <summary>
/// 资源信息验证器
/// </summary>
[Serializable]
public partial class BaseResourceValidator : AbstractValidator<AddBaseResourceArgs>
{
    /// <summary>
    /// 验证资源信息
    /// </summary>
    /// <param name="validate">是否验证</param>
    public BaseResourceValidator(bool validate = true)
    {
        // 验证参数不能为空
        RuleFor(x => x).NotNull().WithMessage("参数不能为空");

        // 验证公司标识不能为空
        RuleFor(x => x.CompanyId).NotNull().NotEmpty().WithMessage("公司标识不能为空");

        // 验证名称不能为空
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("名称不能为空");

        // 验证系统标识不能为空
        RuleFor(x => x.SystemId).NotNull().NotEmpty().WithMessage("系统标识不能为空");

        // 调用扩展方法进行额外验证
        OverrideValidator(validate);
    }
}