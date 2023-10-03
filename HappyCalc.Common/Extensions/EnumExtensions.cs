﻿using System.ComponentModel;
using System.Reflection;

namespace HappyCalc.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo? fi = value.GetType().GetField(value.ToString());

            if (fi == null)
            {
                return string.Empty;
            }
            else
            {
                DescriptionAttribute[]? attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (attributes != null && attributes.Any())
                {
                    return attributes.First().Description;
                }

                return value.ToString();
            }            
        }
    }
}
