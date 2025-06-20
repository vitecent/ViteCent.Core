﻿#region

using ViteCent.Core.Data;

#endregion

namespace ViteCent.Files.Api.Data;

/// <summary>
/// 获取文件参数类，用于文件相关操作的参数传递
/// </summary>
public class GetFileArgs : BaseArgs
{
    /// <summary>
    /// 文件路径，表示要获取的文件在系统中的相对路径
    /// </summary>
    public string Path { get; set; } = string.Empty;
}