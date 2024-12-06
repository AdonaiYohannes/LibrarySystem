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
                var books = context.Books.Include(b => b.BookAuthors)
                    .ThenInclude(b => b.Author)
                    .ToList();

                
                Console.WriteLine("\nAvailable Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.ID}, Title: {book.Titel}, ISBN: {book.ISBN}");

                    foreach (var Author in book.BookAuthors)
                    {
                        Console.WriteLine($"Author ID: {Author.Id}, Name: {Author.Author.FirstName + Author.Author.LastName}");
                    }
                }
            }
        }
    }
}