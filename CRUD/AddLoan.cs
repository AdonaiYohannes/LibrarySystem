using System;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using Microsoft.VisualBasic;

namespace Library.Operations
{
    public class AddLoan
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.Write("Enter Borrower ID: ");
                if(!int.TryParse(Console.ReadLine(), out var borrowerId))
                {
                    Console.WriteLine("Invalid Borrower ID");
                    return;
                }

                Console.Write("Enter Book ID: ");
                if(!int.TryParse(Console.ReadLine(), out var bookId))
                {
                    Console.WriteLine("Invalid Book ID");
                    return;
                }

                Console.Write("Enter loan Date (yyyy-MM-dd): ");
                if(!DateTime.TryParse(Console.ReadLine(), out var dueDate))
                {
                    Console.WriteLine("Invalid format!");
                    return;
                }

                var loan = new Loan
                {
                    BorrowerId = borrowerId,
                    BookId = bookId,
                    LoanDate = dueDate
                };

                context.Loans.Add(loan);
                context.SaveChanges();

                Console.WriteLine($"Loan added successfully for Book ID {bookId} to Borrower ID {borrowerId} with loan date {dueDate}.");
            }
        }
    }
}