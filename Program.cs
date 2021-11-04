﻿using System;
using System.IO;
namespace dotnet_students_catalog
{
    class Program
    {
        static string[] fileInfo = new string[5];
        static int rowsNumber = 0;
        static void Main(string[] args)
        {
            StartCommandLoop();
        }
        static void ExtractFileInfo()
        {
            string readPath = "About.txt";

            StreamReader read = new StreamReader(readPath);
            while (!read.EndOfStream)
            {
                fileInfo[rowsNumber] = read.ReadLine();
                rowsNumber++;
            }
        }
        static void ShowInfo()
        {
            for (int i = 0; i < rowsNumber; i++)
            {
                Console.WriteLine(fileInfo[i]);
            }
        }
        static void StartCommandLoop()
        {
            Console.WriteLine("Enter the command 'exit' to close the program.");
            Console.WriteLine("For more information, enter the command 'about'.");
            bool exit = false;
            string command = "";
            ExtractFileInfo();
            while (exit == false)
            {
                Console.Write("Enter a command: ");
                command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "about":
                    {
                        ShowInfo();
                        break;
                    }
                    case "exit":
                    {
                        exit=true;
                        break;
                    }
                    case "costi":
                    {
                        Console.WriteLine("FORTZA!"); //I love Easter eggs! <3
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }
    }
}
