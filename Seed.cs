using Library.Models;
using System;
using Microsoft.EntityFrameworkCore;

class program 
{
    static void Main(string[] args)
    {
        using (var context = new LibraryContext())
        {
            // Creating an Author
            var author = new Author 
            {
                FirstName = "John", 
                LastName = "Doe"
            };
            context.Authors.Add(author); //Adding to our Db Author
            context.SaveChanges();

            // Creating a Book
            var book = new Book 
            {
                Titel = "C# Programing", 
                ISBN = "1234567890",
                PublishedYear = 2024
            };
            context.Books.Add(book); // Adding to our Db Book
            context.SaveChanges();   // Saves changes that are made

            // Relation between Book and Author
            var bookAuthor = new BookAuthor
            {
                BookId = bookId,
                AuthorId = authorId,
            };
            context.BookAuthors.Add(bookAuthor);
            context.SaveChanges();
        
        }
    }
}