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
                    var book1 = context.Books.First(B => B.Titel == "When I was a teenager?");
                    var author1 = context.Authors.First(A => A.FirstName == "Niko" && A.LastName == " Rask");
                    var book2 = context.Books.First(B => B.Titel ==  "Why I'm the GOAT");
                    var author2 = context.Authors.First(A => A.FirstName == "Ashok" && A.LastName == " Tamang");
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