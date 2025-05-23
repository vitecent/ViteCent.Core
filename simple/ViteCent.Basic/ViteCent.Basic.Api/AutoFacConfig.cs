/*
 * **********************************
 * 代码由工具自动生成，请勿人工修改
 * 重新生成时，将覆盖原有代码
 * 如需扩展该类，请在partial类中实现
 * **********************************
 */

#region

using Autofac;
using System.Reflection;
using Module = Autofac.Module;

#endregion

namespace ViteCent.Basic.Api;

/// <summary>
/// 调休申请注入
/// </summary>
public partial class AutoFacConfig : Module
{
    /// <summary>
    /// 注入
    /// </summary>
    /// <param name="builder"></param>
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        var path = AppDomain.CurrentDomain.BaseDirectory;

        var assemblies = new List<Assembly>();

        var dlls = new List<string>
        {
            "*Application.dll",
            "*Domain.dll"
        };

        foreach (var dll in dlls)
        {
            var files = Directory.GetFiles(path, dll);

            foreach (var item in files)
            {
                var assembly = Assembly.LoadFrom(item);
                assemblies.Add(assembly);
            }
        }

        builder.RegisterAssemblyTypes([.. assemblies])
            .Where(t => t.IsClass && !t.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();

        OverrideLoad(builder);
    }
}