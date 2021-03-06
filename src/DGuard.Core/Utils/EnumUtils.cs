using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DGuard.Core.Utils
{
    public static class EnumUtils
    {
        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }

        public static string Descricao(this Enum value)
        {
            return GetCustomDescription(value);
        }
    }
}
