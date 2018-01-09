﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layout_and_views.Models
{
    public class PersonList
    {
        public string SearchString { get; set; }
        public bool SortReverse { get; set; }
        public bool SortCaseSensitive { get; set; }
        public List<Person> Persons { get { return PersonList.persons; }
                                      private set { PersonList.persons = value; }
                                    }
        public List<Person> PersonSearch { get; set; }

        public PersonList()
        {
            SearchString = "";
            Search();
        }
        public static List<Person> persons = new List<Person>
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
        public static void Remove(int id)
        {
            try
            {
                persons.RemoveAll(x => x.Id == id);
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// Sorts PersonSeach according to conditions in SortReverse and SortCaseSensitive
        /// </summary>
        public void SortByName()
        {
            if(SortCaseSensitive)
            {
                PersonSearch = PersonSearch.OrderBy(x => x.Name).ThenBy(x => x.City).ToList();
            }
            else
            {
                PersonSearch = PersonSearch.OrderBy(x => x.Name.ToLower()).ThenBy(x => x.City).ToList();
            }
            if (SortReverse)
            {
                PersonSearch.Reverse();
            }
        }
        public void SortByCity()
        {
            if (SortCaseSensitive)
            {
                PersonSearch = PersonSearch.OrderBy(x => x.City).ThenBy(x => x.Name).ToList();
            }
            else
            {
                PersonSearch = PersonSearch.OrderBy(x => x.City.ToLower()).ThenBy(x => x.Name.ToLower()).ToList();
            }
            if (SortReverse)
            {
                PersonSearch.Reverse();
            }
        }
        public void Search()
        {
            if (SearchString != "" || SearchString != null)
            {
                foreach (var person in persons)
                {
                    PersonSearch = Persons.Where(x => x.Name.ToLower().Contains(SearchString.ToLower()) || x.City.ToLower().Contains(SearchString.ToLower())).ToList();
                }
            }
            else
            {
                PersonSearch = Persons;
            }
        }
    }
}