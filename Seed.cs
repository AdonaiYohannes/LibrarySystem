using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class Seed
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                if (context.Books.Any() || context.Authors.Any() || context.Borrowers.Any())
                    return;
                
                var authors = new[] // Add Author
                {
                    new Author { FirstName = "Ashok", LastName = "Tamang",},
                    new Author { FirstName = "Niko", LastName = "Kohsa"},
                    new Author { FirstName = "George", LastName = "Orwell"}
                };
                context.Authors.AddRange(authors);

                //add book
                //conect book to author
                //add borrower
                //add loan
            }
        }
    }
}