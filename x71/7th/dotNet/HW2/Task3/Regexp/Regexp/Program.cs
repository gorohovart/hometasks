using System;

namespace Regexp
{
    public sealed class Program
    {
        public static void PrintCheckSucceed(string stringName, string what)
        {
            if ((what == null)||(stringName == null)) throw new ArgumentNullException();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("Line \"{0}\" is {1}!",stringName, what));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintCheckFailed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("Check of string \"{0}\" failed", str));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Program to check if a string is a zip, phone number or email.\nEnter the string:");

            var line = Console.ReadLine();

            if (UserInputChecker.IsZip(line))
            {
                PrintCheckSucceed(line, "a ZIP");
            }
            else if (UserInputChecker.IsPhoneNumber(line))
            {
                PrintCheckSucceed(line, "a phone number");
            }
            else if (UserInputChecker.IsEmergencyPhoneNumber(line))
            {
                PrintCheckSucceed(line, "an emergency phone number");
            }
            else if (UserInputChecker.IsEmail(line))
            {
                PrintCheckSucceed(line, "an email");
            }
            else
            {
                PrintCheckFailed(line);
            }
        }
    }
}
