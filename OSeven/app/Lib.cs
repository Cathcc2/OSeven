using System;
using OSeven.calc;
using OSeven.sound;
using OSeven.files;
using OSeven.app;
using Oseven;
using OSeven.app.Game;

namespace OSeven.lib
{
    public static class Lib
    {
        public static void Main()
        {
        start:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine("|         OSEVEN LIBRARY COMMAND        |");
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine("| TAB  |      QUIT                      |");
            Console.WriteLine("|  F1  |      BACK                      |");
            Console.WriteLine("|  1   |      Calculator                |");
            Console.WriteLine("|  2   |      Text Editor               |");
            Console.WriteLine("|  3   |      File Manager              |");
            Console.WriteLine("|  4   |      Sound Playground          |");
            Console.WriteLine("|  5   |      Games                     |");
            Console.WriteLine("|  6   |      Piano                     |");
            Console.WriteLine(" ---------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("\nLibrary> ");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Calculator");
                    try { Calc.Main(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("App 'Calc' crashed\n" + e); }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Text Editor");
                    try { text.Text.Main(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("App 'Text' crashed\n" + e); }
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("File Manager");
                    try { Files.Main(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\nApp 'Files' crashed\n" + e); }
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Sound Playground");
                    try { Sound.Main(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\nApp 'Sound' crashed\n" + e); }
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("Games");
                    try { Games.Main(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\nApp 'SnakeGame' crashed\n" + e); }
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("Games");
                    try { Piano.Pian(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\nApp 'SnakeGame' crashed\n" + e); }
                    break;

                case ConsoleKey.Tab:
                    break;
                case ConsoleKey.F1:
                    Console.WriteLine("\nEnter number to launch app. Press TAB to quit library (or app if launched).");
                    goto start;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUnknown command, press F1 for help.");
                    goto start;
            }
        }
        public static void Boot()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("| OK |");
            Console.ResetColor();
            Console.Write(" OSeven Apps Library\n");
        }
    }
}