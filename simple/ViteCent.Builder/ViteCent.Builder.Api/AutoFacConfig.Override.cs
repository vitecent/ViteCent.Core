/*
 * **********************************
 * 代码由工具自动生成
 * 重新生成时，不会覆盖原有代码
 * **********************************
 */

#region 引入命名空间

// 引入Autofac依赖注入容器相关命名空间，提供IoC容器的核心功能
using Autofac;

// 将Autofac.Module重命名为Module，避免与System.Reflection.Module的命名冲突
using Module = Autofac.Module;

#endregion 引入命名空间

namespace ViteCent.Builder.Api;

/// <summary>
/// AutoFac依赖注入配置类拓展
/// </summary>
public partial class AutoFacConfig : Module
{
    /// <summary>
    /// 加载依赖注入配置
    /// </summary>
    /// <param name="builder">容器构建器，用于注册类型到IoC容器</param>
    private void OverrideLoad(ContainerBuilder builder)
    {
    }
}