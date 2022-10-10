using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Operations
{
    public static class NameChanger
    {
        public static string ChangeName(string name)
        {
            name.Replace("/", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace(".", "")
                .Replace(",", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace("@", "")
                .Replace("*", "")
                .Replace("-", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("ğ", "g")
                .Replace("ş", "s")
                .Replace("ç", "c")
                .Replace("ı", "i");

            return name;
        }
    }
}
