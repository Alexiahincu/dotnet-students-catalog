using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_students_catalog
{
    public class Person
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
}