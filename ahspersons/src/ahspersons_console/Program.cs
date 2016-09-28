using System;
using System.Collections.Generic;
using Models;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Person(1, "Philippe", "Parent"),
                new Student(2, "Oliviera", "Wilmots", "666-66666-79204")
                
            };
            foreach (var person in persons)
            {
               Console.WriteLine(person.ToString());
            }
        }
    }
}
