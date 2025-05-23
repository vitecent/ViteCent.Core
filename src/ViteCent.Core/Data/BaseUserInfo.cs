﻿namespace ViteCent.Core.Data;

/// <summary>
/// </summary>
public class BaseUserInfo
{
    /// <summary>
    /// </summary>
    public List<string> Auth { get; set; } = [];

    /// <summary>
    /// </summary>
    public List<BaseSystemInfo> AuthInfo { get; set; } = [];

    /// <summary>
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public BaseCompanyInfo Company { get; set; } = new();

    /// <summary>
    /// </summary>
    public BaseDepartmentInfo Department { get; set; } = new();

    /// <summary>
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public int IsSuper { get; set; }

    /// <summary>
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public BasePositionInfo Position { get; set; } = new();

    /// <summary>
    /// </summary>
    public string Token { get; set; } = string.Empty;
}