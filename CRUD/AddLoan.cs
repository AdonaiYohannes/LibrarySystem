using System;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Operations
{
    public class AddLoan
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.Write("Enter Borrower ID: ");
                int borrowerId = int.Parse(Console.ReadLine());

                Console.Write("Enter Book ID: ");
                int bookId = int.Parse(Console.ReadLine());

                Console.Write("Enter Due Date (yyyy-MM-dd): ");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());

                var loan = new Loan
                {
                    BorrowerId = borrowerId,
                    BookId = bookId,
                    LoanDate = DateTime.Now,
                    ReturnDate = dueDate
                };

                context.Loans.Add(loan);
                context.SaveChanges();

                Console.WriteLine($"Loan added successfully for Book ID {bookId} to Borrower ID {borrowerId}.");
            }
        }
    }
}