using System.ComponentModel;

namespace Showdown.Utilities;

public static class EnumHelper
{
    public static string GetDescription<T>(this T value)
    {
        if (value is null)
            return string.Empty;

        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
        return attribute?.Description ?? value.ToString();
    }
}
