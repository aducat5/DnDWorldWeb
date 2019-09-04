using System;

namespace DnDWorld.BLL.Utility
{
    public static class GenFunx
    {
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }

        public static int ToInt(this string stringValue)
        {
            return Convert.ToInt32(stringValue);
        }

        public static string ClearText(this string text)
        {
            return text.Trim(' ', '.', ';', '&', '*', '/');
        }
    }
}