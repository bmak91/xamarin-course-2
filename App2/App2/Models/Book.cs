using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class Book
    {
        public Book(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; } = "";
        public string AuthorName => $"{Author?.FirstName} {Author?.LastName}";
        public Author Author { get; set; }
    }
}
