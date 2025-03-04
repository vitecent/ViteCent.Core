﻿#region

using log4net;
using Microsoft.AspNetCore.Builder;
using ViteCent.Core.Api.Swagger;
using ViteCent.Core.Cache.Redis;
using ViteCent.Core.Orm.SqlSugar;
using ViteCent.Core.Register.Consul;
using ViteCent.Core.Trace.Zipkin;

#endregion

namespace ViteCent.Core.Web;

/// <summary>
/// </summary>
public class BaseMicroService : MicroService
{
    /// <summary>
    /// </summary>
    private readonly ILog logger;

    /// <summary>
    /// </summary>
    private readonly string title;

    /// <summary>
    /// </summary>
    private readonly List<string> xmls;

    /// <summary>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="xmls"></param>
    public BaseMicroService(string title, List<string> xmls)
    {
        this.title = title;
        this.xmls = xmls;

        logger = BaseLogger.GetLogger();

        logger.Info("开始构建基础微服务");
    }

    /// <summary>
    /// </summary>
    public Action<WebApplicationBuilder> OnBuild { get; set; } = default!;

    /// <summary>
    /// </summary>
    public Action<WebApplication> OnStart { get; set; } = default!;

    /// <summary>
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    protected override async Task BuildAsync(WebApplicationBuilder builder)
    {
        // 调用基类的 BuildAsync 方法
        await base.BuildAsync(builder);

        var configuration = builder.Configuration;
        var services = builder.Services;

        // 添加Redis服务
        logger.Info("开始添加 Redis 服务");
        services.AddRedis(configuration);

        // 添加Consul服务
        logger.Info("开始添加 Consul 服务");
        services.AddConsul(configuration);

        // 添加Zipkin服务
        logger.Info("开始添加 Zipkin 服务");
        services.AddZipkin(configuration);

        // 添加SqlSugar服务
        logger.Info("开始添加 SqlSugar 服务");
        services.AddSqlSugger(configuration);

        // 添加Swagger服务
        logger.Info("开始添加 Swagger 服务");
        services.AddSwagger(title, xmls);

        logger.Info("开始执行构建回调");

        // 执行构建回调
        OnBuild?.Invoke(builder);
    }

    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    protected override async Task StartAsync(WebApplication app)
    {
        // 调用基类的 StartAsync 方法
        await base.StartAsync(app);

        // 使用 Consul 中间件
        logger.Info("开始使用 Consul 中间件");
        await app.UseConsulAsync();

        // 使用 Zipkin 中间件
        logger.Info("开始使用 Zipkin 中间件");
        app.UseZipkin();

        // 使用 Swagger 仪表盘
        logger.Info("开始使用 Swagger 仪表盘");
        app.UseSwagger();

        logger.Info("开执行启动回调");

        // 执行启动回调
        OnStart?.Invoke(app);
    }
}