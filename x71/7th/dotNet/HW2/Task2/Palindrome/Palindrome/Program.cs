using System;

namespace Palindrome
{
    internal sealed class Program
    {
        public static void Main()
        {
            Console.WriteLine("Program to check if a string is a palindrome or not.\nEnter the string:");

            var line = Console.ReadLine();

            if (PalindromeChecker.IsPalindrome(line))
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
}