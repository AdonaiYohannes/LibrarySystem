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
                Console.WriteLine("Enter Books Publishing year(yyyy): ");
                // var publishedYear = int.Parse (Console.ReadLine());
                var PublishedYear = Console.ReadLine();
                if (!int.TryParse(Console.ReadLine(), out var published))
                {
                    Console.WriteLine("Invalide fromat!");
                    return;
                }
                Console.WriteLine("Enter ISBN: ");
                var isbn = Console.ReadLine();
                

                var book = new Book {Titel = title, PublishedYear = published, ISBN = isbn };
                context.Books.Add(book);
                context.SaveChanges();
                
                Console.WriteLine($"Book {title}, with Published Year {published} and ISBN {isbn} has been added.");
            }
        }
    }
}