using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_students_catalog
{
    public static class PersonHelper
    {
        public static void AddPerson(string firstname, string lastname, int age, List<Person> personList)
        {
            if (!PersonHelper.PersonCheck(firstname, lastname, personList))
            {
                personList.Add(new Person(firstname, lastname, age));
                Console.WriteLine($"New person added: {firstname} {lastname}, {age}");
            }
            else
            {
                Console.WriteLine($"{firstname} {lastname} already exists.");
            }
        }
        public static void FindPerson(string nameToSearch, List<Person> personList)
        {
            bool found = false;
            if (nameToSearch.Contains(" "))
            {
                string[] nameParts = nameToSearch.Split(' ');
                foreach (Person someone in personList)
                {
                    if (someone.FirstName == nameParts[0] && someone.LastName == nameParts[1])
                    {
                        found = true;
                        someone.Greet();
                    }
                }
            }
            else
            {
                foreach (Person someone in personList)
                {
                    if (someone.FirstName == nameToSearch || someone.LastName == nameToSearch)
                    {
                        found = true;
                        someone.Greet();
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine($"{nameToSearch} does not exist.");
            }
        }
        public static void ListPersons(List<Person> personList)
        {
            foreach (Person someone in personList)
            {
                someone.Greet();
            }
        }
        public static bool PersonCheck(string firstname, string lastname, List<Person> personList)
        {
            foreach (Person someone in personList)
            {
                if (someone.FirstName == firstname && someone.LastName == lastname)
                {
                    return true;
                }
            }
            return false;
        }
    }
}