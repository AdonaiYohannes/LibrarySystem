using System;
using Library.Models;

namespace Library.Operations
{
    public class AddBook
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Enter Book Title: ");
                var title = Console.ReadLine();
                Console.WriteLine("Enter Books Publishing year(yyyy-mm-dd): ");
                var publishedYear = int.Parse (Console.ReadLine());
                Console.WriteLine("Enter ISBN: ");
                var isbn = Console.ReadLine();
                

                var book = new Book {Titel = title, PublishedYear = publishedYear, ISBN = isbn };
                context.Books.Add(book);
                context.SaveChanges();
                
                Console.WriteLine($"Book {title}, with Published Year {publishedYear} and ISBN {isbn} has been added.");
            }
        }
    }
}