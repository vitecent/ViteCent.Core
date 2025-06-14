﻿namespace ViteCent.Builder.Data;

/// <summary>
/// </summary>
public class ApiSetting
{
    /// <summary>
    /// </summary>
    public string Cache { get; set; } = "192.168.0.9:6379,password=123456,defaultDatabase=1";

    /// <summary>
    /// </summary>
    public string Environment { get; set; } = "IIS";

    /// <summary>
    /// </summary>
    public string FacName { get; set; } = "AutoFacConfig";

    /// <summary>
    /// </summary>
    public string Guid { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    public string JwtAudience { get; set; } = "Cent";

    /// <summary>
    /// </summary>
    public string JwtIssuer { get; set; } = "Vite";

    /// <summary>
    /// </summary>
    public string JwtKey { get; set; } = "a9YRPktRYNd8jc5Z42nSzwDZ1pyd3FBJ";

    /// <summary>
    /// </summary>
    public string MapperName { get; set; } = "AutoMapperConfig";

    /// <summary>
    /// </summary>
    public string Name { get; set; } = "Api";

    /// <summary>
    /// </summary>
    public string Register { get; set; } = "http://192.168.0.9:8500";

    /// <summary>
    /// </summary>
    public string Trace { get; set; } = "http://192.168.0.9:9411/api/v2/spans";
}