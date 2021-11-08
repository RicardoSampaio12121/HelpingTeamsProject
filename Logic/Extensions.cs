using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Extensions
    {
        public static string jsonAsJson(this string json)
        {
            string output = string.Empty;

            foreach(char c in json)
            {
                if (c != '\\')
                {
                    output += c;
                }
            }
            return output;
        }
    }
}
