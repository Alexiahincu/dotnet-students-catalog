using System;
using System.IO;
namespace dotnet_students_catalog
{
    class Program
    {
        static void EnterCommand()
        {
            Console.WriteLine("Enter the command 'exit' to close the program.");
            Console.WriteLine("For more information, enter the command 'about'.");
            bool exit = false;
            string command = "";
            string readPath = "D:\\Repositories\\dotnet-students-catalog\\About.txt";
            string[] fileInfo = new string[5];
            int rowsNumber = 0;
            StreamReader read = new StreamReader(readPath);
            while (!read.EndOfStream)
            {
                fileInfo[rowsNumber] = read.ReadLine();
                rowsNumber++;
            }
            while (exit == false)
            {
                Console.Write("Enter a command: ");
                command = Console.ReadLine();
                if (string.Compare(command, "exit", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    exit = true;
                }
                else if (string.Compare(command, "about", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    for (int i = 0; i < rowsNumber; i++)
                    {
                        Console.WriteLine(fileInfo[i]);
                    }
                }
                else if (string.Compare(command, "costi", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Console.WriteLine("FORTZA!"); //I love easter eggs <3
                }
            }
        }
        static void Main(string[] args)
        {
            EnterCommand();
        }
    }
}
