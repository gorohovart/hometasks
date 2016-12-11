using System;

namespace Regexp
{
    private sealed class Program
    {
        private static void PrintCheckSucceed(string what)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("String is " + what + "!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void PrintCheckFailed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Check failed");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Program to check if a string is a zip, phone number or email.\nEnter the string:");

            var line = Console.ReadLine();

            if (UserInputChecker.IsZip(line))
            {
                CheckSucceed("ZIP");
            }
            else if (UserInputChecker.IsPhoneNumber(line))
            {
                CheckSucceed("phone number");
            }
            else if (UserInputChecker.IsEmergencyPhoneNumber(line))
            {
                PrintCheckSucceed("emergency phone number");
            }
            else if (UserInputChecker.IsEmail(line))
            {
                CheckSucceed("email");
            }
            else
            {
                PrintCheckFailed();
            }
        }
    }
}
