/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

#region 引入命名空间

// 引入ORM基础设施
using SqlSugar;

#endregion 引入命名空间

namespace ViteCent.Auth.Entity.BaseLogs;

/// <summary>
/// 新增日志信息模型
/// </summary>
[Serializable]
[SplitTable(SplitType.Year)]
[SugarTable("base_logs_{year}{month}{day}")]
public class AddBaseLogsEntity : BaseLogsEntity
{
}