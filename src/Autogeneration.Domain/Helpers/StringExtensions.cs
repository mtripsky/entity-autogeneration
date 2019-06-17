using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Autogeneration.Domain.Helpers
{
    public static class StringExtensions
    {
        public static string RemoveFirstLines(string text, int linesCount)
        {
            var lines = Regex
                .Split(text, "\r\n|\r|\n")
                .Skip(linesCount);

            return string.Join(Environment.NewLine, lines.ToArray());
        }

        public static bool IsPrimitive(string type)
        {
            if(type == "int"
               || type == "double"
               || type == "long"
               || type == "string")
            { 
            
            }


            return false;
        }
    }
}
