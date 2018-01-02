using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout_and_views.Models
{
    public class Project
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GitHub { get; set; }
        public bool Done { get; set; }

        public Project(string title, string description, string github, bool done)
        {
            Title = title;
            Description = description;
            GitHub = github;
            Done = done;
        }
    }
}