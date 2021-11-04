using System;
using System.IO;
using System.Collections.Generic;
namespace dotnet_students_catalog
{
    class Program
    {
        static List<Person> personList = new List<Person>();
        static string[] fileInfo = new string[5];
        static int rowsNumber = 0;

        class Person
        {
            public string FirstName, LastName;
            public int Age;
            public Person(string firstname, string lastname, int age)
            {
                FirstName = firstname;
                LastName = lastname;
                Age = age;
            }
            public void Greet()
            {
                Console.WriteLine($"Welcome, {FirstName} {LastName} ({Age})! :)");
            }
        }
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
                    default:
                        {
                            break;
                        }
                }
                switch (command.ToLower())
                {
                    case "about":
                        {
                            ShowInfo();
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
                                personList.Add(new Person(parts[2], parts[3], age));
                                Console.WriteLine($"New person added: {parts[2]} {parts[3]}, {age}");
                            }
                            break;
                        }
                    case "find person":
                        {
                            if (parts.Length == 3)
                            {
                                foreach (Person someone in personList)
                                {
                                    if (someone.FirstName == parts[2])
                                        someone.Greet();
                                }
                            }
                            break;
                        }

                    case "list persons":
                        {
                            foreach (Person someone in personList)
                            {
                                someone.Greet();
                            }
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