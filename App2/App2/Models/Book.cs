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
        public string ImageUrl { get; set; } = 
            "http://images.squarespace-cdn.com/content/v1/5aa83bad9772ae97813540d0/1546342351907-4R2L1N4GITARI03VU9N0/ke17ZwdGBToddI8pDm48kJPo64LO3YZG-4f-ST8EfI9Zw-zPPgdn4jUwVcJE1ZvWEtT5uBSRWt4vQZAgTJucoTqqXjS3CfNDSuuf31e0tVGunbRojLjYM_qWg5xABZ5ZcuB4bj617U7w2cj588VrBRur-lC0WofN0YB1wFg-ZW0/cover_UC95Q8VU77.png";
        public string AuthorName => $"{Author?.FirstName} {Author?.LastName}";
        public Author Author { get; set; }
    }
}
