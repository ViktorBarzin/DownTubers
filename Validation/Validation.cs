using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    using System.Reflection.Emit;
    using System.Text.RegularExpressions;

    public static class Validation
    {
        public static bool IsNullOrEmpty(string text)
        {
            return String.IsNullOrEmpty(text);
        }

        public static bool IsLongerThan5(string text)
        {
            return text.Length > 5;
        }

        public static bool IsNumber(string c)
        {
            decimal a;
            return decimal.TryParse(c, out a);
        }

        public static bool ValidEmail(string email)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                 + "@"
                                 + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(email);
            return match.Success;
        }

        public static bool IsShorterThen250(string c)
        {
            return c.Length < 250;
        }
    }
}
