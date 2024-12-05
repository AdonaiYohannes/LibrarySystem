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
                int bookId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Author ID: ");
                int authorId = int.Parse(Console.ReadLine());
                // add if (incase input format is not correct)

                var bookAuthor = new BookAuthor {BookId = bookId, AuthorId = authorId};
                context.BookAuthors.Add(bookAuthor);
                context.SaveChanges();

                Console.WriteLine($"Relationship between Book {bookId} and Author {authorId} has been added.");

            }
        }
    }
}