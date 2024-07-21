using System.ComponentModel;
using System.Reflection;

namespace Big2.Utilities;

public static class EnumHelper
{
    public static string GetEnumDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field is null)
            return value.ToString();
        return field.GetCustomAttribute(typeof(DescriptionAttribute)) is not DescriptionAttribute attribute ?
            value.ToString() :
            attribute.Description;
    }
}
