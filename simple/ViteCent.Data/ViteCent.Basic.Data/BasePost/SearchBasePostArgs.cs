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

namespace ViteCent.Basic.Data.BasePost;

/// <summary>
/// 搜索职位信息参数
/// </summary>
[Serializable]
public class SearchBasePostArgs : SearchArgs, IRequest<PageResult<BasePostResult>>
{
}