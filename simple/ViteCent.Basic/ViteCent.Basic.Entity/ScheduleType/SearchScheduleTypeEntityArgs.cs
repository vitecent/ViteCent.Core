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

namespace ViteCent.Basic.Entity.ScheduleType;

/// <summary>
/// 搜索基础排班模型参数
/// </summary>
[Serializable]
public class SearchScheduleTypeEntityArgs : SearchArgs, IRequest<List<ScheduleTypeEntity>>
{
}