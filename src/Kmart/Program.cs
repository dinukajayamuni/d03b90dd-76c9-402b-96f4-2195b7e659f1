using System;

namespace Kmart
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                try
                {
                    Console.WriteLine(SubsequenceGenerator.Generate(args[0]));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please provide one string input of any number of integers separated by single whitespace");
                }
            }
            else
            {
                Console.WriteLine("Please provide one string input of any number of integers separated by single whitespace");
            }
        }
    }
}
