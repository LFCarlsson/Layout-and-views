using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layout_and_views.Models
{
    public class PersonList
    {
        public List<Person> Persons { get; set; }
                                 
                            

        public PersonList()
        {
            Persons = people;
        }
        public static List<Person> people = new List<Person>
        {
            new Person()
            {
                Name = "Fredrik Carlsson",
                City = "Nybro",
                PhoneNumber = "076-123 45 67"

            },
            new Person()
            {
                Name = "Steve Holt",
                City = "Örebro",
                PhoneNumber = "071-123 23 78"

            },
            new Person()
            {
                Name = "Nisse Pisse",
                City = "Göteborg",
                PhoneNumber = "058-543 25 12"

            },
            new Person()
            {
                Name = "Britt-Marie Körberg",
                City = "Orrefors",
                PhoneNumber = "678-123 43 57"

            },
            new Person()
            {
                Name = "Nils Nilsson",
                City = "Nybro",
                PhoneNumber = "076-234 45 67"

            },
            new Person()
            {
                Name = "Örjan Örjansson",
                City = "Växjö",
                PhoneNumber = "011-123 34 56"

            },
            new Person()
            {
                Name = "Carl Bildt",
                City = "Stockholm",
                PhoneNumber = "073-256 24 67"

            },
            new Person()
            {
                Name = "Gunnar Växjösson",
                City = "Stockholm",
                PhoneNumber = "073-256 24 67"

            },
            new Person()
            {
                Name = "Edward Blom",
                City = "Stockholm",
                PhoneNumber = "057-243 23 45"

            },
            new Person()
            {
                Name = "Mäktiga Zeus",
                City = "Gränna",
                PhoneNumber = "058-125 68 45"

            },
            new Person()
            {
                Name = "Sven Stensson",
                City = "Växjö",
                PhoneNumber = "356-345 12 23"

            }
        };

        public static void AddPerson(Person person)
        {
            people.Add(person);
        }

        public static void Remove(int id)
        {
            try
            {
                people.RemoveAll(x => x.Id == id);
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// Sort the 
        /// </summary>
        /// <param name=""></param>
       
        public static IEnumerable<Person> Filter(string filter, bool caseSensitive, IEnumerable<Person> people)
        {
            IEnumerable<Person> result;
            if (!caseSensitive)
            {
                filter = filter.ToLower();
                result = from person in people
                                             where (person.Name.ToLower().Contains(filter) || person.City.ToLower().Contains(filter) )
                                             select person;
            }
            else
            {
                result = from person in people
                         where (person.Name.Contains(filter) || person.City.Contains(filter))
                         select person;
            }
            return result;
        }
        public static IEnumerable<Person> Sort(bool byName, IEnumerable<Person> people)
        {
            return people.OrderBy(person => byName ? person.Name : person.City);
        }

    }
}