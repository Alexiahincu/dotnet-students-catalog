using System;

namespace dotnet_students_catalog
{
    class Program
    {
        static void EnterCommand()
        {
            Console.WriteLine("Enter the command 'exit' to close the program.");
            bool exit = false;
            string command = "";
            while (exit == false)
            {
                Console.Write("Enter a command: ");
                command = Console.ReadLine();
                if (string.Compare(command, "exit", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    exit = true;
                }
            }
        }
        static void Main(string[] args)
        {
            EnterCommand();
        }
    }
}
