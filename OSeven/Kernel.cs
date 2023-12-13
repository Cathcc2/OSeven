using System;
using Sys = Cosmos.System;
using System.Threading;
using OSeven.files;
using OSeven.lib;
using OSeven.date;
using OSeven.loading;
using OSeven.sysinfo;
using OSeven.input;
using OSeven.shell;
using Oseven.oseven;

namespace OSeven
{
    public class Kernel : Sys.Kernel
    {
        public static string CurrentVersion = "OSeven Alpha 0.1";
        
        protected override void BeforeRun()
        {
            KernelBoot();
        }
        protected override void Run()
        {

            try
            {
                Shell.Main();
            }
            catch (Exception e)
            {
                ErrorScreen(Convert.ToString(e));
            }
        }
        public static void ErrorScreen(string errormsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i <= Console.WindowHeight; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine();
            }
            Console.WriteLine(CurrentVersion + "\n\nCritical System Error\n\n" + errormsg);
            Thread.Sleep(1000);
            Console.Write("\nRestarting computer in 5 seconds...");
            Loading.Main(10);
            Console.CursorLeft = 0;
            Console.Write("Restarting computer in 4 seconds...");
            Loading.Main(10);
            Console.CursorLeft = 0;
            Console.Write("Restarting computer in 3 seconds...");
            Loading.Main(10);
            Console.CursorLeft = 0;
            Console.Write("Restarting computer in 2 seconds...");
            Loading.Main(10);
            Console.CursorLeft = 0;
            Console.Write("Restarting computer in 1 second....");
            Loading.Main(5);
            Console.Clear();
            Loading.Main(5);
            Sys.Power.Reboot();
        }
        public static void KernelBoot()
        {
            Console.Clear();
            Console.WriteLine("                                                         ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ======    ======   =====  =       =  =====   ==     =    ");
            Console.WriteLine("||    ||   ||       ||     =       =  ||      = =    =    ");
            Console.WriteLine("||    ||   ||       ||      =     =   ||      =  =   =    ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("||    ||   ======   =====    =   =    =====   =   =  =    ");
            Console.WriteLine("||    ||        ||  ||        = =     ||      =    = =    ");
            Console.WriteLine(" ======    ======   =====      =      =====   =     ==    ");
            Console.WriteLine("                                                         ");
            //Boot sequence
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorLeft = 0;
            Console.Write("Booting OSeven...\n\n");
            //Checking system integrity
            Oseven.oseven.Oseven.Boot();
            Input.Check();
            Shell.Check();
            Lib.Boot();
            Files.Check();
            Sysinfo.Check();
            Date.Check();
            Console.WriteLine("                                                         ");
            Console.Beep(300, 200);
            Console.Beep(300, 200);
            Thread.Sleep(300);
            Console.Beep(400, 100);
            Thread.Sleep(100);
            Console.Beep(500, 100);
            Thread.Sleep(100);
            Console.Beep(600, 100);
            Thread.Sleep(100);
            Console.Beep(700, 100);
            Console.CursorLeft = 0;
            Console.Write("Press any key to continue");
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(CurrentVersion);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();

        }
        public static void KernelScreen()
        {
            Console.ResetColor();
            Console.Write("Press Enter to boot OSeven");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            KernelBoot();
        }
    }
}