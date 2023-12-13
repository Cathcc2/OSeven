using System;
using OSeven.files;
using OSeven.lib;
using OSeven.input;

namespace OSeven.text
{
    public static class Text
    {
        public static void Main()
        {
        text:

            Console.WriteLine(" -------------------------------------------");
            Console.WriteLine("|                TEXT COMMAND               |");
            Console.WriteLine(" -------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("|  new    |      New Text File              |");
            Console.WriteLine("|  open   |      Open a File                |");
            Console.WriteLine("|  save   |      Save input to text file    |");
            Console.WriteLine("|  TAB    |      QUIT                       |");
            Console.WriteLine(" -------------------------------------------");
       
            switch (Input.Main("Text", ConsoleColor.White))
            {
 
                case "new":
                    if (Files.content != null)
                    {
                        Console.WriteLine("Warning: Temp memory cleared");
                        Files.content = null;
                    }
                    Files.content = Console.ReadLine();
                    goto text;
                case "open":
                    Console.WriteLine("\nSelect file...");
                    Files.Main();
                    Console.Write("\nFile opened\n" + Files.textfromfile);
                    Files.content = Console.ReadLine();
                    goto text;
                case "save":
                    Files.Save();
                    goto text;
                case "system/return":
                    if (Files.content != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Text saved in temp memory");
                    }
                    Lib.Main();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Unknown command");
                    Console.ResetColor();
                    goto text;
            }
        }

    }
}