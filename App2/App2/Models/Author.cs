using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class Author
    {
        public Author()
        {
            
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
