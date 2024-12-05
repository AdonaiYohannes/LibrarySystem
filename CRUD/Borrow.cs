using System;
using System.Linq;
using Library.Models;

namespace LibrarySystem.Operations
{
    public class Borrow
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.Write("Enter Borrower ID: ");
                int borrowerId = int.Parse(Console.ReadLine());

                Console.Write("Enter Book ID: ");
                int bookId = int.Parse(Console.ReadLine());

                var borrower = context.Borrowers.Find(borrowerId);

                if (borrower == null)
                {
                    Console.WriteLine("Borrower not found.");
                    return;
                }

                int currentLoans = context.Loans.Count(l => l.BorrowerId == borrowerId && l.ReturnDate == null);

                if (currentLoans >= borrower.MaxBooksAllowed)
                {
                    Console.WriteLine("Borrower has reached the maximum book loan limit.");
                    return;
                }

                var loan = new Loan
                {
                    BorrowerId = borrowerId,
                    BookId = bookId,
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(14) // Default loan period
                };

                context.Loans.Add(loan);
                context.SaveChanges();

                Console.WriteLine($"Book ID {bookId} successfully borrowed by Borrower ID {borrowerId}.");
            }
        }
    }
}




