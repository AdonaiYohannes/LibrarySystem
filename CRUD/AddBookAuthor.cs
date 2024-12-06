using System;
using System.Linq;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class AddBookAuthor
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Enter Book ID: ");
                if (!int.TryParse(Console.ReadLine(), out var bookId))
                {
                    Console.WriteLine("Invalid Book ID!");
                    return;
                }
                Console.WriteLine("Enter Author ID: ");

                if(!int.TryParse(Console.ReadLine(), out var authorId))
                {
                    Console.WriteLine("Invalid Author ID: ");
                    return;
                }
                var bookAuthor = new BookAuthor {BookId = bookId, AuthorId = authorId};
                context.BookAuthors.Add(bookAuthor);
                context.SaveChanges();

                Console.WriteLine($"Relationship between Book {bookId} and Author {authorId} has been added.");

            }
        }
    }
}