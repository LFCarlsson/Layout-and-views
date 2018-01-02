using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout_and_views.Models
{
    public class OwnerInfo
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string BirthPlace { get; set; }
        public string City { get; set; }
        public string GitHubURL { get; set; }
        public string CVPath { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int Id { get; internal set; }
        public string Email { get; internal set; }
    }
}