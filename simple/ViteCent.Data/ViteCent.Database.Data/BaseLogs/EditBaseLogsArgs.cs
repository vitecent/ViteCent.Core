/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * **********************************
 */

namespace ViteCent.Database.Data.BaseLogs;

/// <summary>
/// 编辑日志信息参数
/// </summary>
[Serializable]
public class EditBaseLogsArgs : AddBaseLogsArgs
{
    /// <summary>
    /// 标识
    /// </summary>
    public string Id { get; set; } = string.Empty;
}