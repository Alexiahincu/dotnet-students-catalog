using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace dotnet_students_catalog
{
    class Program
    {
        static List<Person> personList = new List<Person>();
        static StringBuilder fileInfo=new StringBuilder();
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
                fileInfo.AppendLine(read.ReadLine());
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
                string[] parts = command.Split(' ');
                switch (parts.Length)
                {
                    case 5 when parts[0].ToLower() == "add" && parts[1].ToLower() == "person":
                        {
                            command = parts[0] + " " + parts[1];
                            break;
                        }
                    case 3 when parts[0].ToLower() == "find" && parts[1].ToLower() == "person":
                        {
                            command = parts[0] + " " + parts[1];
                            break;
                        }
                    case 4 when parts[0].ToLower() == "find" && parts[1].ToLower() == "person":
                        {
                            //if someone is searched by full name
                            command = parts[0] + " " + parts[1];
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
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
                            if (!PersonHelper.PersonCheck(parts[2], parts[3], personList))
                            {
                                int age = 0;
                                if (parts.Length == 5 && int.TryParse(parts[4], out age))
                                {
                                    personList.Add(new Person(parts[2], parts[3], age));
                                    Console.WriteLine($"New person added: {parts[2]} {parts[3]}, {age}");
                                }
                            }
                            else Console.WriteLine($"{parts[2]} {parts[3]} already exists.");
                            break;
                        }
                    case "find person":
                        {
                            PersonHelper.FindPerson(parts, personList);
                            break;
                        }

                    case "list persons":
                        {
                            PersonHelper.ListPersons(personList);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Array.Clear(parts, 0, parts.Length);
            }
        }
    }
}