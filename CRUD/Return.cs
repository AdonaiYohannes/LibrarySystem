using System;
using Library.Models;

public class ReturnBook
{
    public static void ReturnBook()
        {
            Console.WriteLine("\nEnter Borrower ID: ");
            int borrowerId = int.Parse(Console.ReadLine());
            var borrower = Borrower.(b => b.Id == borrowerId);

            if (borrower == null)
            {
                Console.WriteLine("Borrower not found.");
                return;
            }

            Console.WriteLine("\nEnter Book ID to Return: ");
            int bookId = int.Parse(Console.ReadLine());

            if (!borrower.BorrowedBooks.Contains(bookId))
            {
                Console.WriteLine("You have not borrowed this book.");
                return;
            }

            var book = Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                book.IsBorrowed = false;
                borrower.BorrowedBooks.Remove(book.Id);

                Console.WriteLine($"You returned: {book.Title}");
            }
        }
}