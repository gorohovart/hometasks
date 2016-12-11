using System;
using System.IO;
using drom;

namespace DromeTest
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            var testStrings = File.ReadAllLines("..\\..\\test.txt");

            foreach (var str in testStrings)
            {
                if (PalindromeChecker.IsPalindrome(str))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(str);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(str);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
