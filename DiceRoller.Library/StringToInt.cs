using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DiceRoller.Library
{
    public class StringToInt
    {
        public int OneOrGreater(string input)
        {
            int result;
            try
            {
                result = int.Parse(Regex.Replace(input, @"[A-z]", ""));
                if (result >= 1)
                {
                    return result;
                }
                else
                {
                    return 1;
                }
            }
            catch
            {
                return 1;
            }
        }

        public int ZeroOrGreater(string input)
        {
            int result;
            try
            {
                result = int.Parse(Regex.Replace(input, @"[A-z]", ""));
                if (result >=0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
