using OSeven.app.Game;
using OSeven.calc;
using OSeven.files;
using OSeven.sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSeven.app.Game
{
    internal class Games
    {
        public static void Main()
        {
        start:
            Console.Clear();
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine("|            SELECT A GAME              |");
            Console.WriteLine(" ---------------------------------------");
            Console.ResetColor();
            Console.WriteLine("|  1   |         JackEmpoy              |");
            Console.WriteLine("|  2   |         SnakeGame              |");
            Console.WriteLine(" ---------------------------------------");
            Console.Write("\nGames> ");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("JackEmpoy");
                    try { JackEmpoy.Main(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("App 'Calc' crashed\n" + e); }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("SnakeGame");
                    try { SnakeGame.Init(); }
                    catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("App 'Text' crashed\n" + e); }
                    break;
               
                case ConsoleKey.Tab:
                    break;
                case ConsoleKey.F1:
                    Console.WriteLine("\nEnter number to launch app. Press TAB to quit Games (or app if launched).");
                    goto start;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUnknown command, press F1 for help.");
                    goto start;
            }
        }

    }
}