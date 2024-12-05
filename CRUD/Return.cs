using System;
using System.Linq;
using Library.Models;

namespace LibrarySystem.Operations
{
    public class Return
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                Console.Write("Enter Borrower ID: ");
                int borrowerId = int.Parse(Console.ReadLine());

                Console.Write("Enter Loan ID: ");
                int loanId = int.Parse(Console.ReadLine());

                // Check if borrower exists
                var borrower = context.Borrowers.FirstOrDefault(l => l.LoanId == loanId && l.BorrowerId == borrowerId);
                if (borrower == null)
                {
                    Console.WriteLine("Borrower not found.");
                    return;
                }

                // Checking if loan exists and belongs to the borrower
                var loan = context.Loans.FirstOrDefault(l => l.LoanId == loanId && l.BorrowerId == borrowerId);
                if (loan == null)
                {
                    Console.WriteLine("Loan not found or does not belong to this borrower.");
                    return;
                }

                // Checking if the book is returned
                if (loan.ReturnDate != null)
                {
                    Console.WriteLine("This book has already been returned.");
                    return;
                }

                // Mark the book as returned
                loan.ReturnDate = DateTime.Now;
                context.SaveChanges();

                Console.WriteLine($"Loan ID {loanId} has been successfully returned by Borrower ID {borrowerId}.");
            }
        }
    }
}