﻿#region

using StackExchange.Redis;
using ViteCent.Core.Data;
using ViteCent.Core.Enums;

#endregion

namespace ViteCent.Core.Cache.Redis;

/// <summary>
/// Redis缓存实现类，提供基于Redis的缓存功能
/// </summary>
public class RedisCache : IBaseCache
{
    /// <summary>
    /// Redis数据库实例，用于执行Redis操作
    /// </summary>
    private readonly IDatabase database;

    /// <summary>
    /// 初始化Redis缓存实例
    /// </summary>
    /// <param name="configuration">Redis连接配置字符串</param>
    /// <param name="db">Redis数据库索引，默认为0</param>
    public RedisCache(string configuration, int db = default)
    {
        var connectionMultiplexer = ConnectionMultiplexer.Connect(configuration);
        database = connectionMultiplexer.GetDatabase(db);
    }

    /// <summary>
    /// 删除指定键的缓存数据
    /// </summary>
    /// <param name="key">要删除的缓存键</param>
    /// <returns>删除成功返回true，否则返回false</returns>
    public bool DeleteKey(string key)
    {
        return database.KeyDelete(key);
    }

    /// <summary>
    /// 获取哈希表中指定字段的值
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">哈希表的键</param>
    /// <param name="field">字段名</param>
    /// <returns>返回指定类型的值，如果不存在则返回默认值</returns>
    public T GetHash<T>(string key, string field)
    {
        if (!HasHash(key, field)) return default!;

        var json = database.HashGet(key, field);

        return string.IsNullOrWhiteSpace(json) ? default! : json.ToString().DeJson<T>();
    }

    /// <summary>
    /// 获取列表中指定索引位置的值
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">列表的键</param>
    /// <param name="index">索引位置</param>
    /// <returns>返回指定类型的值，如果不存在则返回默认值</returns>
    public T GetList<T>(string key, int index)
    {
        if (!HasKey(key)) return default!;

        var json = database.ListGetByIndex(key, index);

        return !string.IsNullOrWhiteSpace(json) ? json.ToString().DeJson<T>() : default!;
    }

    /// <summary>
    /// 获取列表中指定范围的值集合
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">列表的键</param>
    /// <param name="start">起始位置</param>
    /// <param name="end">结束位置</param>
    /// <returns>返回指定范围内的值集合</returns>
    public List<T> GetList<T>(string key, int start, int end)
    {
        var list = new List<T>();

        if (!HasKey(key)) return list;

        foreach (var value in database.ListRange(key, start, end).ToList())
            list.Add(value.ToString().DeJson<T>());

        return list;
    }

    /// <summary>
    /// 获取有序集合中指定范围的值集合（升序）
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">有序集合的键</param>
    /// <param name="start">起始位置</param>
    /// <param name="end">结束位置</param>
    /// <returns>返回指定范围内的值集合</returns>
    public List<T> GetSortedSet<T>(string key, long start = 0, long end = int.MaxValue)
    {
        return GetSortedSet<T>(key, start, end, Order.Ascending);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <param name="start">开始位置</param>
    /// <param name="end">结束位置</param>
    /// <param name="order">排序</param>
    /// <returns>处理结果</returns>
    public List<T> GetSortedSet<T>(string key, long start = 0, long end = int.MaxValue,
        Order order = Order.Descending)
    {
        var list = new List<T>();

        if (HasKey(key))
            foreach (var value in database.SortedSetRangeByRank(key, start, end, order))
                list.Add(value.ToString().DeJson<T>());

        return list;
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <returns>处理结果</returns>
    public T GetString<T>(string key)
    {
        if (!HasKey(key)) return default!;

        var json = database.StringGet(key);

        return !string.IsNullOrWhiteSpace(json) ? json.ToString().DeJson<T>() : default!;
    }

    /// <summary>
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="field">字段</param>
    /// <returns>处理结果</returns>
    public bool HasHash(string key, string field)
    {
        return database.HashExists(key, field);
    }

    /// <summary>
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>处理结果</returns>
    public bool HasKey(string key)
    {
        return database.KeyExists(key);
    }

    /// <summary>
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>处理结果</returns>
    public bool LeftRemoveList(string key)
    {
        return string.IsNullOrWhiteSpace(database.ListLeftPop(key));
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    /// <returns>处理结果</returns>
    public bool LeftSetList<T>(string key, T value)
    {
        return database.ListLeftPush(key, value?.ToJson()) > 0;
    }

    /// <summary>
    /// </summary>
    /// <param name="args">请求参数</param>
    /// <returns>处理结果</returns>
    public async Task<string> NextIdentity(NextIdentifyArg args)
    {
        var now = DateTime.Now.Date;

        var key = GetIdAsyncentityKey(args, now);
        var value = GetIdAsyncentifyValue(args, now);
        var time = GetIdAsyncentifyTimespan(args, now);

        if (HasKey(key))
        {
            value = GetString<long>(key);
            value += args.Count;
        }

        SetString(key, value, time);

        var result = $"{args.Prefix}{value}{args.Suffix}";

        return await Task.FromResult(result);
    }

    /// <summary>
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="field">字段</param>
    /// <returns>处理结果</returns>
    public bool RemoveHash(string key, string field)
    {
        return database.HashDelete(key, field);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    /// <returns>处理结果</returns>
    public bool RemoveList<T>(string key, T value)
    {
        return database.ListRemove(key, value?.ToJson()) > 0;
    }

    /// <summary>
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="newKey">新键</param>
    /// <returns>处理结果</returns>
    public bool ReNameKey(string key, string newKey)
    {
        return database.KeyRename(key, newKey);
    }

    /// <summary>
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>处理结果</returns>
    public bool RightRemoveList(string key)
    {
        return string.IsNullOrWhiteSpace(database.ListRightPop(key));
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    /// <returns>处理结果</returns>
    public bool RightSetList<T>(string key, T value)
    {
        return database.ListRightPush(key, value?.ToJson()) > 0;
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <param name="field">字段</param>
    /// <param name="value">值</param>
    /// <returns>处理结果</returns>
    public bool SetHash<T>(string key, string field, T value)
    {
        return database.HashSet(key, field, value?.ToJson());
    }

    /// <summary>
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="expireTime">过期时间</param>
    /// <returns>处理结果</returns>
    public bool SetKeyExpire(string key, TimeSpan expireTime)
    {
        return database.KeyExpire(key, expireTime);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    /// <param name="score">权重信息</param>
    public void SetSortedSet<T>(string key, T value, double score)
    {
        database.SortedSetAdd(key, value?.ToJson(), score);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">返回值的类型</typeparam>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    /// <param name="expireTime">过期时间</param>
    /// <returns>处理结果</returns>
    public bool SetString<T>(string key, T value, TimeSpan? expireTime = null)
    {
        return database.StringSet(key, value?.ToJson(), expireTime);
    }

    /// <summary>
    /// </summary>
    /// <param name="args">请求参数</param>
    /// <param name="now">当前时间</param>
    /// <returns>处理结果</returns>
    private static TimeSpan GetIdAsyncentifyTimespan(NextIdentifyArg args, DateTime now)
    {
        return args.Type switch
        {
            IdentifyEnum.Year => now.ToYearEnd() - now,
            IdentifyEnum.Month => now.ToMonthEnd() - now,
            IdentifyEnum.Day => now.ToDayEnd() - now,
            _ => now.ToDayEnd() - now
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="args">请求参数</param>
    /// <param name="now">当前时间</param>
    /// <returns>处理结果</returns>
    private static long GetIdAsyncentifyValue(NextIdentifyArg args, DateTime now)
    {
        return args.Type switch
        {
            IdentifyEnum.Year => long.Parse($"{now:yyyy}0000000000"),
            IdentifyEnum.Month => long.Parse($"{now:yyyyMM}00000000"),
            IdentifyEnum.Day => long.Parse($"{now:yyyyMMdd}000000"),
            _ => long.Parse($"{now:yyyyMMdd}000000")
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="args">请求参数</param>
    /// <param name="now">当前时间</param>
    /// <returns>处理结果</returns>
    private static string GetIdAsyncentityKey(NextIdentifyArg args, DateTime now)
    {
        return args.Type switch
        {
            IdentifyEnum.Year => $"{args.CompanyId}{args.Name}{now:yyyy}",
            IdentifyEnum.Month => $"{args.CompanyId}{args.Name}{now:yyyyMM}",
            IdentifyEnum.Day => $"{args.CompanyId}{args.Name}{now:yyyyMMdd}",
            _ => $"{args.CompanyId}{args.Name}{now:yyyyMMdd}"
        };
    }
}