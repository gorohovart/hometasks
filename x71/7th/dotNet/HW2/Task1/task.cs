using System;

class Program
{
    public static void Main()
    {
        Console.Clear();
        Console.WriteLine("Я – интеллектуальный калькулятор!");
		Console.WriteLine("Как тебя зовут?");

        var name = Console.ReadLine();

       	var rnd = new Random();
       	var a = rnd.Next(10) + 1;
       	var b = rnd.Next(10) + 1;

        Console.WriteLine("Сколько будет {0} + {1}", a, b);
        var result = Console.ReadLine();
        try
        {
            var number = Int32.Parse(result); 

            if (number == a + b)
	        {
	        	Console.WriteLine("Верно, {0}!", name);
	        }
	        else
	        {
	        	Console.WriteLine("{0}, ты не прав.", name);
	        }
        }
        catch (FormatException)
        {
            Console.WriteLine("{0}: Bad Format", result);
        }   
        catch (OverflowException)
        {
            Console.WriteLine("{0}: Overflow", result);   
        }
    }
}