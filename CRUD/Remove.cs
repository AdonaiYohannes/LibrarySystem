using System;
using Library.Models;
using System.Linq;

namespace Library.Operations
{
    public class Remove
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Enter the ID of the entity to remove:");
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the entity type (Book/Author/Loan):");
                var entityType = Console.ReadLine().ToLower();

                switch (entityType)
                {
                    case "book":
                        var book = context.Books.Find(id);
                        if (book != null)
                        {
                            context.Books.Remove(book);
                            context.SaveChanges();
                            Console.WriteLine($"Book '{book.Titel}' removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;

                    case "author":
                        var author = context.Authors.Find(id);
                        if (author != null)
                        {
                            context.Authors.Remove(author);
                            context.SaveChanges();
                            Console.WriteLine($"Author '{author.FirstName} {author.LastName}' removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Author not found.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid entity type.");
                        break;
                }
            }
        }
    }
}