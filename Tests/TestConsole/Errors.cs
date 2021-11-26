using System;

namespace TestConsole
{
    public static class Errors
    {
        public static void WrongInputFormat(ExpectedInput input)
        {
            Console.WriteLine($"Wrong input format, expected input is an {input}");
        }
    }
}