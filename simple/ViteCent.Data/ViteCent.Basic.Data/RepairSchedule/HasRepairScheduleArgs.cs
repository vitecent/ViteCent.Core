#region

using MediatR;
using ViteCent.Core.Data;

#endregion

namespace ViteCent.Basic.Data.RepairSchedule;

/// <summary>
/// </summary>
[Serializable]
public class HasRepairScheduleEntityArgs : BaseArgs, IRequest<BaseResult>
{
    /// <summary>
    /// </summary>
    public string CompanyId { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public string DepartmentId { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public RepairTypeEnum RepairType { get; set; }

    /// <summary>
    /// </summary>
    public string ScheduleId { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public string UserId { get; set; } = string.Empty;
}