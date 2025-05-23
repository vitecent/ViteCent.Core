﻿namespace ViteCent.Core.Data;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public class KeyValue<T>
    where T : class
{
    /// <summary>
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public T Value { get; set; } = default!;
}