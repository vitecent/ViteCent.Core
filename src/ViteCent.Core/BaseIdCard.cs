﻿namespace ViteCent.Core;

/// <summary>
/// 身份证号码工具类，提供身份证号码的验证和信息提取功能
/// </summary>
public static class IdCardHelper
{
    /// <summary>
    /// 从身份证号码中提取出生日期
    /// </summary>
    /// <param name="input">身份证号码字符串（支持15位或18位）</param>
    /// <returns>格式化的出生日期字符串（格式：YYYY-MM-DD），如果身份证号码无效则返回空字符串</returns>
    public static string GetIdAsyncCardBirthday(this string input)
    {
        if (!input.IsIdCard()) return string.Empty;

        if (input.Length == 18)
            return input.GetIdAsyncCardBirthday18();

        if (input.Length == 15)
            return input.GetIdAsyncCardBirthday15();

        throw new Exception("身份证号格式错误");
    }

    /// <summary>
    /// 从15位身份证号码中提取出生日期
    /// </summary>
    /// <param name="input">15位身份证号码字符串</param>
    /// <returns>格式化的出生日期字符串（格式：YY-MM-DD）</returns>
    public static string GetIdAsyncCardBirthday15(this string input)
    {
        return input.Substring(6, 6).Insert(4, "-").Insert(2, "-");
    }

    /// <summary>
    /// 从18位身份证号码中提取出生日期
    /// </summary>
    /// <param name="input">18位身份证号码字符串</param>
    /// <returns>格式化的出生日期字符串（格式：YYYY-MM-DD）</returns>
    public static string GetIdAsyncCardBirthday18(this string input)
    {
        return input.Substring(6, 8).Insert(6, "-").Insert(4, "-");
    }

    /// <summary>
    /// 验证身份证号码是否有效
    /// </summary>
    /// <param name="input">待验证的身份证号码字符串</param>
    /// <returns>如果身份证号码有效返回true，否则返回false</returns>
    public static bool IsIdCard(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        if (input.Length == 18)
            return input.IsIdCard18();

        if (input.Length == 15)
            return input.IsIdCard15();

        return false;
    }

    /// <summary>
    /// 验证15位身份证号码是否有效
    /// </summary>
    /// <param name="input">待验证的15位身份证号码字符串</param>
    /// <returns>如果15位身份证号码有效返回true，否则返回false</returns>
    public static bool IsIdCard15(this string input)
    {
        //数字验证
        if (long.TryParse(input, out var n) == false || n < Math.Pow(10, 14)) return false;

        //省份验证
        var address =
            "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (!address.Contains(input.Remove(2), StringComparison.CurrentCulture)) return false;

        //生日验证
        var birth = input.Substring(6, 6).Insert(4, "-").Insert(2, "-");
        if (DateTime.TryParse(birth, out _) == false) return false;

        return true;
    }

    /// <summary>
    /// 验证18位身份证号码是否有效（包含校验码验证）
    /// </summary>
    /// <param name="input">待验证的18位身份证号码字符串</param>
    /// <returns>如果18位身份证号码有效返回true，否则返回false</returns>
    public static bool IsIdCard18(this string input)
    {
        //数字验证
        if (long.TryParse(input.Remove(17), out var x) == false || x < Math.Pow(10, 16) ||
            long.TryParse(input.Replace('x', '0').Replace('X', '0'), out _) == false) return false;

        //省份验证
        var address =
            "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (!address.Contains(input.Remove(2), StringComparison.CurrentCulture)) return false;

        //生日验证
        var birth = input.Substring(6, 8).Insert(6, "-").Insert(4, "-");
        if (DateTime.TryParse(birth, out _) == false) return false;

        //校验码验证
        var arrVarifyCode = "1,0,x,9,8,7,6,5,4,3,2".Split(',');
        var Wi = "7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2".Split(',');
        var Ai = input.Remove(17).ToCharArray();
        var sum = 0;
        for (var i = 0; i < 17; i++) sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());

        Math.DivRem(sum, 11, out var y);

        if (!arrVarifyCode[y].Equals(input.Substring(17, 1), StringComparison.CurrentCultureIgnoreCase)) return false;

        return true;
    }
}