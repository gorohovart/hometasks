using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public sealed class PalindromeChecker
    {
        private static string delimeters = "!@#$%^&*()_+=-:;\"\\|/.,<>{}[]'`~ ";

        private static bool isDelimiter(char c)
        {
            return delimeters.Contains(c.ToString());
        }

        public static bool IsPalindrome(string line)
        {
            if (line == null) throw new ArgumentNullException();
            
            var leftPointer = 0;
            var rightPointer = line.Length - 1;

            while (leftPointer <= rightPointer)
            {
                while (isDelimiter(line[leftPointer]))
                {
                    leftPointer++;
                    if (leftPointer >= line.Length)
                        return true;
                }
                while (isDelimiter(line[rightPointer]))
                {
                    rightPointer--;
                    if (leftPointer < 0)
                        return false;
                }
                if (Char.ToLower(line[leftPointer]) != Char.ToLower(line[rightPointer]))
                {
                    return false;
                }
                leftPointer++;
                rightPointer--;
            }

            return true;
        }
    }
}
