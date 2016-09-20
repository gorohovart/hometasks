using System;

class Program
{
    private static string delimeters = "!@#$%^&*()_+=-:;\"\\|/.,<>{}[]'`~ ";
    private static bool isDelimiter(char c)
    {
        return delimeters.Contains(c.ToString());
    }

    private static bool isPalindrome(string line)
    {
        var chars = line.ToCharArray();
        var leftPointer = 0;
        var rightPointer = line.Length - 1;

        while (leftPointer <= rightPointer)
        {
            while (isDelimiter(chars[leftPointer]))
            {
                leftPointer++;
                if (leftPointer >= line.Length)
                    return true;
            }
            while (isDelimiter(chars[rightPointer]))
            {
                rightPointer--;
                if (leftPointer < 0)
                    return false;
            }
            if (Char.ToLower(chars[leftPointer]) != Char.ToLower(chars[rightPointer]))
            {
                return false;
            }
            leftPointer++;
            rightPointer--;
        }
        
        return true;
    }

    public static void Main()
    {
        Console.Clear();
        Console.WriteLine("Program to check if a string is a palindrome or not.\nEnter the string:");

        var line = Console.ReadLine();
        
        if (isPalindrome(line))
	    {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("String is a palindrome!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
	    else
	    {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("String is not a palindrome!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}