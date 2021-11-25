using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace dotnet_students_catalog
{
    class Program
    {
        private static List<Person> personList = new List<Person>();
        private static StringBuilder fileInfo = new StringBuilder();
        static void Main(string[] args)
        {
            StartCommandLoop();
        }

        private static void ExtractFileInfo()
        {
            string readPath = "About.txt";

            StreamReader read = new StreamReader(readPath);
            while (!read.EndOfStream)
            {
                fileInfo.AppendLine(read.ReadLine());
            }
        }
        private static string ExtractCommand(string command, string[] parts)
        {
            switch (parts[0])
            {
                case "add" when parts[1].ToLower() == "person":
                    {
                        return parts[0] + " " + parts[1];
                    }
                case "find" when parts[1].ToLower() == "person":
                    {
                        return parts[0] + " " + parts[1];
                    }
                default:
                    {
                        return command;
                    }
            }
        }
        private static void ExecuteCommand(string command, string[] parts, ref bool exit)
        {
            switch (command.ToLower())
            {
                case "about":
                    {
                        Console.WriteLine(fileInfo);
                        break;
                    }
                case "exit":
                    {
                        exit = true;
                        break;
                    }
                case "costi":
                    {
                        Console.WriteLine("FORTZA!"); //I love Easter eggs! <3
                        break;
                    }
                case "add person":
                    {
                        int age = 0;
                        if (parts.Length == 5 && int.TryParse(parts[4], out age))
                        {
                            PersonHelper.AddPerson(parts[2], parts[3], age, personList);
                        }
                        else
                        {
                            Console.WriteLine("Not valid parameters.");
                            Console.WriteLine("To add a person, first introduce the full name, then the age.");
                        }
                        break;
                    }
                case "find person":
                    {
                        string nameToSearch = "";
                        switch (parts.Length)
                        {
                            case 3:
                                {
                                    nameToSearch = parts[2];
                                    PersonHelper.FindPerson(nameToSearch, personList);
                                    break;
                                }
                            case 4:
                                {
                                    nameToSearch = parts[2] + " " + parts[3];
                                    PersonHelper.FindPerson(nameToSearch, personList);
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Not valid parameters.");
                                    Console.WriteLine("To find a person, enter one (first or last) name or two (the full name).");
                                    break;
                                }
                        }
                        break;
                    }
                case "list persons":
                    {
                        PersonHelper.ListPersons(personList);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Not valid command.");
                        break;
                    }
            }
            Array.Clear(parts, 0, parts.Length);
        }
        static void StartCommandLoop()
        {
            Console.WriteLine("Enter the command 'exit' to close the program.");
            Console.WriteLine("For more information, enter the command 'about'.");
            bool exit = false;
            ExtractFileInfo();
            while (exit == false)
            {
                Console.Write("Enter a command: ");
                string command = Console.ReadLine();
                string[] parts = command.Split(' ');
                command = ExtractCommand(command, parts);
                ExecuteCommand(command.ToLower(), parts, ref exit);
            }
        }
    }
}