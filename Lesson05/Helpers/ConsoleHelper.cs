using System;

namespace Lesson05.Extensions
{
    internal static class ConsoleHelper
    {
        public static void WriteLineError(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Error: {message}");

            Console.ForegroundColor = currentColor;
        }

        public static void WriteError(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"Error: {message}");

            Console.ForegroundColor = currentColor;
        }

        public static void WriteLineSuccess(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ForegroundColor = currentColor;
        }

        public static void WriteSuccess(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(message);

            Console.ForegroundColor = currentColor;
        }
    }
}
