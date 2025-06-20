/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region

using MediatR;

#endregion

namespace ViteCent.Auth.Entity.BaseCompany;

/// <summary>
/// 获取公司信息模型参数
/// </summary>
[Serializable]
public class GetBaseCompanyEntityArgs : IRequest<BaseCompanyEntity>
{
    /// <summary>
    /// 标识
    /// </summary>
    public string Id { get; set; } = string.Empty;
}