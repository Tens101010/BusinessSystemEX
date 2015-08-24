using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class StringHandler
    {
        // Creating a static function in a static class
        // Notice the "this", creating a static extension method
        // This enables the use of much simpler code when writing:
            // StringHandler.InsertSpaces(productName);
        // This can become:
            // productName.InsertSpaces
        public static string InsertSpaces(this string source)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        // Trim any spaces already there
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
                result = result.Trim();
            }
            return result;
        }
    }
}