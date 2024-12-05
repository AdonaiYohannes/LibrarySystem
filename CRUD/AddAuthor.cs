using System;
using Library.Models;

namespace Library.Operations
{
    public class AddAuthor
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Enter Author First Name: ");
                var firstName = Console.ReadLine();
                Console.WriteLine("Enter Author Last Name: ");
                var lastName = Console.ReadLine();

                var author = new Author {FirstName = firstName, LastName = lastName};
                context.Authors.Add(author);
                context.SaveChanges();

                Console.WriteLine ($"Author {firstName} {lastName} has been added.");
            }
        }
    }


}