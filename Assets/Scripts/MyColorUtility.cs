using UnityEngine;

//カラーコード文字列をColorクラスに変換するスクリプト
//https://baba-s.hatenablog.com/entry/2015/12/31/100000
public static class MyColorUtility
{
    /// <summary>
    /// 指定された文字列を Color 型に変換できる場合 true を返します
    /// </summary>
    public static bool IsColor(string htmlString)
    {
        Color color;
        return ColorUtility.TryParseHtmlString(htmlString, out color);
    }

    /// <summary>
    /// 指定された文字列を Color 型に変換します
    /// </summary>
    public static Color ToColor(string htmlString)
    {
        Color color;
        ColorUtility.TryParseHtmlString(htmlString, out color);
        return color;
    }

    /// <summary>
    /// <para>指定された文字列を Color 型に変換します</para>
    /// <para>変換できなかった場合デフォルト値を返します</para>
    /// </summary>
    public static Color ToColorOrDefault(string htmlString, Color defaultValue = default(Color))
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(htmlString, out color))
        {
            return color;
        }
        return defaultValue;
    }

    /// <summary>
    /// <para>指定された文字列を Color 型に変換します</para>
    /// <para>変換できなかった場合 null を返します</para>
    /// </summary>
    public static Color? ToColorOrNull(string htmlString)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(htmlString, out color))
        {
            return color;
        }
        return null;
    }
}