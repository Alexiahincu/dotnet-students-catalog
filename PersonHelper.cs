using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_students_catalog
{
    public static class PersonHelper
    {
        public static void FindPerson(string[] parts, List<Person> personList)
        {
            if (parts.Length == 3 || parts.Length == 4)
            {
                foreach (Person someone in personList)
                {
                    if (someone.FirstName == parts[2] || someone.LastName == parts[2])
                        someone.Greet();
                }
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