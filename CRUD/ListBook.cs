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
                var books = context.Books.ToList(books => b.BookAuthors);
                Console.WriteLine("\nAvailable Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}");
                }   // hur ska jag skriva ut author till boken?
            }
        }
    }
}