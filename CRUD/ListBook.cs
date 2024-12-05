using System;
using System.Linq;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Operations
{
    public class ListBook
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                var books = context.Books.Include(b => b.BookAuthors).ToList();
                Console.WriteLine("\nAvailable Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.ID}, Title: {book.Titel}, ISBN: {book.ISBN}");

                    if (book.BookAuthors != null && book.BookAuthors.Any())
                    {
                        foreach (var bookAuthor in book.BookAuthors)
                        {
                            var author = context.Authors.FirstOrDefault(a => a.Id == bookAuthor.AuthorId):
                            if (author != null)
                            {
                                Console.WriteLine($"- {author.FirstName} {author.LastName}");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}