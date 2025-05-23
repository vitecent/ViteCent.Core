﻿#region

using Quartz;
using ViteCent.Core.Cache;
using ViteCent.Core.Data;
using ViteCent.Core.Register;

#endregion

namespace ViteCent.Job.Api.Jobs;

/// <summary>
/// </summary>
/// <param name="cache"></param>
/// <param name="register"></param>
/// <param name="logger"></param>
public class ServiceJob(
    IBaseCache cache,
    IRegister register,
    ILogger<ServiceJob> logger)
    : IJob
{
    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Execute(IJobExecutionContext context)
    {
        logger.LogInformation($"ServiceJob : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

        var services = await register.ServiceAsync();

        logger.LogInformation($"获取到{services.Count}个服务");

        cache.SetString(BaseConst.RegistServices, services, TimeSpan.FromMinutes(1));
    }
}