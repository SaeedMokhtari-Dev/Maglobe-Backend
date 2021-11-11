using System;

namespace Maglobe.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ReverseDate(this string s)
        {
            var dateSplit = s.Split("/");
            Array.Reverse(dateSplit);
            return String.Join("/", dateSplit);
        }
    }
}