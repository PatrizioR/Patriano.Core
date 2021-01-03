using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Patriano.Core.Extensions
{
    public static class PropertyInfoExtension
    {
        public static T? GetValueOrDefault<T>(this PropertyInfo info, object? value, T defaultValue = default(T))
        {
            if (info == null || value == null)
            {
                return defaultValue;
            }

            try
            {
                var resultValue = info.GetValue(value);
                if (resultValue == null)
                {
                    return defaultValue;
                }
                Type t = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;
                Console.WriteLine($"{nameof(GetValueOrDefault)} Change type {info.PropertyType.Name} to {t.Name}");
                var tmpResultValue = Convert.ChangeType(resultValue, t);
                Console.WriteLine($"{nameof(GetValueOrDefault)} Change type {t.Name} to {typeof(T).Name}");
                if (t.GetInterfaces()?.Any(interf => interf == typeof(IConvertible)) != true)
                {
                    var tmpResultValueString = tmpResultValue.ToString();
                    if (tmpResultValueString == null)
                    {
                        return defaultValue;
                    }
                    return (T)Convert.ChangeType(tmpResultValueString, typeof(T));
                }
                return (T)Convert.ChangeType(tmpResultValue, typeof(T));
            }
            catch (Exception ex)
            {
                return defaultValue;
            }
        }
    }
}