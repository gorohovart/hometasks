namespace drom
{
    public sealed class PalindromeChecker
    {
        private const string Delimeters = "’‘”“?!@#$%^&*()_+=-:;\"\\|/.,<>{}[]'`~ ’";

        private static bool IsDelimiter(char c)
        {
            return Delimeters.Contains(c.ToString());
        }

        public static bool IsPalindrome(string line)
        {
            var chars = line.ToCharArray();
            var leftPointer = 0;
            var rightPointer = line.Length - 1;

            while (leftPointer <= rightPointer)
            {
                while (IsDelimiter(chars[leftPointer]))
                {
                    leftPointer++;
                    if (leftPointer >= line.Length)
                        return true;
                }
                while (IsDelimiter(chars[rightPointer]))
                {
                    rightPointer--;
                    if (leftPointer < 0)
                        return false;
                }
                if (char.ToLower(chars[leftPointer]) != char.ToLower(chars[rightPointer]))
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
