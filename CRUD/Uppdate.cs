using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Operations
{
    public class Update
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.Write("Enter Book ID to update: ");
                int bookId = int.Parse(Console.ReadLine());

                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    Console.Write("Enter new Title: ");
                    book.Titel = Console.ReadLine();
                    context.SaveChanges();

                    Console.WriteLine("Book updated successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }
    }
}