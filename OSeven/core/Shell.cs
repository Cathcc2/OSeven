using OSeven.input;
using System;
using System.Collections.Generic;

namespace OSeven.shell
{
    public static class Shell
    {
        public static void Main()
        {
            Oseven.oseven.Oseven.Main(Input.Main("", ConsoleColor.Green));
        }
        public static void Check()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("| OK |");
            Console.ResetColor();
            Console.Write(" OSeven Shell\n");
        }
    }
}