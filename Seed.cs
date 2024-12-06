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
                if (!context.Books.Any())
                {
                    var book1 = new Book 
                    {
                        Titel = "When I was a teenager?",
                        PublishedYear = 1850,
                        ISBN = "mynthbrgvfedcs"
                    };
                    var book2 = new Book
                    {
                        Titel = "Why I'm the GOAT",
                        PublishedYear = 1999,
                        ISBN = "pjraiii12"
                    };
                    context.Books.Add(book1);
                    context.Books.Add(book2);
                    context.SaveChanges();   
                }
                else
                {
                    Console.WriteLine("Book exists!");
                }   
                if (!context.Authors.Any())
                {
                    var author1 = new Author
                    {
                        FirstName = "Niko",
                        LastName = "Rask"
                    };
                    var author2 = new Author
                    {
                        FirstName = "Ashok",
                        LastName = "Tamang"
                    };
                    context.Authors.Add(author1);
                    context.Authors.Add(author2);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Author already exists!");
                }

                if (!context.BookAuthors.Any())
                {
                    var book1 = context.Books.FirstOrDefault(B => B.Titel == "When I was a teenager?");
                    if(book1 == null)
                    {
                        Console.WriteLine("NO book");
                    }
                    var author1 = context.Authors.FirstOrDefault(A => A.FirstName == "Niko" && A.LastName == "Rask");
                    if(author1 == null)
                    {
                        Console.WriteLine("NO author");
                    }
                    var book2 = context.Books.FirstOrDefault(B => B.Titel ==  "Why I'm the GOAT");
                    if(book2 == null)
                    {
                        Console.WriteLine("NO book");
                    }
                    var author2 = context.Authors.FirstOrDefault(A => A.FirstName == "Ashok" && A.LastName == "Tamang");
                    if(author2 == null)
                    {
                        Console.WriteLine("NO author");
                    }
                    context.BookAuthors.Add(new BookAuthor{BookId = book1.ID, AuthorId = author1.Id });
                    context.BookAuthors.Add(new BookAuthor{BookId = book2.ID, AuthorId = author2.Id });
                    context.SaveChanges();

                    Console.WriteLine("Relation has been added");
                }
                else
                {
                    Console.WriteLine("No relation!");
                }
            }
        }
    }
}