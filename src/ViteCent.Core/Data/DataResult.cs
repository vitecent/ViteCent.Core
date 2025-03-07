﻿namespace ViteCent.Core.Data;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataResult<T> : BaseResult
    where T : class
{
    /// <summary>
    /// </summary>
    public DataResult()
    {
    }

    /// <summary>
    /// </summary>
    /// <param name="data"></param>
    public DataResult(T data)
    {
        Data = data;
    }

    /// <summary>
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public DataResult(int code, string message) : base(code, message)
    {
    }

    /// <summary>
    /// </summary>
    /// <value>The data.</value>
    public T Data { get; set; } = default!;
}