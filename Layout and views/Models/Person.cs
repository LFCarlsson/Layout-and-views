using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout_and_views.Models
{
    public class Person
    {
        private static int count = 0;
        public string Name { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int Id { get; private set; }

        public Person()
        {
            Id = count;
            count++;
        }
    }
}