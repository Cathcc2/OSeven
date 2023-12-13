using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;
using OSeven.lib;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using OSeven.date;
using OSeven.sysinfo;
using Cosmos.Core;
using OSeven.files;
using OSeven.text;
using OSeven.loading;
using OSeven.input;
using System.Runtime.CompilerServices;
using OSeven;

namespace Oseven.oseven
{
    public static class Oseven
    {
        public static string Input { get; set; }
        public static bool Echo { get; set; }
        public static string Prompt { get; set; }

        public static void Main(string input)
        {
        
            switch (input)
            {

                case "help":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("              ======    ======   =====  =       =  =====   ==     =    ");
                    Console.WriteLine("             ||    ||   ||       ||     =       =  ||      = =    =    ");
                    Console.WriteLine("             ||    ||   ||       ||      =     =   ||      =  =   =    ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("             ||    ||   ======   =====    =   =    =====   =   =  =    ");
                    Console.WriteLine("             ||    ||        ||  ||        = =     ||      =    = =    ");
                    Console.WriteLine("              ======    ======   =====      =      =====   =     ==    ");
                    Console.WriteLine("                                                         ");

                    Console.WriteLine(" ----------------------------------------------------------------------------");
                    Console.WriteLine("|                            OSEVEN HELP COMMAND                             |");
                    Console.WriteLine(" ----------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("| TAB            | Quit app               | about       | System Information |");
                    Console.WriteLine("| F1             | Display help           | ver         | System version     |");
                    Console.WriteLine("| ESC            | Cancel input           | cls         | Clear screen       |");
                    Console.WriteLine("| Arrows Up/Down | Browse command history | lib         | library of apps    |");
                    Console.WriteLine("| help           | Display help           | err         | Check kernel error |");
                    Console.WriteLine("| sd             | Turn off computer      | echo        | Echo message       |");
                    Console.WriteLine("| restart        | Restart computer       | sound       | Play beep          |");
                    Console.WriteLine("| info           | OS information         | date / time | Display date/time  |");
                    Console.WriteLine("| color          | Change color           | Load        | services           |");
                    Console.WriteLine(" ----------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;

                    break;
                case "about":
                    Console.WriteLine("About Oseven\n--------\n" + Kernel.CurrentVersion + "\nBased on CosmosOS" + "\nCreated by Group7\nGithub: https://github.com/Oseven.Blk2 \nWebsite: https://Osevenv.github.io");
                    break;
                case "shutdown" or "turnoff" or "sd":
                    Shutdown(false);
                    break;
                case "reboot" or "restart" or "rb":
                    Shutdown(true);
                    break;
                case "err":
                    Kernel.ErrorScreen("Attempted execute");
                    break;
                case "lib":
                    Lib.Main();
                    break;
                case "prompt":

                    break;
                case "cls" or "clear":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(Kernel.CurrentVersion);
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "echo":
                    Console.WriteLine("Usage: echo 'message'");
                    break;
                case { } when input.StartsWith("echo "):
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(input[5..]);
                    break;
                case "pause":
                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                    break;
                case "sound":
                    Console.Beep();
                    break;
                case "system/Return":
                    Kernel.KernelScreen();
                    break;
                case "ver" or "version":
                    Console.WriteLine(Kernel.CurrentVersion);
                    break;
                case "time" or "date":
                    try { Console.WriteLine(Date.Main()); }
                    catch (Exception e) { Console.WriteLine("Service 'Date' crashed\n" + e); }
                    break;
                case "services":
                    break;
                case "info":
                    Console.WriteLine("System Info\n-----------");
                    try { Sysinfo.Main(); }
                    catch (Exception e) { Console.WriteLine("Service 'System Info' crashed\n" + e); }
                    break;
                case { } when input.StartsWith("ping "):
                    break;
                case "" or null:
                    break;
                case "load":
                    Loading.Main(50);
                    Console.WriteLine(VFSManager.GetDisks());
                    break;
                case "color":
                    Console.WriteLine("Choose your font color");
                    Console.Write("Gray \n DarkGray \n Blue \n Black");
                    switch (Console.BackgroundColor)
                    {

                        case ConsoleColor.Gray:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            break;
                        case ConsoleColor.DarkGray:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case ConsoleColor.Blue:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            break;
                        case ConsoleColor.DarkBlue:
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                    }
                    Console.Clear();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Unknown command '" + input + "', type help for list of commands.");
                    break;
            }
        }
        public static void Boot()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("| OK |");
            Console.ResetColor();
            Console.Write(" Oseven Core\n");
        }
        public static void Shutdown(bool reboot)
        {
            if (Files.content != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("There are unsaved work in app 'Text', do you want to shutdown anyway?\nEnter - continue shutdown and delete unsaved data\nESC - cancel shutdown\nTAB - save data");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        goto exit;
                    case ConsoleKey.Tab:
                        Files.Save();
                        Loading.Main(5);
                        Shutdown(reboot);
                        break;
                    case ConsoleKey.Enter:
                        break;
                    default:
                        return;
                }
            }
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();
            Loading.Main(10);
            if (reboot == true) { Sys.Power.Reboot(); ACPI.Shutdown(); } else { Sys.Power.Shutdown(); ACPI.Reboot(); }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(18, Console.CursorTop = Console.WindowHeight / 2 - 1);
            Console.Write("It is now safe to turn off computer.");
            while (true) ;
            exit:
            Console.WriteLine("\nShutdown cancelled");
        }
        public static void RefreshScreen(int height)
        {
            for (int i = 0; i <= height; i++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Kernel.CurrentVersion);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSuccesfully switched color");
        }
    }
}
