
using System;

namespace TheBear.Core
{
    public static class Logger
    {
        private static void Print(string text, string tag, ConsoleColor tagColor)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = tagColor;
            Console.Write(tag);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("] " + text);
        }
        private static void PrinAligned(string text)
        {
            Console.CursorLeft = 10;
            Console.WriteLine(text);
        }

        public static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            PrinAligned(@" __         __  ");
            PrinAligned(@"/  \.-'''-./  \ ");
            PrinAligned(@"\    -   -    / ");
            PrinAligned(@" |   o   o   |  ");
            PrinAligned(@" \  .-'''-.  /  ");
            PrinAligned(@"  '-\__Y__/-'   ");
            PrinAligned(@"     `---`      ");
            Console.WriteLine();
        }
        public static void PrintInfo(string text) => Print(text, "i", ConsoleColor.Blue);
        public static void PrintWarn(string text) => Print(text, "!", ConsoleColor.Yellow);
        public static void PrintError(string text) => Print(text, "x", ConsoleColor.Red);
        public static void PrintSuccess(string text) => Print(text, "+", ConsoleColor.Green);

        public static void ReadLine() => Console.ReadLine();

    }
}
